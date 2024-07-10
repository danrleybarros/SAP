using Xunit;
using Gcsb.Connect.SAP.Tests.Builders.ARR;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.ARR
{
    public class FooterDomainTest
    {
        #region Create Tests

        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateFooterDomain()
        {
            var model = FooterBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #endregion

        #region Tests With Constants

        [Theory]
        [Trait("Action", "None")]
        [InlineData("FF")]
        public void ShouldMatchConstantsFooterDomain(string typeLine)
        {
            var model = FooterBuilder.New().Build();
            Assert.Equal(model.TypeLine, typeLine);
        }

        #endregion

        #region Tests With Invalid Formats

        [Theory]
        [Trait("Action", "None")]
        [InlineData(999999.999)]
        [InlineData(999999.9)]
        [InlineData(.00)]
        public void FooterWrongTotalReleases(decimal value)
        {
            var model = FooterBuilder.New().WithTotalReleases(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        
        [Theory]
        [Trait("Action", "None")]
        [InlineData(999999.999)]
        [InlineData(999999.9)]
        [InlineData(99999999999999.9)]
        [InlineData(.00)]
        public void FooterWrongTotalReleasesValue(decimal value)
        {
            var model = FooterBuilder.New().WithTotalReleasesValue(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion
    }
}