using Gcsb.Connect.SAP.Domain.ARR.Boleto;

namespace Gcsb.Connect.SAP.Tests.Builders.ARRBOLETO
{
    public class FooterBuilder
    {
        public string TypeLine;
        public decimal TotalReleases;
        public string TotalFineValue;
        public string TotalInterestValue;
        public decimal TotalReleasesValue;

        public static FooterBuilder New()
        {
            return new FooterBuilder()
            {
                TypeLine = "FF",
                TotalReleases = 1000.00m,
                TotalFineValue = "",
                TotalInterestValue = "",
                TotalReleasesValue = 1000.00m
            };
        }

        public FooterBuilder WithTypeLine(string typeLine)
        {
            this.TypeLine = typeLine;
            return this;
        }

        public FooterBuilder WithTotalReleases(decimal totalReleases)
        {
            this.TotalReleases = totalReleases;
            return this;
        }

        public FooterBuilder WithTotalFineValue(string totalFineValue)
        {
            this.TotalFineValue = totalFineValue;
            return this;
        }

        public FooterBuilder WithTotalInterestValue(string totalInterestValue)
        {
            this.TotalInterestValue = totalInterestValue;
            return this;
        }

        public FooterBuilder WithTotalReleasesValue(decimal totalReleasesValue)
        {
            this.TotalReleasesValue = totalReleasesValue;
            return this;
        }

        public FooterBoleto Build()
        {
            return new FooterBoleto(TotalReleases, TotalFineValue, TotalInterestValue, TotalReleasesValue);
        }
    }
}
