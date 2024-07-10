using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper
{
    public class ChargeBackTotalNotUsed : IChargeBackStrategy
    {
        private string[] ignoreReceivables = new string[] { "SPJURTBRAC", "SPMULTBRAC", "SPJURCLOUDCOC", "SPMULCLOUDCOC" };

        public void Add(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("ChargeBack getting lines same cycle ");

            var ChargeBackTotalNotUsed = new List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute>();
            var InvoicesAdjustment = request.CounterchargeDisputes.Where(w=> w.TransactionType == TransactionType.Adjustment && !ignoreReceivables.Contains(w.AReceber)).ToList();
            var chargeBackSameCycle = request.CounterchargeDisputes.Where(w => w.TransactionType == TransactionType.AdjustReversal && w.DisputeType == DisputeType.FutureAccount && InvoicesAdjustment.Select(s => s.NumeroFatura).Contains(w.NumeroFatura) && !ignoreReceivables.Contains(w.AReceber)).ToList();
            var invoicesAdjustmentPaid = request.CounterchargeDisputes.Where(w => w.TransactionType == TransactionType.Payment && w.PaymentStatusType == PaymentStatusType.Pago && chargeBackSameCycle.Select(s => s.NumeroFatura).Contains(w.NumeroFatura) && !ignoreReceivables.Contains(w.AReceber)).ToList();

            invoicesAdjustmentPaid.ForEach(f =>
            {
                var adjustment = InvoicesAdjustment.Find(w => w.NumeroFatura == f.NumeroFatura);
                var generateBilling = request.CounterchargeDisputes
                    .Where(w => w.TransactionType == TransactionType.Billing
                    && w.NumeroFatura == f.NumeroFatura
                    && w.ValorContestado.HasValue
                    && w.ValorContestado == adjustment.ValorContestado);

                if (!generateBilling.Any())
                {
                    var chargeBack = chargeBackSameCycle.Find(f => f.NumeroFatura == f.NumeroFatura);                  
                    chargeBack.SetContestValue(adjustment.ValorContestado.Value);
                    ChargeBackTotalNotUsed.Add(chargeBack);
                }
            });

            if (ChargeBackTotalNotUsed.Any())             
                request.CounterchargeChargeBack.Add(ChargeBackType.TotalNotUsed, ChargeBackTotalNotUsed);
                    
        }
    }
}
