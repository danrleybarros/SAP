using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices.RequestHandlers
{
    public class GetServicesInvoicesHandler : Handler
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository;

        public GetServicesInvoicesHandler(IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository)
        {
            this.serviceInvoiceReadOnlyRepository = serviceInvoiceReadOnlyRepository;
        }

        public override void ProcessRequest(CustomerServicesRequest request)
        {
            request.Logs.Add(new Log("CustomerServicesUseCase - GetServicesInvoicesHandler", "Getting a list of services by invoice number", TypeLog.Processing));
            request.ServicesInvoices.AddRange(serviceInvoiceReadOnlyRepository.GetServices(w => request.InvoiceNumbers.Contains(w.InvoiceNumber)));

            successor?.ProcessRequest(request);
        }
    }
}
