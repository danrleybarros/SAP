using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Helper
{
    public class ChargeBackRectifiedBoleto : IChargeBackStrategy
    {
        private string[] receivables = new string[] { "SPJURTBRAC", "SPMULTBRAC", "SPJURCLOUDCOC", "SPMULCLOUDCOC" };
        public void Add(FATRequest request)
        {
            request.AddProcessingLog("ChargeBack getting rectified boleto lines");

            var chargeBackTotalInvoiceNotPaid = new List<ServiceFilter>();
            var invoicesNotPaid = request.CounterchargeDisputes.Where(w => w.TransactionType == TransactionType.Payment && w.PaymentStatusType != PaymentStatusType.Pago).Select(s => s.NumeroFatura).ToList();
            var interestAndFineRectifiedBoletoInvoices = request.CounterchargeDisputes
                .Where(w => w.DisputeType.Equals(DisputeType.RectifiedBoleto) && receivables.Contains(w.AReceber) && invoicesNotPaid.Contains(w.NumeroFatura))
                .Select(w => w.NumeroFatura).Distinct().ToList();
            var rectifiedBoletoChargebackServices = request.CounterchargeChargebackServices.Where(s => interestAndFineRectifiedBoletoInvoices.Contains(s.Invoice.InvoiceNumber)).ToList();

            rectifiedBoletoChargebackServices.ForEach(f =>
            {
                var adjustment = request.CounterchargeDisputes.Find(w => w.TransactionType == TransactionType.Adjustment && w.NumeroFatura == f.Invoice.InvoiceNumber);

                if (adjustment != null)
                    chargeBackTotalInvoiceNotPaid.Add(f);
            });

            if (chargeBackTotalInvoiceNotPaid.Any())
                request.InterestAndFineCounterchargeChargebackServices.Add(ChargeBackType.RetifiedBoleto, chargeBackTotalInvoiceNotPaid);
        }
    }
}
