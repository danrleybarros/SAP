using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Helper.Base
{
    public abstract class ChargeBackDifferentCycle
    {
        private readonly IJsdnRepository jsdnRepository;
        private List<Domain.JSDN.ServiceFilter> CounterchargeChargeBacks { get; set; }
        private string[] activities = new string[] { "INTEREST", "FINES" };
        private string[] receivables = new string[] { "SPJURTBRAC", "SPMULTBRAC", "SPJURCLOUDCOC", "SPMULCLOUDCOC" };

        public ChargeBackDifferentCycle(IJsdnRepository jsdnRepository)
        {
            this.jsdnRepository = jsdnRepository;
            CounterchargeChargeBacks = new List<Domain.JSDN.ServiceFilter>();
        }

        public List<Domain.JSDN.ServiceFilter> GetChargeBackDifferentCycle(ChargeBackType type, FATRequest request)
        {
            request.AddProcessingLog("ChargeBack getting lines different cycle ");

            var invoicesAdjustment = request.CounterchargeDisputes.Where(w => w.TransactionType == TransactionType.Adjustment && activities.Contains(w.TipoAtividade.ToUpper())).Select(s => s.NumeroFatura).ToList();
            var interestAndFineChargebacks = request.CounterchargeChargebackServices.Where(w => receivables.Contains(w.Receivable) && !invoicesAdjustment.Contains(w.Invoice.InvoiceNumber)).ToList();
            var counterchargeDisputesInvoice = jsdnRepository.GetCounterchargeDisputeByInvoice(interestAndFineChargebacks.Select(s => s.Invoice.InvoiceNumber).ToList());
            var invoicesAdjustmentPaid = counterchargeDisputesInvoice.Where(w => w.TransactionType == TransactionType.Payment && w.PaymentStatusType == PaymentStatusType.Pago).ToList();

            invoicesAdjustmentPaid.ForEach(f =>
            {
                var adjustment = counterchargeDisputesInvoice.Find(w => w.TransactionType == TransactionType.Adjustment && w.NumeroFatura == f.NumeroFatura);
                var generateBilling = request.CounterchargeDisputes.Find(w => w.TransactionType == TransactionType.Billing && w.NumeroFatura == f.NumeroFatura);
                var chargeback = interestAndFineChargebacks?.Where(w => w.Invoice.InvoiceNumber.Equals(f.NumeroFatura)).ToList();

                if (chargeback != null)
                {
                    if (type == ChargeBackType.TotalUsed && generateBilling?.ValorContestado == adjustment.ValorContestado)
                        CounterchargeChargeBacks.AddRange(chargeback);

                    if (type == ChargeBackType.DebtGranted && generateBilling == null)
                        CounterchargeChargeBacks.AddRange(chargeback);
                }
            });

            return CounterchargeChargeBacks;
        }
    }
}
