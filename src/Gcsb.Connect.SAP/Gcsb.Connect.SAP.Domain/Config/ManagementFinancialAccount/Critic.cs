using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount.Base;
using System;

namespace Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount
{
    public class Critic : BaseFinancialAccount
    {
        public Critic(string financialAccount, AccountingAccount accountingAccount) : base(financialAccount, accountingAccount)
        {

        }
    }
}
