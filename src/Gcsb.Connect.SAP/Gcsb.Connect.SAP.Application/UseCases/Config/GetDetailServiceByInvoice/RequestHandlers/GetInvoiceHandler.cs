using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetDetailServiceByInvoice.RequestHandlers
{
    public class GetInvoiceHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoiceHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(GetDetailServiceByInvoiceRequest request)
        {
            request.Invoices = invoiceReadOnlyRepository
                .GetInvoices(i => request.InvoicesNumber.Contains(i.InvoiceNumber));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
