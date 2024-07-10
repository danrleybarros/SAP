using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gcsb.Connect.SAP.Domain.FinancialAccountsClient.ManagementFinancialAccount
{
    public class ManagementFinancialAccountDto
    {
        [JsonProperty("storeAcronym")]
        public string StoreAcronym { get; set; }
        [JsonProperty("isProvider")]
        public bool IsProvider { get; set; }
        [JsonProperty("boleto")]
        public AccountIntercompany Boleto { get; set; }
        [JsonProperty("creditCard")]
        public AccountIntercompany CreditCard { get; set; }
        [JsonProperty("unassigned")]
        public Account Unassigned { get; set; }
        [JsonProperty("critic")]
        public Account Critic { get; set; }
        [JsonProperty("transferred")]
        public Account Transferred { get; set; }
    }

    public class AccountIntercompany
    {
        [JsonProperty("financialAccount")]
        public string FinancialAccount { get; set; }
        [JsonProperty("accountingAccountCredit")]
        public string AccountingAccountCredit { get; set; }
        [JsonProperty("accountingAccountDebit")]
        public string AccountingAccountDebit { get; set; }
        [JsonProperty("intercompany")]
        public List<Intercompany> Intercompany { get; set; }
    }

    public class Intercompany
    {
        [JsonProperty("providerCompany")]
        public string ProviderCompany { get; set; }
        [JsonProperty("accountingAccountCredit")]
        public string AccountingAccountCredit { get; set; }
        [JsonProperty("accountingAccountDebit")]
        public string AccountingAccountDebit { get; set; }
    }

    public class Account
    {
        [JsonProperty("storeAcronym")]
        public string FinancialAccount { get; set; }
        [JsonProperty("accountingAccountCredit")]
        public string AccountingAccountCredit { get; set; }
        [JsonProperty("accountingAccountDebit")]
        public string AccountingAccountDebit { get; set; }        
    }
}
