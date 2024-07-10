using Gcsb.Connect.SAP.Application.Boundaries.GetOpenInvoices;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetOpenInvoices
{
    public class GetOpenInvoicesInput
    {
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public SearchType SearchType { get; set; }

        [Required]
        public string Value { get; set; }
    }
}