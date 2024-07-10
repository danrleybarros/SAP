using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.Model.InterestAndFineFinancialAccount
{
    public class BaseFinancialAccount
    {
        [MaxLength(15)]
        public string Credit { get; set; }
        [MaxLength(15)]
        public string Debit { get; set; }

        public BaseFinancialAccount(string credit, string debit)
        {
            Credit = credit;
            Debit = debit;
        }
    }
}
