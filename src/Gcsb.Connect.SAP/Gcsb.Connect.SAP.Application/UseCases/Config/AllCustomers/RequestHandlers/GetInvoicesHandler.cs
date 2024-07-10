using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.RequestHandlers
{
    public class GetInvoicesHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoicesHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(AllCustomersRequest request)
        {
            var numbers = request.Customers.Select(s => s.InvoiceNumber).ToList();
            request.Invoices = invoiceReadOnlyRepository.GetInvoices(w => numbers.Contains(w.InvoiceNumber));

            sucessor?.ProcessRequest(request);
        }
    }
}
