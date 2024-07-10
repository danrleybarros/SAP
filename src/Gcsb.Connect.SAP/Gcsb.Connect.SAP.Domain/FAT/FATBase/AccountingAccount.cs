using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Domain.FAT.FATBase
{
    public class AccountingEntry
    {
        public string FinancialAccount { get; private set; }
        public string AccountingEntryType { get; private set; }
        public string AccountingAccount { get; private set; }        
        public string ServiceCode { get; private set; }
        public bool HaveIntercompany { get; private set; }
        public StoreType Store { get; private set; }        
        public StoreType Provider { get; private set; }

        public AccountingEntry(string financialAccount, string accountingEntryType, string accountingAccount, StoreType store = StoreType.TBRA, string serviceCode = null, StoreType provider = StoreType.TBRA, bool haveIntercompany = false)
        {
            FinancialAccount = financialAccount;
            AccountingEntryType = accountingEntryType;
            AccountingAccount = accountingAccount;
            ServiceCode = serviceCode;
            HaveIntercompany = haveIntercompany;
            Store = store;
            Provider = provider;            
        }
    }
}
