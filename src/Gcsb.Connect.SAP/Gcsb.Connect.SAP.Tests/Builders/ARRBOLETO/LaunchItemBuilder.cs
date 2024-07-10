using Gcsb.Connect.SAP.Domain.ARR;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.ARRBOLETO
{
    public class LaunchItemBuilder
    {
        public string TypeLine;
        public int? LineNumber;
        public DateTime LaunchDate;
        public string Type;
        public string FinancialAccount;
        public string Complement;
        public decimal LaunchValue;
        public string SecondComplement;
        public string AccountingEntry;
        public string AccountingAccount;

        public static LaunchItemBuilder New()
        {
            return new LaunchItemBuilder()
            {
                TypeLine = "D1",
                LineNumber = 0000000001,
                LaunchDate = Convert.ToDateTime("2019-01-01"),
                Type = "BCO001",
                FinancialAccount = "ARRECGEN000GW",
                Complement = "",
                LaunchValue = 1000.00m,
                SecondComplement = "",
                AccountingEntry = "C",
                AccountingAccount = "0000000001"
            };
        }

        public LaunchItemBuilder WithTypeLine(string typeLine)
        {
            TypeLine = typeLine;
            return this;
        }

        public LaunchItemBuilder WithLineNumber(int? lineNumber)
        {
            LineNumber = lineNumber;
            return this;
        }

        public LaunchItemBuilder WithLaunchDate(DateTime launchDate)
        {
            LaunchDate = launchDate;
            return this;
        }

        public LaunchItemBuilder WithType(string type)
        {
            Type = type;
            return this;
        }

        public LaunchItemBuilder WithFinancialAccount(string financialAccount)
        {
            FinancialAccount = financialAccount;
            return this;
        }

        public LaunchItemBuilder WithComplement(string complement)
        {
            Complement = complement;
            return this;
        }

        public LaunchItemBuilder WithLaunchValue(decimal launchValue)
        {
            LaunchValue = launchValue;
            return this;
        }

        public LaunchItemBuilder WithSecondComplement(string secondComplement)
        {
            SecondComplement = secondComplement;
            return this;
        }

        public LaunchItemBuilder WithAccountingEntry(string accountingEntry)
        {
            AccountingEntry = accountingEntry;
            return this;
        }

        public LaunchItemBuilder WithAccountingAccount(string accountingAccount)
        {
            AccountingAccount = accountingAccount;
            return this;
        }

        public LaunchItem Build()
            => new LaunchItem(LineNumber, LaunchDate, FinancialAccount, LaunchValue, SecondComplement, Type, Complement, AccountingEntry, AccountingAccount);
    }
}
