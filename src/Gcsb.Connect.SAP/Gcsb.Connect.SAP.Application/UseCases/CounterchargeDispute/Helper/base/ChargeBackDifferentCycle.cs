using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper.Base
{
    public abstract class ChargeBackDifferentCycle
    {
        private readonly IJsdnRepository jsdnRepository;
        private List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute> CounterchargeChargeBacks { get; set; }
        private string[] ignoreReceivables = new string[] { "SPJURTBRAC", "SPMULTBRAC", "SPJURCLOUDCOC", "SPMULCLOUDCOC" };
        public ChargeBackDifferentCycle(IJsdnRepository jsdnRepository)
        {
            this.jsdnRepository = jsdnRepository;
            CounterchargeChargeBacks = new List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute>();

        }

        public List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute> GetChargeBackDifferentCycle(ChargeBackType type, CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("ChargeBack getting lines different cycle ");

            var InvoicesAdjustment = request.CounterchargeDisputes.Where(w => w.TransactionType == TransactionType.Adjustment && !ignoreReceivables.Contains(w.AReceber)).Select(s => s.NumeroFatura).ToList();
            var adjustReversal = request.CounterchargeDisputes.Where(w => w.TransactionType == TransactionType.AdjustReversal && w.DisputeType == DisputeType.FutureAccount && !InvoicesAdjustment.Contains(w.NumeroFatura)&& !ignoreReceivables.Contains(w.AReceber)).ToList();
            var counterchargeDisputesInvoice = jsdnRepository.GetCounterchargeDisputeByInvoice(adjustReversal.Select(s => s.NumeroFatura).ToList());
            var invoicesAdjustmentPaid = counterchargeDisputesInvoice.Where(w => w.TransactionType == TransactionType.Payment && w.PaymentStatusType == PaymentStatusType.Pago && !ignoreReceivables.Contains(w.AReceber)).ToList();

            invoicesAdjustmentPaid.ForEach(f =>
            {
                var adjustment = counterchargeDisputesInvoice.Find(w => w.TransactionType == TransactionType.Adjustment && w.NumeroFatura == f.NumeroFatura);
                var generateBilling = request.CounterchargeDisputes.Find(w => w.TransactionType == TransactionType.Billing && w.NumeroFatura == f.NumeroFatura);
                var chargeBack = adjustReversal.Find(w => w.NumeroFatura == f.NumeroFatura);
                var contestedValue = generateBilling?.ValorContestado ?? adjustment?.ValorContestado;
                chargeBack.SetContestValue(contestedValue);  
              
                if (type == ChargeBackType.TotalUsed && generateBilling?.ValorContestado == adjustment.ValorContestado)
                    CounterchargeChargeBacks.Add(chargeBack);

                if (type == ChargeBackType.PartialUsed &&  generateBilling?.ValorContestado < adjustment.ValorContestado)
                    CounterchargeChargeBacks.Add(chargeBack);

                if (type == ChargeBackType.DebtGranted && generateBilling == null)
                    CounterchargeChargeBacks.Add(chargeBack);

            });

            return CounterchargeChargeBacks;
        }
      
    }
}