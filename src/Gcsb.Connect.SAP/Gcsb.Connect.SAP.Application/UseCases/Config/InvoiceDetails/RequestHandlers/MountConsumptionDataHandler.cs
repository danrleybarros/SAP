using Gcsb.Connect.SAP.Application.Boundaries.CustomerConsumption;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InvoiceDetails.RequestHandlers
{
    public class MountConsumptionDataHandler : Handler
    {
        public override void ProcessRequest(InvoiceDetailsRequest request)
        {
            request.Invoices.ForEach(invoice =>
            {                
                var dueDate = invoice.Services.FirstOrDefault(a => a.DueDate != null)?.DueDate ?? default;

                var services = invoice.Services.Select(s => new Boundaries.CustomerConsumption.Services(
                    s.ServiceCode,
                    s.ServiceName,
                    s.ServiceType,
                    Convert.ToDecimal(s.GrandTotalRetailPrice ?? 0),
                    s.Activity,
                    s.OrderCreationDate)).ToList();

                request.Consumptions.Add(new ConsumptionOutput(
                    long.Parse($"7{invoice.Customer.CustomerCode.PadLeft(9, '0')}"),
                    invoice.Customer.CompanyName,
                    invoice.CycleCode?.ToString("MM/yyyy"),
                    invoice.InvoiceNumber,
                    dueDate,
                    invoice.TotalInvoicePrice ?? 0,
                    services,
                    GetPaymentStatus(invoice.InvoiceNumber, request.PaymentsCredit, request.PaymentsBoleto),
                    GetPaymentDate(invoice.InvoiceNumber, request.PaymentsCredit, request.PaymentsBoleto),
                    invoice.StoreAcronym
                    ));
            });

           sucessor?.ProcessRequest(request);
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
