using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.InvoiceDetails
{
    public class InvoiceDetailsRequest
    {
        [Required]
        public List<string> InvoiceNumbers { get; set; }
    }
}
