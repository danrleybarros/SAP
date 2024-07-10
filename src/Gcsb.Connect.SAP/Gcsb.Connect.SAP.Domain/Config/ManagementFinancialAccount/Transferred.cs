using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount.Base;
using System;

namespace Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount
{
    public class Transferred : BaseFinancialAccount
    {   
        public Transferred(string financialAccount, AccountingAccount accountingAccount) : base (financialAccount, accountingAccount)
        {
           
        }
    }    
}
