using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount.Get
{
    public class ManagementFinancialAccountGetInput
    {
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public StoreType StoreType { get; set; }
    }
}
