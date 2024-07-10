
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Domain.AJU
{
    public class ServiceAccountingAccountAJU
    {       
        public string FinancialAccount { get; private set; }
        public string ServiceCode { get; private set; }
        public bool HaveIntercompany { get; private set; }
        public StoreType Store { get; private set; }
        public StoreType Provider { get; private set; }
        public TypeAccounting Type { get; set; }
        public string[] AccountingAccount { get; private set; }

        public ServiceAccountingAccountAJU(string financialAccount, string serviceCode, bool haveIntercompany, StoreType store, StoreType provider, TypeAccounting type, params string[] accountingAccount)
        {
            FinancialAccount = financialAccount;
            ServiceCode = serviceCode;
            HaveIntercompany = haveIntercompany;
            Store = store;
            Provider = provider;
            Type = type;
            AccountingAccount = accountingAccount;
        }

        public ServiceAccountingAccountAJU(string financialAccount, TypeAccounting type, params string[] accountingAccount)
        {
            FinancialAccount = financialAccount;
            AccountingAccount = accountingAccount;
            Type = type;
        }
    }
  
}
