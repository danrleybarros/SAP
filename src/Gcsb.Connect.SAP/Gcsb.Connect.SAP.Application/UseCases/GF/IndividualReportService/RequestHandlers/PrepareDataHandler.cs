using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.Messaging.Messages.Log;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService.RequestHandlers
{
    public class PrepareDataHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public PrepareDataHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(ISIChainRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Consulting data and grouping result - Individual Report Service"));
            request.Invoices = invoiceReadOnlyRepository.GetInvoicesFromIdFileReturnNF(request.IdFile);

            if (request.Invoices.Count > 0)
                request.Lines.AddRange(request.Invoices.GroupBy(g => g.InvoiceNumber)
                    .Select(s => new Domain.GF.IndividualReportService(Domain.Util.LastDayOfThePreviousMonth(s.FirstOrDefault()))).ToList());

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
