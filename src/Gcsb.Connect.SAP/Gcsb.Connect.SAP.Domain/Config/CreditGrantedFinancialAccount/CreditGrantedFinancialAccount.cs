using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.Config.CreditGrantedFinancialAccount
{
    public class CreditGrantedFinancialAccount
    {
        public Guid? Id { get; set; }
        public StoreType StoreAcronym { get; private set; }
        [Required]
        [MaxLength(15)]
        public string CreditGrantedAJU { get; private set; }
        [Required]
        [MaxLength(15)]
        public string AccountingAccountDeb { get; private set; }
        [Required]
        [MaxLength(15)]
        public string AccountingAccountCred { get; private set; }

        public CreditGrantedFinancialAccount(Guid? id, StoreType storeAcronym, string creditGrantedAJU, string accountingAccountDeb, string accountingAccountCred)
        {
            Id = id;
            StoreAcronym = storeAcronym;
            CreditGrantedAJU = creditGrantedAJU;
            AccountingAccountDeb = accountingAccountDeb;
            AccountingAccountCred = accountingAccountCred;
        }
    }
}
