using Gcsb.Connect.SAP.Tests.Builders.GF;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.GF
{
    public class CISSDomainTests
    {
        #region Create

        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateLaunch()
        {
            var model = new CISSBuilder().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #endregion

        #region Create with null or empty information

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateLaunchWithComplementNullOrEmpty(string value)
        {
            var model = new CISSBuilder().WithCompanyCode(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
              
        #endregion
    }
}
