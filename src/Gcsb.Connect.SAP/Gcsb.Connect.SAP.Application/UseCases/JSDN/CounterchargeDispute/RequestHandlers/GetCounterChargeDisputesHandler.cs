using Gcsb.Connect.SAP.Application.Repositories.JSDN;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDispute.RequestHandlers
{
    public class GetCounterChargeDisputesHandler : Handler
    {
        private readonly IJsdnRepository jsdnRepository;

        public GetCounterChargeDisputesHandler(IJsdnRepository jsdnRepository)
        {
            this.jsdnRepository = jsdnRepository;
        }

        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.CounterchargeDisputes.AddRange(jsdnRepository.GetAllCounterchargeDispute(request.DateFrom, request.DateTo));
            request.CounterchargeDisputes.AddRange(jsdnRepository.GetAllCounterchargeDisputeBilling(request.DateFrom, request.DateTo));

            sucessor?.ProcessRequest(request);
        }
    }
}
