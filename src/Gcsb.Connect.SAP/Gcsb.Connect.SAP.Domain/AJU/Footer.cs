using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.AJU
{
    public class Footer
    {
        public const string linetype = "FF";

        public const string totalReleasesFormat = "{0:000000}";
        public const string totalReleasesValueFormat = "{0,16:0.00}";

        [Required]
        [MaxLength(2)]
        public string LineType { get => linetype; }

        [Required]
        [Range(1, 999999)]
        [Format(totalReleasesFormat)]
        public int TotalReleases { get; private set; }

        [Required]
        [RegularExpression(@"^\d{1,16}.\d{2}$")]
        [Format(totalReleasesValueFormat)]
        public decimal TotalReleasesValue { get; private set; }

        public Footer(int totalreleases, decimal totalreleasesvalue)
        {
            this.TotalReleases = totalreleases;
            this.TotalReleasesValue = totalreleasesvalue;
        }
    }
}
