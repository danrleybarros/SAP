using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices.RequestHandlers
{
    public class MountOutputHandler : Handler
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public MountOutputHandler(ICustomerReadOnlyRepository customerReadOnlyRepository,
            IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(CustomerServicesRequest request)
        {
            request.Logs.Add(new Log("CustomerServicesUseCase - MountOutputHandler", "Mounting Output object", TypeLog.Processing));

            request.ServicesInvoices.ForEach(service =>
            {
                request.CustomerServices.Add(new Domain.Config.CustomerService.CustomerService()
                {
                    AccountStartDate = (DateTime)GetAccountStartDate(service.Invoice.Customer.CustomerCode),
                    AccountStatus = service.Invoice.Customer.UserAccountStatus,
                    CustomerCode = service.Invoice.Customer.CustomerCode,
                    PaymentMethod = service.Invoice.PaymentMethod,
                    ProductType = service.ServiceType,
                    TotalInvoicePrice = service.Invoice.TotalInvoicePrice ?? 0,
                    UF = Util.GetUF(service.Invoice.Customer.MailingStateOrProvince, StoreType.TBRA).Uf,
                    CustomerAccount = service.Invoice.Customer.CustomerEmailAddress,
                    ServiceCode = service.ServiceCode,
                    InvoiceNumber = service.InvoiceNumber,
                    OrignalDueDate = Convert.ToDateTime(service.DueDate),
                    OldestDueDate = Convert.ToDateTime(service.DueDate)
                });
            });
        }

        public DateTime? GetAccountStartDate(string customerCode)
        {
            var invoices = customerReadOnlyRepository
                .GetCustomers(s => s.CustomerCode == customerCode)
                .Select(i => i.InvoiceNumber)
                .ToList();

            return invoiceReadOnlyRepository
                .GetInvoices(s => invoices.Contains(s.InvoiceNumber))
                .OrderBy(o => o.InvoiceCreationDate)
                .FirstOrDefault()
                .InvoiceCreationDate;
        }
    }
}
