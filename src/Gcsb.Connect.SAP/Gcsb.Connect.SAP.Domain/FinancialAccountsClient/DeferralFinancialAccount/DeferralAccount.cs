using System.Runtime.CompilerServices;

namespace Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount
{
    public class DeferralAccount
    {
        public long Credit { get; private set; }
        public long Debit { get; private set; }

        public DeferralAccount()  { }

        public DeferralAccount(long credit, long debit)
        {
            Credit = credit;
            Debit = debit;
        }
    }
}
