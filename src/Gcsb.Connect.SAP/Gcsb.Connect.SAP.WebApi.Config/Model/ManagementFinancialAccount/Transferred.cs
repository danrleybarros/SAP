
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.Model.ManagementFinancialAccount
{ 
    public class Transferred : BaseFinancialAccount<Domain.Config.ManagementFinancialAccount.AccountingAccount>
    {       
        public override Domain.Config.ManagementFinancialAccount.AccountingAccount Map()
        => new Domain.Config.ManagementFinancialAccount.AccountingAccount(AccountingAccountCredit, AccountingAccountDebit);

        public Transferred(string financialAccount, string accountingAccountCredit, string accountingAccountDebit) : base(financialAccount, accountingAccountCredit, accountingAccountDebit)
        {

        }
    }
}
