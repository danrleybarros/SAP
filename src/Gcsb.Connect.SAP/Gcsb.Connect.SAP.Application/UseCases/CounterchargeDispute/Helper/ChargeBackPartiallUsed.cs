using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper.Base;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper
{
    public class ChargeBackPartiallUsed : ChargeBackDifferentCycle, IChargeBackStrategy
    {
        public ChargeBackPartiallUsed(IJsdnRepository jsdnRepository) : base(jsdnRepository)   {   }

        public void Add(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("ChargeBack getting lines partial total used");

            var chargeBack = base.GetChargeBackDifferentCycle(ChargeBackType.PartialUsed, request);

            if (chargeBack.Any())
                request.CounterchargeChargeBack.Add(ChargeBackType.PartialUsed, chargeBack);
        }
    }
}
