using System.Linq;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Application.Repositories.StatusActivationServices;
using Gcsb.Connect.SAP.Domain.Deferral.StatusActivationService;
using Gcsb.Connect.SAP.Domain.Deferral.StatusActivationService.Enum;

namespace Gcsb.Connect.SAP.Application.UseCases.Deferral.RequestHandlers
{
    public class ValidateRulesHandler : Handler
    {
        private readonly IStatusActivationServiceReadOnlyRepository statusActivationServiceReadOnlyRepository;
        private readonly IReturnNFReadOnlyRepository returnNFReadOnlyRepository;

        public ValidateRulesHandler(IStatusActivationServiceReadOnlyRepository repository, IReturnNFReadOnlyRepository returnNFReadOnlyRepository)
        {
            this.statusActivationServiceReadOnlyRepository = repository;
            this.returnNFReadOnlyRepository = returnNFReadOnlyRepository;
        }

        public override void ProcessRequest(DeferralRequest request)
        {
            request.AddProcessingLog("Validate if service is active and if NF was emitted");

            var nFs = returnNFReadOnlyRepository.GetReturnNF(request.DeferralOffers.Select(df => df.InvoiceNumber).Distinct().ToList());
            var servicesActivation = statusActivationServiceReadOnlyRepository.GetOffersByCode(request.DeferralOffers.Select(s => s.OfferCode).Distinct().ToArray());

            request.DeferralOffers.ForEach(o =>
            {
                var serviceActivation = servicesActivation.Where(w => w.OfferCode.Equals(o.OfferCode) && w.CustomerCode.Equals(o.CustomerCode.WithTenDigits()) && w.OrderNumber.Equals(o.OrderNumber)).FirstOrDefault();
                var nf = nFs.Where(nf => nf.InvoiceID == o.InvoiceNumber).FirstOrDefault();

                if (serviceActivation != null)
                {
                    o.SetExpirationDate(serviceActivation.ExpirationDate);
                    o.SetIsActive(serviceActivation.ActivationStatus == ActivationTypeEnum.Activated);
                }
                else
                    o.SetIsActive(true);

                if (nf != null)
                    o.SetIsNFEmitted(true);
            });

            sucessor?.ProcessRequest(request);
        }

    }
}
