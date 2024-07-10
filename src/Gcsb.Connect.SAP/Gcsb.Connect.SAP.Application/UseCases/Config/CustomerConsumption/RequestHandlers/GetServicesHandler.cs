using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption.RequestHandlers
{
    public class GetServicesHandler : Handler
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository;

        public GetServicesHandler(IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository)
        {
            this.serviceInvoiceReadOnlyRepository = serviceInvoiceReadOnlyRepository;
        }

        public override void ProcessRequest(CustomerConsumptionRequest request)
        {
            var invoices = request.Customers.Select(s => s.InvoiceNumber).ToList();

            request.Services = serviceInvoiceReadOnlyRepository.GetServices(w => invoices.Contains(w.InvoiceNumber));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
