
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.Model.ManagementFinancialAccount
{
    public class Boleto : BaseFinancialAccount<Domain.Config.ManagementFinancialAccount.Boleto>
    {      
        public override Domain.Config.ManagementFinancialAccount.Boleto Map()
        => new Domain.Config.ManagementFinancialAccount.Boleto(FinancialAccount,
           new Domain.Config.ManagementFinancialAccount.AccountingAccount(AccountingAccountCredit, AccountingAccountDebit));

        public Boleto(string financialAccount, string accountingAccountCredit, string accountingAccountDebit) : base(financialAccount, accountingAccountCredit, accountingAccountDebit)
        {

        }

    }
}
