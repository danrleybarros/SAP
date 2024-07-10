using Gcsb.Connect.SAP.Application.Repositories.JSDN;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class CounterchargeDisputeAdjustmentHandler : Handler
    {
        private readonly IJsdnRepository jsdnRepository;

        public CounterchargeDisputeAdjustmentHandler(IJsdnRepository jsdnRepository)
        {
            this.jsdnRepository = jsdnRepository;
        }

        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Consulting CounterchargeDispute - Adjustment");

            request.CounterchargeDisputesAdjustment.AddRange(jsdnRepository.GetAllCounterchargeDispute(request.DateFrom, request.DateTo));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
