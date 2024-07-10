using System;
using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount
{
    public class CriticBuilder
    {     
        public string FinancialAccount;
        public AccountingAccount AccountingAccount;

        public static CriticBuilder New()
        {
            return new CriticBuilder
            {               
                FinancialAccount = "FinanAccount",
                AccountingAccount = AccountingAccountBuilder.New().Build()
            };
        }     

        public CriticBuilder WithFinancialAccount(string financialaccount)
        {
            FinancialAccount = financialaccount;
            return this;
        }

        public CriticBuilder WithAccountingAccount(AccountingAccount accountingaccount)
        {
            AccountingAccount = accountingaccount;
            return this;
        }
        
        public Critic Build()
        => new Critic(FinancialAccount, AccountingAccount);

    }
}
