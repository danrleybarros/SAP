using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.HistoryConsumption
{
    public class OutputHistoryResponse
    {
        [Required]
        [MaxLength(4)]
        public string ServiceType { get; private set; }

        [Required]
        public string MonthYear { get; private set; }


        [Required]
        public decimal Value { get; private set; }

        public OutputHistoryResponse(string serviceType, string monthYear, decimal value)
        {
            ServiceType = serviceType;
            MonthYear = monthYear;
            Value = value;
        }
    }
}
