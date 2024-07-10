using Gcsb.Connect.SAP.Application.Boundaries.GetOpenInvoices;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices.RequestHandlers
{
    public class InvoiceFilterHandler : Handler<GetOpenInvoicesRequest>
    {
        public override void ProcessRequest(GetOpenInvoicesRequest request)
        {
            var paidBillFeeds = request.Invoices
                .GroupJoin(request.Payments,
                i => i.InvoiceNumber,
                p => p.InvoiceNumberJsdn,
                (i, p) => new { i, p })
                .Where(w => w.p.Sum(a => a.TransactionAmount) > 0 && w.p.Sum(a => a.TransactionAmount) >= w.i.TotalInvoicePrice)
                .Select(s => s.i)
                .ToList();

            request.OpenInvoicesOutput = MountOpenInvoices(request, paidBillFeeds);

            sucessor?.ProcessRequest(request);
        }

        public List<InvoiceOutput> MountOpenInvoices(GetOpenInvoicesRequest request, List<Domain.JSDN.BillFeedSplit.Invoice> paidInvoices)
        {
            var openInvoices = request.Invoices.Where(a => !paidInvoices.Contains(a)).ToList();

            var invoices = openInvoices.Select(i =>
            {
                var customer = request.Customers.First(a => a.InvoiceNumber == i.InvoiceNumber);
                var service = request.Services.First(a => a.InvoiceNumber == i.InvoiceNumber);

                return new InvoiceOutput($"7{ customer.CustomerCode.PadLeft(9, '0')}",
                    customer.CompanyName,
                    customer.CustomerCNPJ,
                    i.InvoiceNumber,
                    i.CycleCode ?? default, //TODO: Este campo deveria poder ser nulo?
                    service.DueDate ?? default, //TODO: Este campo deveria poder ser nulo?
                    i.TotalInvoicePrice ?? 0, //TODO: Este campo deveria poder ser nulo?
                    GetPaidAmount(request.Payments, i.InvoiceNumber));
            }).ToList();

            return invoices;
        }

        public decimal GetPaidAmount(List<Domain.JSDN.PaymentFeedDoc> payments, string invoiceNumber)
        {
            return payments
                .Where(a => a.InvoiceNumberJsdn == invoiceNumber)
                .ToList()
                .Sum(a => a.TransactionAmount ?? 0); //TODO: Este campo deveria poder ser nulo? 
        }
    }
}
