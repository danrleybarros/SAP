using Gcsb.Connect.SAP.Domain.Config.PaymentFeed;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.PaymentFeedData.PaymentFeedRequest
{
    public class InputPayRequest
    {
        [Required]
        public FileType Type { get; set; }

        [Required]
        public DateTime BillFromDate { get; set; }

        [Required]
        public DateTime BillToDate { get; set; }
    }
}
