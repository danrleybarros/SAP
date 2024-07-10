using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;

namespace Gcsb.Connect.SAP.Tests.Builders.FinancialAccountsClient
{
    public class FinancialAccountBuilder
    {
        public string StoreAcronym;
        public string ServiceCode;
        public string ProviderCompanyAcronym;
        public bool HaveIntercompany;
        public string InterfaceType;
        public string AccountType;
        public string FinancialAccountValue;
        public string FinancialAccountDeb;
        public string FinancialAccountCred;

        public static FinancialAccountBuilder New()
        {
            return new FinancialAccountBuilder()
            {
                StoreAcronym = "cloudCo",
                ServiceCode = "AzureActiveDirectoryBasic",
                ProviderCompanyAcronym = "cloudCo",
                HaveIntercompany = true,
                InterfaceType = "Billed",
                AccountType = "Billed",
                FinancialAccountValue = "FATO365CSPGW",
                FinancialAccountDeb = "41435025",
                FinancialAccountCred = "11215115"
            };
        }

        public FinancialAccountBuilder WithStoreAcronym(string storeAcronym)
        {
            StoreAcronym = storeAcronym;
            return this;
        }
        public FinancialAccountBuilder WithServiceCode(string serviceCode)
        {
            ServiceCode = serviceCode;
            return this;
        }
        public FinancialAccountBuilder WithProviderCompanyAcronym(string providerCompanyAcronym)
        {
            ProviderCompanyAcronym = providerCompanyAcronym;
            return this;
        }
        public FinancialAccountBuilder WithHaveIntercompany(bool haveIntercompany)
        {
            HaveIntercompany = haveIntercompany;
            return this;
        }
        public FinancialAccountBuilder WithInterfaceType(string interfaceType)
        {
            InterfaceType = interfaceType;
            return this;
        }
        public FinancialAccountBuilder WithAccountType(string accountType)
        {
            AccountType = accountType;
            return this;
        }
        public FinancialAccountBuilder WithFinancialAccountType(string financialAccountValue)
        {
            FinancialAccountValue = financialAccountValue;
            return this;
        }
        public FinancialAccountBuilder WithFinancialAccountDeb(string financialAccountDeb)
        {
            FinancialAccountDeb = financialAccountDeb;
            return this;
        }
        public FinancialAccountBuilder WithFinancialAccountCred(string financialAccountCred)
        {
            FinancialAccountCred = financialAccountCred;
            return this;
        }

        public FinancialAccount Build()
            => new FinancialAccount(StoreAcronym, ServiceCode, ProviderCompanyAcronym, HaveIntercompany, InterfaceType, AccountType, FinancialAccountValue, FinancialAccountDeb, FinancialAccountCred);
    }
}
