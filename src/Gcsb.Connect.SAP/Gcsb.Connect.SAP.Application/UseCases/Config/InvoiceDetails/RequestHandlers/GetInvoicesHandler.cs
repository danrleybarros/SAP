using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InvoiceDetails.RequestHandlers
{
    public class GetInvoicesHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoicesHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(InvoiceDetailsRequest request)
        {
            request.Invoices = invoiceReadOnlyRepository.GetInvoices(a => request.InvoiceNumbers.Contains(a.InvoiceNumber));

            sucessor?.ProcessRequest(request);
        }
    }
}