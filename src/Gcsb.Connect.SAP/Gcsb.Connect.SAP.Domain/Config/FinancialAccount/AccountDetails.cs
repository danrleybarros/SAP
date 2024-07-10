using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.Config
{
    public class AccountDetails 
    {

        public Guid Id { get; private set; }
        public Guid IdService { get; private set; }
        public Guid IdInterface { get; private  set; }

        [Required]
        [MaxLength(15)]
        public string AccountType { get; private set; }
        
        [Required]
        [MaxLength(15)]
        public string FinancialAccount { get; private set; }
        [Required]
        [MaxLength(15)]
        public string FinancialAccountDeb { get; private set; }
        [Required]
        [MaxLength(15)]
        public string FinancialAccountCred { get; private set; }

        public AccountDetails(Guid id, Guid idService, Guid idInterface, string idAccountType, string financialAccount, string financialAccountDeb, string financialAccountCred)
        {
            Id = id;
            IdService = idService;
            IdInterface = idInterface;
            AccountType = idAccountType;
            FinancialAccount = financialAccount;
            FinancialAccountDeb = financialAccountDeb;
            FinancialAccountCred = financialAccountCred;
        }
    }
}
