using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetDetailServiceByInvoice
{
    public class GetDetailServiceRequest
    {
        [Required]
        public List<string> Invoices { get; set; }
    }
}
