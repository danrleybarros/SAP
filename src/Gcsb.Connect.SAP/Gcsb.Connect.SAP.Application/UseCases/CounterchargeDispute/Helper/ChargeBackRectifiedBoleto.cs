using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper
{
    public class ChargeBackRectifiedBoleto : IChargeBackStrategy
    {
        private string[] ignoreReceivables = new string[] { "SPJURTBRAC", "SPMULTBRAC", "SPJURCLOUDCOC", "SPMULCLOUDCOC" };

        public void Add(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("ChargeBack getting lines rectified boleto");

            var ChargeBackTotalInvoiceNotPaid = new List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute>();
            var invoicesNotPaid = request.CounterchargeDisputes.Where(w => w.TransactionType == TransactionType.Payment && w.PaymentStatusType != PaymentStatusType.Pago && !ignoreReceivables.Contains(w.AReceber)).Select(s=> s.NumeroFatura).ToList();
            var chargeBackRectifiedBoleto = request.CounterchargeDisputes.Where(w => w.TransactionType == TransactionType.AdjustReversal  &&  w.DisputeType == DisputeType.RectifiedBoleto && invoicesNotPaid.Contains(w.NumeroFatura) && !ignoreReceivables.Contains(w.AReceber)).ToList();

            chargeBackRectifiedBoleto.ForEach(f =>
            {
                var adjustment = request.CounterchargeDisputes.Find(w => w.TransactionType == TransactionType.Adjustment &&  w.NumeroFatura == f.NumeroFatura);

                if (adjustment != null)
                {
                    var rectifiedBoleto = chargeBackRectifiedBoleto.Find(w => w.NumeroFatura == f.NumeroFatura);
                    rectifiedBoleto.SetContestValue(adjustment.ValorContestado.Value);
                    ChargeBackTotalInvoiceNotPaid.Add(rectifiedBoleto);
                }
            });

            if (ChargeBackTotalInvoiceNotPaid.Any())
                request.CounterchargeChargeBack.Add(ChargeBackType.RetifiedBoleto, ChargeBackTotalInvoiceNotPaid);
                     
        }
    }
}
