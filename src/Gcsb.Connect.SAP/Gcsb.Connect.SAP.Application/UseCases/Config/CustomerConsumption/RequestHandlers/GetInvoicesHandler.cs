using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption.RequestHandlers
{
    public class GetInvoicesHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoicesHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(CustomerConsumptionRequest request)
        {
            var invoices = request.Customers.Select(s => s.InvoiceNumber).ToList();
            var actualDate = DateTime.UtcNow;
            var endPeriod = actualDate.Day >= 27 ? DateTime.UtcNow : DateTime.UtcNow.AddMonths(-1);
            var initPeriod = endPeriod.AddMonths(-6);            
            var endDay = DateTime.DaysInMonth(endPeriod.Year, endPeriod.Month);

            request.Invoices = invoiceReadOnlyRepository.GetInvoices(w => invoices.Contains(w.InvoiceNumber) && (
                (w.BillFrom.HasValue && w.BillFrom.Value.Date >= new DateTime(initPeriod.Year, initPeriod.Month, 1)) &&
                (w.BillTo.HasValue && w.BillTo.Value.Date <= new DateTime(endPeriod.Year, endPeriod.Month, endDay))
            ));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}