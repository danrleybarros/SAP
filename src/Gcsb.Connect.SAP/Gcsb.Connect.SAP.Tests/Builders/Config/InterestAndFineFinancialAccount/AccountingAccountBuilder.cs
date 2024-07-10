using Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.InterestAndFineFinancialAccount
{
    public class AccountingAccountBuilder
    {
        public string Credit;
        public string Debit;

        public static AccountingAccountBuilder New()
        => new AccountingAccountBuilder { Credit = "AccountCred", Debit = "AccountDeb" };

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
