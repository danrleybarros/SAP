using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Domain.ARR
{
    public class AccountingEntry
    {
        public string ArrecadacaoARR { get; private set; }
        public string AccountingEntryType { get; private set; }
        public string AccountingAccount { get; private set; }
        public StoreType Store { get; private set; }        
        public StoreType Provider { get; private set; }
        public bool HaveIntercompany { get; private set; }

        public AccountingEntry(string arrecadacaoARR, string accountingEntryType, string accountingAccount, StoreType store)
        {
            ArrecadacaoARR = arrecadacaoARR;
            AccountingEntryType = accountingEntryType;
            AccountingAccount = accountingAccount;
            Store = store;
        }

        public AccountingEntry(string arrecadacaoARR, string accountingEntryType, string accountingAccount, StoreType provider, bool haveIntercompany)
        {
            ArrecadacaoARR = arrecadacaoARR;
            AccountingEntryType = accountingEntryType;
            AccountingAccount = accountingAccount;
            Provider = provider;
            HaveIntercompany = haveIntercompany;
        }

        public AccountingEntry(string arrecadacaoARR, string accountingEntryType, string accountingAccount, StoreType store, StoreType provider, bool haveIntercompany)
        {
            ArrecadacaoARR = arrecadacaoARR;
            AccountingEntryType = accountingEntryType;
            AccountingAccount = accountingAccount;
            Store = store;
            Provider = provider;
            HaveIntercompany = haveIntercompany;
        }
    }
}
