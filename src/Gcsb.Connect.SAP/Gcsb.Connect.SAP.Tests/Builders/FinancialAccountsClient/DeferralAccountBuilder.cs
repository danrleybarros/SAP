using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount;

namespace Gcsb.Connect.SAP.Tests.Builders.FinancialAccountsClient
{
    public class DeferralAccountBuilder
    {
        public long Credit;
        public long Debit;

        public static DeferralAccountBuilder New()
        {
            return new DeferralAccountBuilder()
            {
                Credit = 1,
                Debit = 2
            };
        }       


        public DeferralAccountBuilder WithCredit(long credit)
        {
            Credit = credit;
            return this;
        }

        public DeferralAccountBuilder WithDebit(long debit)
        {
            Debit = debit;
            return this;
        }

        public DeferralAccount Build()
        => new DeferralAccount(Credit, Debit);
    }
}
