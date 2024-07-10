using Gcsb.Connect.SAP.Application.Boundaries.GetOpenInvoices;
using Gcsb.Connect.SAP.Application.Repositories.Pay;
using Gcsb.Connect.SAP.Domain.PAY;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices.RequestHandlers
{
    public class PayFilterHandler : Handler<GetOpenInvoicesRequest>
    {
        private readonly IServicePay servicePay;

        public PayFilterHandler(IServicePay servicePay)
        {
            this.servicePay = servicePay;
        }

        public override void ProcessRequest(GetOpenInvoicesRequest request)
        {
            var invoices = request.OpenInvoicesOutput.Select(a => a.InvoiceNumber).ToList();

            if (invoices.Any())
            {
                var paidInvoices = servicePay.GetInvoicePayment(invoices);

                request.OpenInvoicesOutput.GroupJoin(paidInvoices,
                    open => open.InvoiceNumber,
                    paid => paid.InvoiceNumber,
                    (open, paid) => new { open, paid })
                    .ToList()
                    .ForEach(f => UpdatePaimentAmount(f.open, f.paid, request));
            }

            sucessor?.ProcessRequest(request);
        }

        public void UpdatePaimentAmount(InvoiceOutput invoiceOutput, IEnumerable<InvoicePayment> invoicePayments, GetOpenInvoicesRequest request)
        {
            if (!invoicePayments.Any()) return;

            var amount = request.Payments.OfType<Domain.JSDN.PaymentCreditCard>()
                .Where(a => a.InvoiceNumberJsdn == invoiceOutput.InvoiceNumber)
                .Sum(a => a.PaymentValue) ?? 0;

            invoiceOutput.PaidAmount = amount + invoicePayments.Sum(a => a.PaidAmount);

            if (invoiceOutput.PaidAmount >= invoiceOutput.InvoiceAmount)
            {
                request.OpenInvoicesOutput.Remove(invoiceOutput);
                return;
            }
        }
    }
}
