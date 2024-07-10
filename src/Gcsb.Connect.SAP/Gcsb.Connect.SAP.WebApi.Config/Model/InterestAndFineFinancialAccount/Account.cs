using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.Model.InterestAndFineFinancialAccount
{
    public class Account
    {
        [MaxLength(15)]
        public string FinancialAccount { get; set; }
        public string BilledCounterchargeChargeback { get; set; }
        public string GrantedDebit { get; set; }
        public BaseFinancialAccount InterestOrFine { get; set; }
        public BaseFinancialAccount UnpaidInvoice { get; set; }
        public BaseFinancialAccount PaidInvoice { get; set; }
        public BaseFinancialAccount CycleEstimate { get; set; }
        public BaseFinancialAccount ChargebackFutureCreditUnusedValue { get; set; }
        public BaseFinancialAccount ChargebackFutureCreditUsedValue { get; set; }
        public BaseFinancialAccount ChargebackRectifiedBoleto { get; set; }
        public BaseFinancialAccount GrantedDebitAccounting { get; set; }

        public Account(string financialAccount, 
            string billedCounterchargeChargeback,
            string grantedDebit,
            BaseFinancialAccount interestOrFine, 
            BaseFinancialAccount unpaidInvoice, 
            BaseFinancialAccount paidInvoice, 
            BaseFinancialAccount cycleEstimate,
            BaseFinancialAccount chargebackFutureCreditUnusedValue,
            BaseFinancialAccount chargebackFutureCreditUsedValue,
            BaseFinancialAccount chargebackRectifiedBoleto,
            BaseFinancialAccount grantedDebitAccounting
            )
        {
            FinancialAccount = financialAccount;
            InterestOrFine = interestOrFine;
            UnpaidInvoice = unpaidInvoice;
            PaidInvoice = paidInvoice;
            CycleEstimate = cycleEstimate;
            BilledCounterchargeChargeback = billedCounterchargeChargeback;
            GrantedDebit = grantedDebit;
            ChargebackFutureCreditUnusedValue = chargebackFutureCreditUnusedValue;
            ChargebackFutureCreditUsedValue = chargebackFutureCreditUsedValue;
            ChargebackRectifiedBoleto = chargebackRectifiedBoleto;
            GrantedDebitAccounting = grantedDebitAccounting;
        }
    }
}
