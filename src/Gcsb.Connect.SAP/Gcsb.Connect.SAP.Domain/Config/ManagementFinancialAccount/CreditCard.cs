using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount.Base;
using System;

namespace Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount
{
    public class CreditCard : BaseFinancialAccount
    {
        public CreditCard(string financialAccount, AccountingAccount accountingAccount) : base(financialAccount, accountingAccount)
        {

        }
    }
}
