using Gcsb.Connect.SAP.Domain.Critical;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.Critica
{
    public class LaunchBuilder
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

        public static LaunchBuilder New()
        {
            return new LaunchBuilder()
            {
                TypeLine = "D1",
                LineNumber = 0000000001,
                LaunchDate = Convert.ToDateTime("2019-01-01"),
                Type = "BCO001",
                FinancialAccount = "CRITICA000GW",
                Complement = "",
                LaunchValue = 1000.00m,
                SecondComplement = "",
                AccountingEntry = "C",
                AccountingAccount = "0000000001"
            };
        }

        public LaunchBuilder WithTypeLine(string typeLine)
        {
            TypeLine = typeLine;
            return this;
        }

        public LaunchBuilder WithLineNumber(int? lineNumber)
        {
            LineNumber = lineNumber;
            return this;
        }

        public LaunchBuilder WithLaunchDate(DateTime launchDate)
        {
            LaunchDate = launchDate;
            return this;
        }

        public LaunchBuilder WithType(string type)
        {
            Type = type;
            return this;
        }

        public LaunchBuilder WithFinancialAccount(string financialAccount)
        {
            FinancialAccount = financialAccount;
            return this;
        }

        public LaunchBuilder WithComplement(string complement)
        {
            Complement = complement;
            return this;
        }

        public LaunchBuilder WithLaunchValue(decimal launchValue)
        {
            LaunchValue = launchValue;
            return this;
        }

        public LaunchBuilder WithSecondComplement(string secondComplement)
        {
            SecondComplement = secondComplement;
            return this;
        }

        public LaunchBuilder WithAccountingEntry(string accountingEntry)
        {
            AccountingEntry = accountingEntry;
            return this;
        }

        public LaunchBuilder WithAccountingAccount(string accountingAccount)
        {
            AccountingAccount = accountingAccount;
            return this;
        }

        public LaunchCritical Build()
            => new LaunchCritical(LineNumber, LaunchDate, FinancialAccount, LaunchValue, SecondComplement, Type, Complement, AccountingEntry, AccountingAccount);
    }
}
