using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Helper
{
    public class ChargeBackTotalNotUsed : IChargeBackStrategy
    {
        private string[] receivables = new string[] { "SPJURTBRAC", "SPMULTBRAC", "SPJURCLOUDCOC", "SPMULCLOUDCOC" };

        public void Add(FATRequest request)
        {
            request.AddProcessingLog("ChargeBack getting same cycle lines");

            var chargeBackTotalNotUsed = new List<ServiceFilter>();
            var invoicesAdjustment = request.CounterchargeDisputes.Where(w => w.TransactionType == TransactionType.Adjustment).ToList();
            var interestAndFineChargebacks = request.CounterchargeChargebackServices.Where(w => receivables.Contains(w.Receivable) && invoicesAdjustment.Select(s => s.NumeroFatura).Contains(w.Invoice.InvoiceNumber)).ToList();
            var counterchargeDisputesInvoice = request.CounterchargeDisputes.Where(w => receivables.Contains(w.AReceber) && w.TransactionType == TransactionType.AdjustReversal && w.DisputeType == DisputeType.FutureAccount && invoicesAdjustment.Select(s => s.NumeroFatura).Contains(w.NumeroFatura)).ToList();
            var invoicesAdjustmentPaid = request.CounterchargeDisputes.Where(w => w.TransactionType == TransactionType.Payment && w.PaymentStatusType == PaymentStatusType.Pago && counterchargeDisputesInvoice.Select(s => s.NumeroFatura).Contains(w.NumeroFatura)).ToList();

            invoicesAdjustmentPaid.ForEach(f =>
            {
                var adjustment = invoicesAdjustment.Find(w => w.NumeroFatura == f.NumeroFatura);

                var generateBilling = request.CounterchargeDisputes
                    .Where(w => w.TransactionType == TransactionType.Billing
                    && w.NumeroFatura == f.NumeroFatura
                    && w.ValorContestado.HasValue
                    && w.ValorContestado == (adjustment?.ValorContestado ?? 0));

                var chargeback = interestAndFineChargebacks.Where(w => w.Invoice.InvoiceNumber.Equals(f.NumeroFatura)).ToList();

                if (!generateBilling.Any() && chargeback != null)
                {
                    chargeBackTotalNotUsed.AddRange(chargeback);
                }

            });

            if (chargeBackTotalNotUsed.Any())
                request.InterestAndFineCounterchargeChargebackServices.Add(ChargeBackType.TotalNotUsed, chargeBackTotalNotUsed);
        }
    }
}
