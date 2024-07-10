using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomerInvoices.RequestHandlers
{
    public class GetInvoicesHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoicesHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(AllCustomerInvoicesRequest request)
        {
            var invoices = request.Customers.Select(s => s.InvoiceNumber).ToList();
            
            request.Invoices = invoiceReadOnlyRepository.GetInvoices(w => invoices.Contains(w.InvoiceNumber));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}