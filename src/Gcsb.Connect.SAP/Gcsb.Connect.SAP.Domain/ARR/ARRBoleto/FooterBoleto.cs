using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.ARR.Boleto
{
    public class FooterBoleto : Footer
    {
        [NotMapped]
        protected override string typeLine => "FF";

        public FooterBoleto(decimal totalReleases, string totalFineValue, string totalInterestValue, decimal totalReleasesValue)
        : base (totalReleases, totalFineValue, totalInterestValue, totalReleasesValue)
        {            
        }        
    }
}