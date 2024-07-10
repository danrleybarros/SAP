using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount
{
    public class FinancialAccount
    {
        public string StoreAcronym { get; private set; }
        public string ServiceCode { get; private set; }
        public string ProviderCompanyAcronym { get; private set; }
        public bool HaveIntercompany { get; private set; }
        public string InterfaceType { get; private set; }
        public string AccountType { get; private set; }
        public string FinancialAccountValue { get; private set; }
        public string FinancialAccountDeb { get; private set; }
        public string FinancialAccountCred { get; private set; }
        public StoreType Store { get => Util.ToEnum<StoreType>(StoreAcronym); }
        public StoreType Provider { get => Util.ToEnum<StoreType>(ProviderCompanyAcronym); }

        public FinancialAccount(string storeAcronym, string serviceCode, string providerCompanyAcronym, bool haveIntercompany, string interfaceType, string accountType, string financialAccountValue, string financialAccountDeb, string financialAccountCred)
        {
            StoreAcronym = storeAcronym;
            ServiceCode = serviceCode;
            ProviderCompanyAcronym = providerCompanyAcronym;
            HaveIntercompany = haveIntercompany;
            InterfaceType = interfaceType;
            AccountType = accountType;
            FinancialAccountValue = financialAccountValue;
            FinancialAccountDeb = financialAccountDeb;
            FinancialAccountCred = financialAccountCred;
        }
    }
}
