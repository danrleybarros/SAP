using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany
{
    public class FooterCreditCardInter : Footer
    {
        [NotMapped]
        protected override string typeLine => "FF";

        public FooterCreditCardInter(decimal totalReleases, string totalFineValue, string totalInterestValue, decimal totalReleasesValue)
        : base(totalReleases, totalFineValue, totalInterestValue, totalReleasesValue)
        {
        }
    }
}
