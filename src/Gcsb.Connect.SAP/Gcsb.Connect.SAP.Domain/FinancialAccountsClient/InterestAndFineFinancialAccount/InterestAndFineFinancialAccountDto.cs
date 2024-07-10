using System;

namespace Gcsb.Connect.SAP.Domain.FinancialAccountsClient.InterestAndFineFinancialAccount
{
    public class InterestAndFineFinancialAccountDto
    {
        public Guid Id { get; set; }
        public FinancialAccount FinancialAccount { get; set; }
    }

    public class FinancialAccount
    {
        public string StoreAcronym { get; set; }
        public Account Interest { get; set; }
        public Account Fine { get; set; }
    }

    public class Account
    {
        public string FinancialAccount { get; set; }
        public string BilledCounterchargeChargeback { get; set; }
        public string GrantedDebit { get; set; }
        public AccountingAccount InterestOrFine { get; set; }
        public AccountingAccount UnpaidInvoice { get; set; }
        public AccountingAccount PaidInvoice { get; set; }
        public AccountingAccount CycleEstimate { get; set; }
        public AccountingAccount ChargebackFutureCreditUnusedValue { get; set; }
        public AccountingAccount ChargebackFutureCreditUsedValue { get; set; }
        public AccountingAccount ChargebackRectifiedBoleto { get; set; }
        public AccountingAccount GrantedDebitAccounting { get; set; }
    }

    public class AccountingAccount
    {
        public string Credit { get; set; }
        public string Debit { get; set; }
    }
}
