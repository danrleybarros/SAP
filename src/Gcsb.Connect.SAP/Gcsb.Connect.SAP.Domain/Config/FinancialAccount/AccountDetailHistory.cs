using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.Config
{
    public class AccountDetailHistory
    {
      
        public Guid Id { get; set; }
        public Guid IdService { get; set; }
        public Guid IdInterface { get; set; }
        public Guid IdAccountType { get; private set; }
        
        [Required]
        [MaxLength(15)]
        public string FinancialAccount { get; private set; }
        
        [Required]
        [MaxLength(15)]
        public string AccountDebit { get; private set; }

        [Required]
        [MaxLength(15)]
        public string AccountCredit { get; private set; }

        [Required]
        public DateTime InclusionDate { get; private set; }
        
        [Required]
        public DateTime LastUpdate { get; private set; }
        
        [Required]
        public bool IsDeleted { get; private set; }

        public AccountDetailHistory(Guid id, Guid idService, Guid idInterface, Guid idAccountType, string financialAccount, string accountDebit, string accountCredit, DateTime inclusionDate, DateTime lastUpdate, bool isDeleted)
        {
            Id = id;
            IdService = idService;
            IdInterface = idInterface;
            IdAccountType = idAccountType;
            FinancialAccount = financialAccount;
            AccountDebit = accountDebit;
            AccountCredit = accountCredit;
            InclusionDate = inclusionDate;
            LastUpdate = lastUpdate;
            IsDeleted = isDeleted;
        }

    }
}
