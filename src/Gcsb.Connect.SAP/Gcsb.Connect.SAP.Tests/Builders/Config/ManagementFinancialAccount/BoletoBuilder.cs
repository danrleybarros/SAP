using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount
{
    public class BoletoBuilder
    {      
        public string FinancialAccount;
        public AccountingAccount AccountingAccount;

        public static BoletoBuilder New()
        {
            return new BoletoBuilder
            {               
                FinancialAccount = "AAAAAAAAAAAAAAA",
                AccountingAccount = AccountingAccountBuilder.New().Build()
            };
        }      

        public BoletoBuilder WithFinancialAccount(string financialaccount)
        {
            FinancialAccount = financialaccount;
            return this;
        }

        public BoletoBuilder WithAccountingAccount(AccountingAccount accountingaccount)
        {
            AccountingAccount = accountingaccount;
            return this;
        }

        public Boleto Build()
        => new Boleto(FinancialAccount, AccountingAccount);
    }
}
