using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.CreditGrantedFinancialAccount.GetByStore
{
    public class GetByStoreInput
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [Required]
        public StoreType StoreAcronym { get; set; }
    }
}
