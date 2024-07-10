using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount
{
    public class AccountingAccountBuilder
    {
        public string Credit;
        public string Debit;

        public static AccountingAccountBuilder New()
        => new AccountingAccountBuilder { Credit = "Cred0000", Debit = "Deb0000" };             

        public AccountingAccountBuilder WithCredit(string credit)
        {
            Credit = credit;
            return this;
        }

        public AccountingAccountBuilder WithDebit(string debit)
        {
            Debit = debit;
            return this;
        }

        public AccountingAccount Build()
         => new AccountingAccount(Credit, Debit);
    }
}
