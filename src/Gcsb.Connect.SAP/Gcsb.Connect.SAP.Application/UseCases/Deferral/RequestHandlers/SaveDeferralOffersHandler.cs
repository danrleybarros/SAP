using System.Linq;
using Gcsb.Connect.SAP.Application.Repositories.Deferral;

namespace Gcsb.Connect.SAP.Application.UseCases.Deferral.RequestHandlers
{
    public class SaveDeferralOffersHandler : Handler
    {
        private IDeferralOfferWriteOnlyRepository repository;

        public SaveDeferralOffersHandler(IDeferralOfferWriteOnlyRepository repository)
        {
            this.repository = repository;
        }

        public override void ProcessRequest(DeferralRequest request)
        {
            request.AddProcessingLog("Save Deferral Offers");

            repository.Add(request.DeferralOffers.Where(w=> w.DeferralStatus == Domain.Deferral.DeferralStatus.New));
            repository.UpdateRange(request.DeferralOffers.Where(w => w.DeferralStatus == Domain.Deferral.DeferralStatus.InProgress));

            sucessor?.ProcessRequest(request);
        }
    }
}
