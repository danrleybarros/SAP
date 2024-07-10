using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount.Base;
using System;


namespace Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount
{
   public class Unassigned : BaseFinancialAccount
    {
        public Unassigned(string financialAccount, AccountingAccount accountingAccount) : base(financialAccount, accountingAccount)
        {

        }
    }
}
