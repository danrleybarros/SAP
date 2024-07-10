using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.HistoryConsumption
{
    public class InputHistoryRequest
    {
        [Required]
        public long CustomerCode { get; set; }
    }
}
