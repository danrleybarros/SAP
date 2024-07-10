using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InvoiceDetails.RequestHandlers
{
    public class GetServicesHandler : Handler
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository;

        public GetServicesHandler(IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository)
        {
            this.serviceInvoiceReadOnlyRepository = serviceInvoiceReadOnlyRepository;
        }

        public override void ProcessRequest(InvoiceDetailsRequest request)
        {
            request.Services = serviceInvoiceReadOnlyRepository
                .GetServices(w => request.InvoiceNumbers.Contains(w.InvoiceNumber));

            sucessor?.ProcessRequest(request);
        }
    }
}
