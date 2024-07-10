using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.ARR
{
    public abstract class Footer
    {
        protected abstract string typeLine { get; }
        public const string totalReleasesFormat = "{0:000000}";
        public const string totalReleasesValueFormat = "{0,16:0.00}";

        [Required]
        [MaxLength(2)]
        public string TypeLine { get => typeLine; }

        [Required]
        [Range(0.0, Double.MaxValue)]
        [RegularExpression(@"^\d{1,16}.\d{2}$")]
        [Format(totalReleasesFormat)]
        public decimal TotalReleases { get; set; }

        [MaxLength(16)]
        public string TotalFineValue { get; private set; }

        [MaxLength(16)]
        public string TotalInterestValue { get; private set; }

        [Required]
        [Range(0.0, Double.MaxValue)]
        [RegularExpression(@"^\d{1,16}.\d{2}$")]
        [Format(totalReleasesValueFormat)]
        public decimal TotalReleasesValue { get; set; }

        public Footer(decimal totalReleases, string totalFineValue, string totalInterestValue, decimal totalReleasesValue)
        {
            this.TotalReleases = totalReleases;
            this.TotalFineValue = totalFineValue;
            this.TotalInterestValue = totalInterestValue;
            this.TotalReleasesValue = totalReleasesValue;
        }
    }
}