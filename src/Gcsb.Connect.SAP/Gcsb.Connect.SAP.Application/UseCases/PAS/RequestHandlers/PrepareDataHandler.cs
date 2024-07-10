using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Config;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Domain.PAS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.PAS.RequestHandlers
{
    public class PrepareDataHandler : Handler
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository;
        private readonly IFinancialAccountReadOnlyRepository financialAccountReadOnlyRepository;
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;
        private readonly IFinancialAccountsClient managementFinancialAccountReadOnlyRepository;
        List<string> ignoreActivities = new List<string>() { "credits", "arrear", "fines", "interest", "payment credit", "contractual fine" };

        public PrepareDataHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository,
            IFinancialAccountReadOnlyRepository financialAccountReadOnlyRepository,
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository,
            IFinancialAccountsClient managementFinancialAccountReadOnlyRepository)
        {
            this.serviceReadOnlyRepository = serviceReadOnlyRepository;
            this.financialAccountReadOnlyRepository = financialAccountReadOnlyRepository;
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.paymentFeedReadOnlyRepository = paymentFeedReadOnlyRepository;
            this.managementFinancialAccountReadOnlyRepository = managementFinancialAccountReadOnlyRepository;
        }

        public override void ProcessRequest(PASChainRequest request)
        {
            request.AddProcessingLog("Consulting data and grouping result - PAS");
            var listaServices = serviceReadOnlyRepository.GetPaidServices(request.FilePaymentFeed.Id, ignoreActivities).ToList();
            var listaContas = financialAccountReadOnlyRepository.GetFinancialAccounts(listaServices.Select(s => s.ServiceCode).ToList());
            var error = false;

            listaServices.ForEach(f => f.Account = listaContas.Where(w => w.ServiceCode == f.ServiceCode
              && w.StoreType == Domain.Util.ToEnum<StoreType>(f.Invoice.StoreAcronym)).FirstOrDefault());

            var serviceWithouAccount = listaServices.Where(w => !listaContas.Select(s => s.ServiceCode).ToList().Contains(w.ServiceCode)).ToList();

            serviceWithouAccount.ForEach(f =>
            {
                error = true;
                request.AddExceptionLog($"Service code: {f.ServiceCode} não possui conta", $"Service code: {f.ServiceCode} não possui conta");
            });

            if (!error)
            {
                var stores = listaServices.Select(s => s.Invoice.StoreAcronym).Distinct().ToList();
                stores.ForEach(store =>
                {
                    var storeType = Domain.Util.ToEnum<StoreType>(store);
                    var services = listaServices.Where(w => w.Invoice.StoreAcronym.Equals(store)).ToList();
                    var bodies = GetBodies(services, storeType);
                    request.Lines.Add(storeType, bodies);
                });
            }
            else
                throw new ArgumentException("Not all services have financial account");

            if (request.Lines.Count == 0)
            {
                request.AddProcessingLog($"Not found any services with this paymentfeed: {request.FilePaymentFeed.Id}");
                return;
            }

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }

        public List<Body> GetBodies(List<ServiceFilter> services, StoreType storeType)
        {
            var customers = customerReadOnlyRepository.GetCustomers(services.Select(s => s.Invoice.InvoiceNumber).ToList());
            var payments = paymentFeedReadOnlyRepository.GetPaymentFeedCredit(services.Select(s => s.Invoice.InvoiceNumber).ToList());
            var contaARR = managementFinancialAccountReadOnlyRepository.GetAllManagementFinancialAccount().Where(w => Domain.Util.ToEnum<StoreType>(w.StoreAcronym) == storeType).FirstOrDefault();
            
            if (contaARR is null)
                throw new ArgumentException($"Not found management financial account on database to storeType {storeType}");


            List<Body> bodies = new List<Body>();

            services.ForEach(s => s.Invoice.Customer = customers.Where(x => x.Invoice.InvoiceNumber == s.Invoice.InvoiceNumber).Select(x => x).FirstOrDefault());
            services.ForEach(s => s.Invoice.PaymentFeedsCredit.Add(payments.Where(x => x.InvoiceNumberJsdn == s.Invoice.InvoiceNumber).Select(x => x).FirstOrDefault()));

            var index = 1;

            foreach (var invoiceNumber in services.Select(s => s.Invoice.InvoiceNumber).Distinct())
            {
                var finServices = services.Where(s => s.Invoice.InvoiceNumber == invoiceNumber).ToList();
                var validatePaymentValue = services.Any(f => f.Invoice.TotalInvoicePrice == (f.Invoice.PaymentFeedsCredit.Sum(s => s.TransactionAmount)/100));

                if (finServices.Any())
                {
                    var service = finServices.FirstOrDefault();
                    var payment = new List<PaymentFeedDoc>();

                    finServices.ForEach(s => payment.AddRange(s.Invoice.PaymentFeedsCredit));
                    payment = payment.Distinct().ToList();

                    bodies.Add(new Body(
                        index,
                        service.Invoice.PaymentFeedsCredit.Select(x => x.TransactionDate.Value).FirstOrDefault(),
                        service.Invoice.Customer.CompanyName,
                        service.Invoice.Customer.BillingStreet,
                        service.Invoice.Customer.BillingCity,
                        service.Invoice.Customer.BillingStateOrProvince,
                        long.Parse(service.Invoice.Customer.BillingZIPcode),
                        string.IsNullOrEmpty(service.Invoice.Customer.CustomerCNPJ) ? service.Invoice.Customer.CustomerCPF : service.Invoice.Customer.CustomerCNPJ,
                        validatePaymentValue ? service.Invoice.TotalInvoicePrice.Value : Convert.ToDecimal(finServices.Sum(x => x.GrandTotalRetailPrice)),
                        contaARR.CreditCard.FinancialAccount,
                        service.Invoice.PaymentFeedsCredit.Select(x => x.CardPan).FirstOrDefault(),
                        Convert.ToInt64(service.Invoice.PaymentFeedsCredit.Select(x => x.SIAOperationNumber).FirstOrDefault()),
                        service.Invoice.PaymentFeedsCredit.Select(x => x.AuthorizationID).FirstOrDefault().ToString(),
                        service.Invoice.PaymentFeedsCredit.Select(x => x.CardBrand).FirstOrDefault().ToString()));

                    index++;
                }
            }

            return bodies;
        }
    }
}
