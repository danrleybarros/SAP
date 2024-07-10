using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount
{
    public class AccountingAccount
    {
        [Required]
        [MaxLength(15)]
        public string Credit { get; private set; }

        [Required]
        [MaxLength(15)]
        public string Debit { get; private set; }

        public AccountingAccount(string credit, string debit)
        {           
            Credit = credit;
            Debit = debit;
        }
    }
}
