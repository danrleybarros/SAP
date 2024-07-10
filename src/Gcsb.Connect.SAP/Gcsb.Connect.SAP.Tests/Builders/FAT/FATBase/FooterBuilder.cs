
using Gcsb.Connect.SAP.Domain.FAT.FATBase;

namespace Gcsb.Connect.SAP.Tests.Builders.FAT.FATBase
{
    public class FooterBuilder
    {
        public int TotalReleases;

        public decimal TotalReleasesValue;

        public static FooterBuilder New()
        {
            return new FooterBuilder
            {
                TotalReleases = 1,
                TotalReleasesValue = 38.88m
            };
        }

        public FooterBuilder WithTotalReleases(int totalreleases)
        {
            TotalReleases = totalreleases;
            return this;
        }

        public FooterBuilder WithTotalReleasesValue(decimal totalreleasesvalue)
        {
            TotalReleasesValue = totalreleasesvalue;
            return this;
        }

        public Footer Build()
        {
            return new Footer(TotalReleases, TotalReleasesValue);
        }
    }
}
