using Gcsb.Connect.SAP.Application.UseCases.Deferral;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.ReturnNF.ReturnNFHandlers
{
    public class ExecuteDeferralHandler : Handler
    {
        private readonly IDeferralUseCase deferralUseCase;

        public ExecuteDeferralHandler(IDeferralUseCase deferralUseCase)
        {
            this.deferralUseCase = deferralUseCase;
        }

        public override void ProcessRequest(ReturnNFRequest request)
        {
            var requestDeferral = new DeferralRequest(request.BillfeedId);

            deferralUseCase.Execute(requestDeferral);

            request.DeferralOffers = requestDeferral.DeferralOffers;

            sucessor?.ProcessRequest(request);
        }
    }
}
