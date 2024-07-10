using Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.InterestAndFineFinancialAccount
{
    public class AccountBuilder
    {
        public string FinancialAccount;
        public string BilledCounterchargeChargeback;
        public string GrantedDebit;
        public AccountingAccount InterestOrFine;
        public AccountingAccount UnpaidInvoice;
        public AccountingAccount PaidInvoice;
        public AccountingAccount CycleEstimate;
        public AccountingAccount ChargebackFutureCreditUnusedValue;
        public AccountingAccount ChargebackFutureCreditUsedValue;
        public AccountingAccount ChargebackRectifiedBoleto;
        public AccountingAccount GrantedDebitAccounting;

        public static AccountBuilder New()
        {
            return new AccountBuilder
            {
                FinancialAccount = "123456789",
                BilledCounterchargeChargeback = "Bill",
                GrantedDebit = "GrantedDebt",
                InterestOrFine = AccountingAccountBuilder.New().Build(),
                UnpaidInvoice = AccountingAccountBuilder.New().Build(),
                PaidInvoice = AccountingAccountBuilder.New().Build(),
                CycleEstimate = AccountingAccountBuilder.New().Build(),
                ChargebackFutureCreditUnusedValue = AccountingAccountBuilder.New().WithCredit("UnusedC").WithDebit("UnusedD").Build(),
                ChargebackFutureCreditUsedValue = AccountingAccountBuilder.New().WithCredit("UsedC").WithDebit("UsedD").Build(),
                ChargebackRectifiedBoleto = AccountingAccountBuilder.New().WithCredit("RectiC").WithDebit("RectiD").Build(),
                GrantedDebitAccounting = AccountingAccountBuilder.New().WithCredit("GrantedC").WithDebit("GrantedD").Build()
            };
        }

        public AccountBuilder WithFinancialAccount(string financialAccount)
        {
            FinancialAccount = financialAccount;
            return this;
        }


        public AccountBuilder WithBilledCounterchargeChargeback(string billedCounterchargeChargeback)
        {
            BilledCounterchargeChargeback = billedCounterchargeChargeback;
            return this;
        }

        public AccountBuilder WithGrantedDebit(string grantedDebit)
        {
            GrantedDebit = grantedDebit;
            return this;
        }

        public AccountBuilder WithInterestOrFine(AccountingAccount interestOrFine)
        {
            InterestOrFine = interestOrFine;
            return this;
        }

        public AccountBuilder WithUnpaidInvoice(AccountingAccount unpaidInvoice)
        {
            UnpaidInvoice = unpaidInvoice;
            return this;
        }

        public AccountBuilder WithPaidInvoice(AccountingAccount paidInvoice)
        {
            PaidInvoice = paidInvoice;
            return this;
        }

        public AccountBuilder WithCycleEstimate(AccountingAccount cycleEstimate)
        {
            CycleEstimate = cycleEstimate;
            return this;
        }

        public AccountBuilder WithChargebackFutureCreditUnusedValue(AccountingAccount chargebackFutureCreditUnusedValue)
        {
            ChargebackFutureCreditUnusedValue = chargebackFutureCreditUnusedValue;
            return this;
        }

        public AccountBuilder WithChargebackFutureCreditUsedValue(AccountingAccount chargebackFutureCreditUsedValue)
        {
            ChargebackFutureCreditUsedValue = chargebackFutureCreditUsedValue;
            return this;
        }

        public AccountBuilder WithChargebackRectifiedBoleto(AccountingAccount chargebackRectifiedBoleto)
        {
            ChargebackRectifiedBoleto = chargebackRectifiedBoleto;
            return this;
        }

        public AccountBuilder WithGrantedDebitAccounting(AccountingAccount grantedDebitAccounting)
        {
            GrantedDebitAccounting = grantedDebitAccounting;
            return this;
        }

        public Account Build()
            => new Account(FinancialAccount, BilledCounterchargeChargeback, GrantedDebit, InterestOrFine, UnpaidInvoice, PaidInvoice, CycleEstimate, ChargebackFutureCreditUnusedValue, ChargebackFutureCreditUsedValue, ChargebackRectifiedBoleto, GrantedDebitAccounting);
    }
}
