using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.CreditGrantedFinancialAccount.Save
{
    public class SaveInput
    {
        public Guid? Id { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public StoreType StoreAcronym { get; set; }
        [Required]
        [MaxLength(15)]
        public string CreditGrantedAJU { get; set; }
        [Required]
        [MaxLength(15)]
        public string AccountingAccountDeb { get; set; }
        [Required]
        [MaxLength(15)]
        public string AccountingAccountCred { get; set; }
    }
}
