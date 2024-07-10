using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount.Base;
using System;

namespace Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount
{
    public class Boleto : BaseFinancialAccount
    {
        public Boleto(string financialAccount, AccountingAccount accountingAccount) : base(financialAccount, accountingAccount)
        {

        }
    }
}
