using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount
{
    public class TransferBuilder
    {        
        public string FinancialAccount;
        public AccountingAccount AccountingAccount;

        public static TransferBuilder New()
        {
            return new TransferBuilder
            {              
                FinancialAccount = "AAAAAAAAAAAAAAA",
                AccountingAccount = AccountingAccountBuilder.New().Build()
            };
        }
      
        public TransferBuilder WithFinancialAccount(string financialaccount)
        {
            FinancialAccount = financialaccount;
            return this;
        }

        public TransferBuilder WithAccountingAccount(AccountingAccount accountingaccount)
        {
            AccountingAccount = accountingaccount;
            return this;
        }

        public Transferred Build()
        => new Transferred(FinancialAccount, AccountingAccount);

    }
}
