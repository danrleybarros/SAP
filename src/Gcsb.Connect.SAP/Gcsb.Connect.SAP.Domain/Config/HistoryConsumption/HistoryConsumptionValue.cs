using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.Config.HistoryConsumption
{
    public class HistoryConsumptionValue
    {
        [Required]
        [MaxLength(4)]
        public string ServiceType { get; private set; }

        [Required]
        public string MonthYear { get; private set; }

        [Required]
        public decimal Value { get; private set; }

        public HistoryConsumptionValue(string serviceType, string monthYear, decimal value)
        {
            ServiceType = serviceType;
            MonthYear = monthYear;
            Value = value;
        }
    }
}
