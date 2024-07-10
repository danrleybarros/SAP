using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper.Base;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper
{
    public class ChargeBackDebtGranted : ChargeBackDifferentCycle, IChargeBackStrategy
    {
        public ChargeBackDebtGranted(IJsdnRepository jsdnRepository) : base(jsdnRepository) {  }

        public void Add(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("ChargeBack getting lines debt granted");

            var chargeBack = base.GetChargeBackDifferentCycle(ChargeBackType.DebtGranted, request);

            if (chargeBack.Any())
                request.CounterchargeChargeBack.Add(ChargeBackType.DebtGranted, chargeBack);
        }
    }
}
