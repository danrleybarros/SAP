using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount.Base
{
    public abstract class BaseFinancialAccount
    {           
        [Required]
        [MaxLength(15)]
        public string FinancialAccount { get;protected set; }

        [Required]
        public AccountingAccount AccountingAccount { get; protected set; }

        protected BaseFinancialAccount(string financialAccount, AccountingAccount accountingAccount)
        {          
            FinancialAccount = financialAccount;
            AccountingAccount = accountingAccount;
        }
    }
}
