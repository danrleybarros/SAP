using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.BillFeedData.BillFeedRequest
{
    public class InputBillRequest
    {
        [Required]
        public DateTime BillFromDate { get; set; }

        [Required]
        public DateTime BillToDate { get; set; }
    }
}
