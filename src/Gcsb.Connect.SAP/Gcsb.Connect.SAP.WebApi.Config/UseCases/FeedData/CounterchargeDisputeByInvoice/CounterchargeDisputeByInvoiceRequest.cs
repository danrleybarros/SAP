using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CounterchargeDisputeByInvoice
{
    public class CounterchargeDisputeByInvoiceRequest
    {
        [Required]
        public List<string> Invoices { get; set; }
    }
}
