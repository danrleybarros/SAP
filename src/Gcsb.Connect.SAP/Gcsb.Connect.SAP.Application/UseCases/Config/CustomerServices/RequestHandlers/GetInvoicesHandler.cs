using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices.RequestHandlers
{
    public class GetInvoicesHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoicesHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(CustomerServicesRequest request)
        {
            request.Logs.Add(new Log("CustomerServicesUseCase - GetInvoicesHandler", "Getting Invoice data for all services", TypeLog.Processing));
            var invoices = invoiceReadOnlyRepository.GetInvoices(i => request.InvoiceNumbers.Contains(i.InvoiceNumber));
            request.ServicesInvoices.ForEach(service => {
                service.Invoice = invoices.Find(i => i.InvoiceNumber.Equals(service.InvoiceNumber));
            });

            successor?.ProcessRequest(request);
        }
    }
}
