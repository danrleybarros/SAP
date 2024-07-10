
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.Model.ManagementFinancialAccount
{
    public class CreditCard : BaseFinancialAccount<Domain.Config.ManagementFinancialAccount.CreditCard>
    {     
        public override Domain.Config.ManagementFinancialAccount.CreditCard Map()
        => new Domain.Config.ManagementFinancialAccount.CreditCard(FinancialAccount,
           new Domain.Config.ManagementFinancialAccount.AccountingAccount(AccountingAccountCredit, AccountingAccountDebit));

        public CreditCard(string financialAccount, string accountingAccountCredit, string accountingAccountDebit) : base(financialAccount, accountingAccountCredit, accountingAccountDebit)
        {

        }
    }
}
