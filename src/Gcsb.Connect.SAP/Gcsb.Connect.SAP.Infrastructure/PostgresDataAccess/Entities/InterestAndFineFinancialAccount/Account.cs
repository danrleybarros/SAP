using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.InterestAndFineFinancialAccount
{
    public class Account
    {
        public string FinancialAccount { get; set; }
        public string BilledCounterchargeChargeback { get; private set; }
        public string GrantedDebit { get; private set; }
        public AccountingAccount InterestOrFine { get; set; }
        public AccountingAccount UnpaidInvoice { get; set; }
        public AccountingAccount PaidInvoice { get; set; }
        public AccountingAccount CycleEstimate { get; set; }
        public AccountingAccount ChargebackFutureCreditUnusedValue { get; set; }
        public AccountingAccount ChargebackFutureCreditUsedValue { get; set; }
        public AccountingAccount ChargebackRectifiedBoleto { get; set; }
        public AccountingAccount GrantedDebitAccounting { get; set; }
    }
}
