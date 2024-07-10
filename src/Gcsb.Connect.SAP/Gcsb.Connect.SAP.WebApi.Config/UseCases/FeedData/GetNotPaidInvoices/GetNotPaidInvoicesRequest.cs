using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetNotPaidInvoices
{
    public class GetNotPaidInvoicesRequest
    {
        [Required]
        public List<string> InvoicesNumbers { get; set; }
    }
}
