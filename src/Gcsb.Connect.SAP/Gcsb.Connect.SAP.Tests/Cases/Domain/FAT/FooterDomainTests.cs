using Gcsb.Connect.SAP.Tests.Builders.FAT.FATBase;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.FAT
{
    public class FooterDomainTests
    {
        #region Should create        
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateFooterDomain()
        {
            var model = FooterBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region Should not create with invalid information
        [Theory]
        [Trait("Action", "none")]
        [InlineData(1000000)]
        public void ShouldNotCreateWithInvalidTotalReleases(int value)
        {
            var model = FooterBuilder.New().WithTotalReleases(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(0.001)]
        [InlineData(0.1)]
        public void ShouldNotCreateWithInvalidTotalReleasesValue(decimal value)
        {
            var model = FooterBuilder.New().WithTotalReleasesValue(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion

        #region Tests constants
        [Theory]
        [InlineData("FF")]
        public void ShouldMatchConstantsFooterDomain(string linetype)
        {
            var model = FooterBuilder.New().Build();
            Assert.True(model.LineType == linetype);
        }
        #endregion
    }
}
