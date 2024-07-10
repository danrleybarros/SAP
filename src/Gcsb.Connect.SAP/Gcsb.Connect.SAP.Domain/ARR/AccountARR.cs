using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Domain.ARR
{
    public class AccountARR
    {
        public string InvoiceNumber { get; private set; }
        public string ServiceCode { get; private set; }
        public string ArrecadacaoARR { get; private set; }
        public string AccountingEntryType { get; private set; }
        public string AccountingAccount { get; private set; }
        public StoreType Store { get; private set; }
        public StoreType Provider { get; private set; }
        public bool HaveIntercompany { get; private set; }
        public bool ValidAccount { get; private set; }

        public AccountARR(string invoiceNumber, string serviceCode, string arrecadacaoARR, string accountingEntryType, string accountingAccount, StoreType store, StoreType provider, bool haveIntercompany, bool validAccount)
        {
            InvoiceNumber = invoiceNumber;
            ServiceCode = serviceCode;
            ArrecadacaoARR = arrecadacaoARR;
            AccountingEntryType = accountingEntryType;
            AccountingAccount = accountingAccount;
            Store = store;
            Provider = provider;
            HaveIntercompany = haveIntercompany;
            ValidAccount = validAccount;
        }
    }
}
