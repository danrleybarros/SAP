using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper.Base;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper
{
    public class ChargeBackTotalUsed : ChargeBackDifferentCycle, IChargeBackStrategy
    {
        public ChargeBackTotalUsed(IJsdnRepository jsdnRepository) : base(jsdnRepository) { }

        public void Add(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("ChargeBack getting lines TotalUsed  cycle ");

            var chargeBack = base.GetChargeBackDifferentCycle(ChargeBackType.TotalUsed, request);

            if (chargeBack.Any())
                request.CounterchargeChargeBack.Add(ChargeBackType.TotalUsed, chargeBack); 
       
        }
    }
}
