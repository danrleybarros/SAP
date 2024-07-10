using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount
{
    public class AccountingAccount
    {
        [MaxLength(15)]
        public string Credit { get; private set; }

        [MaxLength(15)]
        public string Debit { get; private set; }

        public AccountingAccount(string credit, string debit)
        {
            Credit = credit;
            Debit = debit;
        }
    }
}
