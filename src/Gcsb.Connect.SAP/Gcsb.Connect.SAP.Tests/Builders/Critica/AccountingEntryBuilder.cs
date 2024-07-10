using Gcsb.Connect.SAP.Domain.Critical;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Tests.Builders.Critica
{
    public class AccountingEntryBuilder
    {
        public string FinancialAccount;
        public string AccountingEntryType;
        public string AccountingAccount;

        public static AccountingEntryBuilder New()
        {
            return new AccountingEntryBuilder()
            {
                FinancialAccount = "FACritica",
                AccountingAccount = "Critica123",
                AccountingEntryType = "C"
            };
        }

        public AccountingEntryBuilder WithFinancialAccount(string financialAccount)
        {
            FinancialAccount = financialAccount;
            return this;
        }

        public AccountingEntryBuilder WithAccountingEntryType(string accountingEntryType)
        {
            AccountingEntryType = accountingEntryType;
            return this;
        }

        public AccountingEntryBuilder WithAccountingAccount(string accountingAccount)
        {
            AccountingAccount = accountingAccount;
            return this;
        }

        public AccountingEntry Build()
            => new AccountingEntry(FinancialAccount, AccountingEntryType, AccountingAccount);
    }
}
