using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.CreditGrantedFinancialAccount
{
    public class CreditGrantedFinancialAccountBuilder
    {
        #region Properties
        public Guid Id;
        public StoreType StoreAcronym;
        public string CreditGrantedAJU;
        public string AccountingAccountDeb;
        public string AccountingAccountCred;
        #endregion

        #region New
        public static CreditGrantedFinancialAccountBuilder New()
        {
            return new CreditGrantedFinancialAccountBuilder()
            {
                Id = Guid.NewGuid(),
                AccountingAccountCred =  "AACred",
                AccountingAccountDeb = "AADeb",
                CreditGrantedAJU = "AJU",
                StoreAcronym = StoreType.TBRA
            };
        }
        #endregion

        #region With Methods
        public CreditGrantedFinancialAccountBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public CreditGrantedFinancialAccountBuilder WithStoreAcronym(StoreType storeAcronym)
        {
            StoreAcronym = storeAcronym;
            return this;
        }

        public CreditGrantedFinancialAccountBuilder WithCreditGrantedAJU(string creditGrantedAJU)
        {
            CreditGrantedAJU = creditGrantedAJU;
            return this;
        }

        public CreditGrantedFinancialAccountBuilder WithAccountingAccountDeb(string accountingAccountDeb)
        {
            AccountingAccountDeb = accountingAccountDeb;
            return this;
        }

        public CreditGrantedFinancialAccountBuilder WithAccountingAccountCred(string accountingAccountCred)
        {
            AccountingAccountCred = accountingAccountCred;
            return this;
        }
        #endregion

        #region Build
        public Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount Build()
            => new Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount(Id, StoreAcronym, CreditGrantedAJU, AccountingAccountDeb, AccountingAccountCred);
        #endregion
    }
}
