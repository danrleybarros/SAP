using Gcsb.Connect.SAP.Domain.Config;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config
{
    public class FinancialAccountRequest
    {
        public string ServiceCode { get; set; }

        public string FinanceAccount { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public StoreType StoreType { get; set; }



        public FinancialAccountRequest(string serviceCode, string financeAccount, StoreType storeType)
        {
            this.ServiceCode = serviceCode;
            this.FinanceAccount = financeAccount;
            this.StoreType = storeType;
        }
    }
}
