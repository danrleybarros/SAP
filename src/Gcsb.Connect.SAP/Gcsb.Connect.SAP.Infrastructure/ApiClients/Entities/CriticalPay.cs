using Newtonsoft.Json;
using System;

namespace Gcsb.Connect.SAP.Infrastructure.ApiClients.Entities
{
   public class CriticalPay 
    {    
        [JsonProperty("invoiceAmount")]
        public decimal InvoiceAmount { get;set; }

        [JsonProperty("registerDate")]
        public DateTime RegisterDate { get;set; }

        [JsonProperty("bankCode")]
        public string BankCode { get; set; }

        [JsonProperty("inclusionDate")]
        public DateTime InclusionDate { get; set; }

    }
}
