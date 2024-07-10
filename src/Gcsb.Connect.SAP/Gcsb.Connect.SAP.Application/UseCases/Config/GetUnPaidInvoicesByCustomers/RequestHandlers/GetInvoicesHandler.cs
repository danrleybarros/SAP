using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetUnPaidInvoicesByCustomers.RequestHandlers
{
    public class GetInvoicesHandler : Handler<GetUnPaidInvoicesByCustomersRequest>
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoicesHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(GetUnPaidInvoicesByCustomersRequest request)
        {
            var invoices = request.Customers.Select(s => s.InvoiceNumber).ToList();

            request.Invoices = invoiceReadOnlyRepository.GetInvoices(a => invoices.Contains(a.InvoiceNumber));

            sucessor?.ProcessRequest(request);
        }
    }
}
