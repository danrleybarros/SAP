using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount
{
    public class TransferredBuilder
    {        
        public string FinancialAccount;
        public AccountingAccount AccountingAccount;

        public static TransferredBuilder New()
        {
            return new TransferredBuilder
            {              
                FinancialAccount = "AAAAAAAAAAAAAAA",
                AccountingAccount = AccountingAccountBuilder.New().Build()
            };
        }
      
        public TransferredBuilder WithFinancialAccount(string financialaccount)
        {
            FinancialAccount = financialaccount;
            return this;
        }

        public TransferredBuilder WithAccountingAccount(AccountingAccount accountingaccount)
        {
            AccountingAccount = accountingaccount;
            return this;
        }

        public Transferred Build()
        => new Transferred(FinancialAccount, AccountingAccount);

    }
}
