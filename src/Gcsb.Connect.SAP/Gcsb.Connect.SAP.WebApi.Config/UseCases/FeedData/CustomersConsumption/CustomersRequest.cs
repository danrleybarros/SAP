using Gcsb.Connect.SAP.Domain.Config.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomersConsumption
{
    public class CustomersRequest
    {
        [Required]
        public List<string> InvoicesNumbers { get; set; }
    }
}
