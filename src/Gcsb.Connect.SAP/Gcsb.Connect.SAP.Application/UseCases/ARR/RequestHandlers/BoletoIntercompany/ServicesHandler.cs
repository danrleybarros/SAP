using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.ARRBoletoIntercompany;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.BoletoIntercompany
{
    public class ServicesHandler : Handler<ARRBoletoInter>, IServicesHandler<ARRBoletoInter>
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository;

        public ServicesHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository)
        {
            this.serviceReadOnlyRepository = serviceReadOnlyRepository;
        }

        public override void ProcessRequest(IARRRequest<ARRBoletoInter> request)
        {
            request.AddProcessingLog("Consulting Services - ARR Boleto Intercompany");
            request.Services = serviceReadOnlyRepository.GetPaidServicesBankSlip(request.IDPaymentFeed).ToList();

            sucessor?.ProcessRequest(request);
        }
    }
}
