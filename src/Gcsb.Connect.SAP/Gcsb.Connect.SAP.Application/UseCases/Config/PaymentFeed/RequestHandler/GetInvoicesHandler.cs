using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeed.RequestHandler
{
    public class GetInvoicesHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoicesHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(PaymentFeedRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog("PaymentFeedData", "Getting invoices by date filter"));
            request.Invoices.AddRange(invoiceReadOnlyRepository.GetInvoices(w => w.BillFrom.Value.Date >= request.BillFromDate
                                                                       && w.BillTo.Value.Date <= request.BillToDate
                                                                       && w.PaymentMethod.Equals(request.PaymentMethod)));

            if (request.Invoices.Count == 0)
            {
                request.Logs.Add(Log.CreateProcessingLog("PaymentFeedData", $"Not found invoices to {request.PaymentMethod}"));
                return;
            }

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
