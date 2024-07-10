using System.Linq;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.SpecialRegime.RequestHandlers
{
    public class GetServicesHandler : Handler
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository;

        public GetServicesHandler(IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository)
        {
            this.serviceInvoiceReadOnlyRepository = serviceInvoiceReadOnlyRepository;
        }

        public override void ProcessRequest(SpecialRegimeRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Consulting data and grouping result - Special Regime"));
            var services = serviceInvoiceReadOnlyRepository.GetServices(request.FileIdBillFeed, "N");
            request.Services = services.Where(s => s.ServiceProviderCompanyName != "jcteststore").ToList();
            

            if (request.Services.Count == 0)
            {
                request.Logs.Add(Log.CreateProcessingLog(request.Service, "Not Found any services"));
                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
