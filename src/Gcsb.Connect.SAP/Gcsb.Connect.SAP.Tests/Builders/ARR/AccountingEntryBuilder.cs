using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Tests.Builders.ARR
{
    public class AccountingEntryBuilder
    {
        public string ArrecadacaoARR;
        public string AccountingEntryType;
        public string AccountingAccount;
        public StoreType Store;
        public StoreType Provider;
        public bool HaveIntercompany;

        public static AccountingEntryBuilder New()
        {
            return new AccountingEntryBuilder()
            {
                ArrecadacaoARR = "arrecadacao01",
                AccountingEntryType = "C",
                AccountingAccount = "account345",
                Store = StoreType.TBRA,
                Provider = StoreType.TBRA,
                HaveIntercompany = false
            };
        }

        public AccountingEntryBuilder WithArrecadacaoARR(string arrecadacaoARR)
        {
            this.ArrecadacaoARR = arrecadacaoARR;
            return this;
        }

        public AccountingEntryBuilder WithAccountingEntryType(string accountingEntryType)
        {
            this.AccountingEntryType = accountingEntryType;
            return this;
        }

        public AccountingEntryBuilder WithAccountingAccount(string accountingAccount)
        {
            this.AccountingAccount = accountingAccount;
            return this;
        }

        public AccountingEntryBuilder WithStore(StoreType store)
        {
            this.Store = store;
            return this;
        }

        public AccountingEntryBuilder WithProvider(StoreType provider)
        {
            this.Provider = provider;
            return this;
        }

        public AccountingEntryBuilder WithHaveIntercompany(bool haveIntercompany)
        {
            this.HaveIntercompany = haveIntercompany;
            return this;
        }

        public AccountingEntry Build()
        {
            return new AccountingEntry(ArrecadacaoARR, AccountingEntryType, AccountingAccount, Store, Provider, HaveIntercompany);
        }
    }
}
