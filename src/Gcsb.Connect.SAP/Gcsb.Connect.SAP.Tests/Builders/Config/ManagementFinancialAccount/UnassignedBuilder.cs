using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount
{
    public class UnassignedBuilder
    {
        public string FinancialAccount;
        public AccountingAccount AccountingAccount;

        public static UnassignedBuilder New()
        {
            return new UnassignedBuilder
            {            
                FinancialAccount = "Unassigned",
                AccountingAccount = AccountingAccountBuilder.New().Build()
            };
        }       

        public UnassignedBuilder WithFinancialAccount(string financialaccount)
        {
            FinancialAccount = financialaccount;
            return this;
        }

        public UnassignedBuilder WithAccountingAccount(AccountingAccount accountingaccount)
        {
            AccountingAccount = accountingaccount;
            return this;
        }

        public Unassigned Build()
        => new Unassigned(FinancialAccount, AccountingAccount);
             
    }
}
