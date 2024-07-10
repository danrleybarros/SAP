using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.Boleto;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.Boleto
{
    public class ServicesHandler : Handler<ARRBoleto>, IServicesHandler<ARRBoleto>
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository;

        public ServicesHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository)
        {
            this.serviceReadOnlyRepository = serviceReadOnlyRepository;
        }

        public override void ProcessRequest(IARRRequest<ARRBoleto> request)
        {
            request.AddProcessingLog("Consulting Services - ARR Boleto");
            request.Services = serviceReadOnlyRepository.GetPaidServicesBankSlip(request.IDPaymentFeed).ToList();

            sucessor?.ProcessRequest(request);
        }
    }
}
