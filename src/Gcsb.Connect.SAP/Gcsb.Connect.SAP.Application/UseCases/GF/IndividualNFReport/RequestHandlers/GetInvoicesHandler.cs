using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.Messaging.Messages.Log;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport.RequestHandlers
{
    public class GetInvoicesHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoicesHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(IndividualReportRequestNF request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Getting invoices by individual invoice = S"));
            request.Invoices = invoiceReadOnlyRepository.GetInvoices(w => w.IdFile.Equals(request.IdBillFeedFile) && w.Customer.IndividualInvoice.Equals("S") && w.InvoiceStatus.Trim().ToLower() != "disregarded" && w.StoreAcronym != "jcteststore");

            sucessor?.ProcessRequest(request);
        }
    }
}
