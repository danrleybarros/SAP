using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.Critical
{
    public class AccountingEntry
    {
        [Required]
        [MaxLength(15)]
        public string FinancialAccount { get; private set; }

        [Required]
        [MaxLength(2)]
        public string AccountingEntryType { get; private set; }

        [Required]
        [MaxLength(10)]
        public string AccountingAccount { get; private set; }

        public AccountingEntry(string financialAccount, string accountingEntryType, string accountingAccount)
        {
            FinancialAccount = financialAccount;
            AccountingEntryType = accountingEntryType;
            AccountingAccount = accountingAccount;
        }
    }
}
