using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public class InvoiceHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public InvoiceHandler(IInvoiceReadOnlyRepository invoiceHandler)
        {
            this.invoiceReadOnlyRepository = invoiceHandler;
        }

        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Consulting Invoices - FAT");
            request.Invoices = invoiceReadOnlyRepository.GetInvoicesFromIdFile(request.IdBillFeed);

            sucessor?.ProcessRequest(request);
        }
    }
}
