using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.Messaging.Messages.Log;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Client.RequestHandlers
{
    public class GetCustomersHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetCustomersHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(ClientChainRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Getting customers from return file NF"));

            var invoices = invoiceReadOnlyRepository.GetInvoicesFromIdFileReturnNF(request.IdFile);

            invoices.ForEach(f => f.Customer.SetInvoice(f));

            request.Customers = invoices
               .GroupBy(g => new { g.Customer.CustomerCNPJ, g.StoreAcronym })
               .Select(s => s.Where(f => f.StoreAcronym.Equals(s.Key.StoreAcronym))
               .Select(s => s.Customer).FirstOrDefault())
               .ToList();

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
