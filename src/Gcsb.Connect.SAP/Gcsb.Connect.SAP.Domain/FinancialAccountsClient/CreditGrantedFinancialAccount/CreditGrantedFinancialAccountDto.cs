using System;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Newtonsoft.Json;

namespace Gcsb.Connect.SAP.Domain.FinancialAccountsClient.CreditGrantedFinancialAccount
{
    public class CreditGrantedFinancialAccountDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("storeAcronym")]
        public string StoreAcronym { get; set; }
        [JsonProperty("creditGrantedAJU")]
        public string CreditGrantedAJU  { get; set; }
        [JsonProperty("accountingAccountDeb")]
        public string AccountingAccountDeb { get; set; }
        [JsonProperty("accountingAccountCred")]
        public string AccountingAccountCred { get; set; }
    }
}
