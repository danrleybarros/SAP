using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomersConsumption.RequestHandlers
{
    public class GetInvoicesHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoicesHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(CustomersConsumptionRequest request)
        {
            request.Invoices = invoiceReadOnlyRepository
                .GetInvoices(i => request.InvoicesNumbers.Contains(i.InvoiceNumber));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}