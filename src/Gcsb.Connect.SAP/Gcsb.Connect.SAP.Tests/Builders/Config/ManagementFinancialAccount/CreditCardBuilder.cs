using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount
{
   public class CreditCardBuilder
    {       
        public string FinancialAccount;
        public AccountingAccount AccountingAccount;

        public static CreditCardBuilder New()
        {
            return new CreditCardBuilder
            {              
                FinancialAccount = "AAAAAAAAAAAAAAA",
                AccountingAccount = AccountingAccountBuilder.New().Build()
            };
        }      

        public CreditCardBuilder WithFinancialAccount(string financialaccount)
        {
            FinancialAccount = financialaccount;
            return this;
        }

        public CreditCardBuilder WithAccountingAccount(AccountingAccount accountingaccount)
        {
            AccountingAccount = accountingaccount;
            return this;
        }

        public CreditCard Build()
        => new CreditCard(FinancialAccount, AccountingAccount);
    }
}
