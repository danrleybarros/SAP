using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.ARR.CreditCard
{
    public class FooterCreditCard : Footer
    {
        [NotMapped]
        protected override string typeLine => "FF";

        public FooterCreditCard(decimal totalReleases, string totalFineValue, string totalInterestValue, decimal totalReleasesValue)
        : base (totalReleases, totalFineValue, totalInterestValue, totalReleasesValue)
        {            
        }        
    }
}