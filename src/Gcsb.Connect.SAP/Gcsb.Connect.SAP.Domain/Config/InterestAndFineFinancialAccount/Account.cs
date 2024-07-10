namespace Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount
{
    public class Account
    {
        public string FinancialAccount { get; private set; }
        public string BilledCounterchargeChargeback { get; private set; }
        public string GrantedDebit { get; private set; }
        public AccountingAccount InterestOrFine { get; private set; }
        public AccountingAccount UnpaidInvoice { get; private set; }
        public AccountingAccount PaidInvoice { get; private set; }
        public AccountingAccount CycleEstimate { get; private set; }
        public AccountingAccount ChargebackFutureCreditUnusedValue { get; set; }
        public AccountingAccount ChargebackFutureCreditUsedValue { get; set; }
        public AccountingAccount ChargebackRectifiedBoleto { get; set; }
        public AccountingAccount GrantedDebitAccounting { get; set; }

        public Account(string financialAccount, string billedCounterchargeChargeback,
            string grantedDebit, AccountingAccount interestOrFine,
            AccountingAccount unpaidInvoice, AccountingAccount paidInvoice,
            AccountingAccount cycleEstimate, AccountingAccount chargebackFutureCreditUnusedValue,
            AccountingAccount chargebackFutureCreditUsedValue, AccountingAccount chargebackRectifiedBoleto,
            AccountingAccount grantedDebitAccounting)
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
