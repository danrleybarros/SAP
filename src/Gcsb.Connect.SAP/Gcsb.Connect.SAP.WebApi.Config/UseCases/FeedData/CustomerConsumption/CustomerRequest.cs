using Gcsb.Connect.SAP.Domain.Config.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomerConsumption
{
    public class CustomerRequest
    {
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentType DocumentType { get; set; }

        [Required]
        public string DocumentNumber { get; set; }
    }
}
