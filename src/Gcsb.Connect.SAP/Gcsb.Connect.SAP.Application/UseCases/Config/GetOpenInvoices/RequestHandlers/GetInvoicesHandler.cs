using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices.RequestHandlers
{
    public class GetInvoicesHandler : Handler<GetOpenInvoicesRequest>
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoicesHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(GetOpenInvoicesRequest request)
        {
            var invoices = request.Customers.Select(s => s.InvoiceNumber).ToList();

            request.Invoices = invoiceReadOnlyRepository.GetInvoices(a => invoices.Contains(a.InvoiceNumber));

            sucessor?.ProcessRequest(request);
        }
    }
}
