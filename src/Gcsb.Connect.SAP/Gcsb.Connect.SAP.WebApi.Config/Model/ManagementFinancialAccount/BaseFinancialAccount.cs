using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.Model.ManagementFinancialAccount
{
    public abstract class BaseFinancialAccount<TDomain> where TDomain : class
    {
        [Required]
        [MaxLength(15)]
        public string FinancialAccount { get; protected set; }

        [Required]
        [MaxLength(15)]
        public string AccountingAccountCredit { get; protected set; }

        [Required]
        [MaxLength(15)]
        public string AccountingAccountDebit { get; protected set; }

        public abstract TDomain Map();

        protected BaseFinancialAccount(string financialAccount, string accountingAccountCredit, string accountingAccountDebit)
        {
            FinancialAccount = financialAccount;
            AccountingAccountCredit = accountingAccountCredit;
            AccountingAccountDebit = accountingAccountDebit;
        }
    }
}
