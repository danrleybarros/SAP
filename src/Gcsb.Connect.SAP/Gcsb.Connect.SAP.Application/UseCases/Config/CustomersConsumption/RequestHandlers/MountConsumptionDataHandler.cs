using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomersConsumption.RequestHandlers
{
    public class MountConsumptionDataHandler : Handler
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public MountConsumptionDataHandler(ICustomerReadOnlyRepository customerReadOnlyRepository, 
            IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(CustomersConsumptionRequest request)
        {
            request.Invoices.ForEach(invoice =>
            {
                request.Consumptions.Add(new Boundaries.CustomersConsumption.CustomersOutput(
                    invoice.Customer.CustomerCode,
                    invoice.InvoiceNumber,
                    GetAccountStartDate(invoice.Customer.CustomerCode), 
                    invoice.InvoiceStatus,
                    invoice.InvoiceCreationDate,
                    invoice.CycleCode.Value,
                    GetPaymentDate(invoice.InvoiceNumber, request.PaymentsCredit, request.PaymentsBoleto),
                    GetPaymentValue(invoice.InvoiceNumber, request.PaymentsCredit, request.PaymentsBoleto),
                    GetInvoicePaid(invoice.InvoiceNumber, request.PaymentsCredit, request.PaymentsBoleto),
                    request.PaymentsBoleto.FirstOrDefault(a => a.InvoiceNumberJsdn == invoice.InvoiceNumber)?.CodigoBarras,
                    GetCreditValue(invoice.InvoiceNumber, request.InvoicesCredit)
                ));
            });

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }

        public decimal GetCreditValue(string invoiceNumber, Dictionary<string, decimal> invoicesCredit)
        {
            decimal credit = 0;

            if (invoicesCredit.Any(f => f.Key == invoiceNumber))
                credit = invoicesCredit.Where(f => f.Key == invoiceNumber).FirstOrDefault().Value;

            return credit;
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

        public decimal? GetPaymentValue(string invoiceNumber, List<PaymentCreditCard> paymentCredit, List<PaymentBoleto> paymentBoleto)
        {
            var credit = paymentCredit.Where(w => w.InvoiceNumberJsdn.Equals(invoiceNumber)).FirstOrDefault();
            var boleto = paymentBoleto.Where(w => w.InvoiceNumberJsdn.Equals(invoiceNumber)).FirstOrDefault();

            return credit?.TransactionAmount ?? boleto?.ValorRecebido ?? 0m;
        }

        private DateTime? GetPaymentDate(string invoiceNumber, List<PaymentCreditCard> paymentCredit, List<PaymentBoleto> paymentBoleto)
        {
            var credit = paymentCredit.Where(w => w.InvoiceNumberJsdn.Equals(invoiceNumber)).FirstOrDefault();
            var boleto = paymentBoleto.Where(w => w.InvoiceNumberJsdn.Equals(invoiceNumber)).OrderByDescending(o => o.TransactionDate).FirstOrDefault();

            return credit?.TransactionDate ?? boleto?.TransactionDate;
        }

        private bool GetInvoicePaid(string invoiceNumber, List<PaymentCreditCard> paymentCredit, List<PaymentBoleto> paymentBoleto)
        {
            var IsCredicardPaid = paymentCredit.Any(w => w.InvoiceNumberJsdn.Equals(invoiceNumber) && (w.ResultCode >= 0 && w.ResultCode <= 99));
            var IsBoletoPaid = paymentBoleto
                .Where(w => w.InvoiceNumberJsdn.Equals(invoiceNumber))
                .GroupBy(g => g.TransactionAmount)
                .Select(s => new { TransactionAmount = s.Key.Value, ValorRecebido = s.Sum(s => s.ValorRecebido) })
                .Any(a => a.ValorRecebido >= a.TransactionAmount);

            return IsCredicardPaid || IsBoletoPaid;
        }
    }
}
