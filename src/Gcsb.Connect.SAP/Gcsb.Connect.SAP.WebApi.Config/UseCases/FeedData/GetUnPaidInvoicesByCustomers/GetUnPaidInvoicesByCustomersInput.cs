using Gcsb.Connect.SAP.Application.Boundaries.GetOpenInvoices;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetUnPaidInvoicesByCustomers
{
    public class GetUnPaidInvoicesByCustomersInput
    {
        [Required]
        public List<DocumentInput> Documents { get; set; }
    }

    public class DocumentInput
    {
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public SearchType SearchType { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
