using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetOrdemInterna
{
    public class GetOrdemInternaRequest
    {
        [Required]
        public List<string> UFs { get; set; }
        
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public StoreType Store { get; set; }
    }
}
