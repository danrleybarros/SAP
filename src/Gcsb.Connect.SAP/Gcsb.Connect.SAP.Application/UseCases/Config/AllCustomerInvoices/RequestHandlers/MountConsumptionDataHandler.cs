using Gcsb.Connect.SAP.Application.Boundaries.AllCustomerInvoices;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomerInvoices.RequestHandlers
{
    public class MountConsumptionDataHandler : Handler
    {
        public override void ProcessRequest(AllCustomerInvoicesRequest request)
        {
            request.Invoices.ForEach(invoice =>
            {
                var services = new List<Boundaries.AllCustomerInvoices.Services>();
                var dueDate = invoice.Services.Select(s => s.DueDate).FirstOrDefault();

                invoice.Services.ForEach(service =>
                {
                    services.Add(new Boundaries.AllCustomerInvoices.Services(
                        service.ServiceCode,
                        service.ServiceName,
                        service.ServiceType,
                        Convert.ToDecimal(service.GrandTotalRetailPrice),
                        service.Activity,
                        service.OrderCreationDate));
                });

                request.Consumptions.Add(new AllCustomerInvoicesOutput(
                    long.Parse($"7{invoice.Customer.CustomerCode.PadLeft(9, '0')}"),
                    invoice.Customer.CompanyName,
                    invoice.CycleCode?.ToString("MM/yyyy"),
                    invoice.InvoiceNumber,
                    dueDate.Value,
                    invoice.TotalInvoicePrice ?? 0,
                    services,
                    GetPaymentStatus(invoice.InvoiceNumber, request.PaymentsCredit, request.PaymentsBoleto),
                    GetPaymentDate(invoice.InvoiceNumber, request.PaymentsCredit, request.PaymentsBoleto)
                    ));
            });

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }

        private string GetPaymentStatus(string invoiceNumber, List<PaymentCreditCard> paymentCredit, List<PaymentBoleto> paymentBoleto)
        {
            var status = "Aberto";
            var credit = paymentCredit.Where(w => w.InvoiceNumberJsdn.Equals(invoiceNumber)).FirstOrDefault();
            var boleto = paymentBoleto.Where(w => w.InvoiceNumberJsdn.Equals(invoiceNumber)).FirstOrDefault();

            if (credit != null || boleto != null)
                status = "Fechado";

            return status;
        }

        private DateTime? GetPaymentDate(string invoiceNumber, List<PaymentCreditCard> paymentCredit, List<PaymentBoleto> paymentBoleto)
        {
            var credit = paymentCredit.Where(w => w.InvoiceNumberJsdn.Equals(invoiceNumber)).FirstOrDefault();
            var boleto = paymentBoleto.Where(w => w.InvoiceNumberJsdn.Equals(invoiceNumber)).FirstOrDefault();

            if (credit != null)
                return credit.TransactionDate;
            else if (boleto != null)
                return boleto.TransactionDate;
            else
                return null;
        }
    }
}
