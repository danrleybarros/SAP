using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Helper.Base;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Helper
{
    public class ChargeBackTotalUsed : ChargeBackDifferentCycle, IChargeBackStrategy
    {
        public ChargeBackTotalUsed(IJsdnRepository jsdnRepository) : base(jsdnRepository) { }

        public void Add(FATRequest request)
        {
            request.AddProcessingLog("ChargeBack getting TotalUsed lines");

            var chargeBack = base.GetChargeBackDifferentCycle(ChargeBackType.TotalUsed, request);

            if (chargeBack.Any())
                request.InterestAndFineCounterchargeChargebackServices.Add(ChargeBackType.TotalUsed, chargeBack);
        }
    }
}
