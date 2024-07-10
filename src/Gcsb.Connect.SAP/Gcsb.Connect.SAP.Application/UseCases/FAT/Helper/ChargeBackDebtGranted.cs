using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Helper.Base;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Helper
{
    public class ChargeBackDebtGranted : ChargeBackDifferentCycle, IChargeBackStrategy
    {
        public ChargeBackDebtGranted(IJsdnRepository jsdnRepository) : base(jsdnRepository) { }

        public void Add(FATRequest request)
        {
            request.AddProcessingLog("ChargeBack getting debt granted lines");

            var chargeBack = base.GetChargeBackDifferentCycle(ChargeBackType.DebtGranted, request);

            if (chargeBack.Any())
                request.InterestAndFineCounterchargeChargebackServices.Add(ChargeBackType.DebtGranted, chargeBack);
        }
    }
}
