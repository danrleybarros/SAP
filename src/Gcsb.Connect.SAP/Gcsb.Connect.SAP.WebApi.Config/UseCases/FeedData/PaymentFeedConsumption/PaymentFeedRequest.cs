using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.PaymentFeedConsumption
{
    public class PaymentFeedRequest
    {
        [Required]
        public string CustomerCode { get; set; }
    }
}
