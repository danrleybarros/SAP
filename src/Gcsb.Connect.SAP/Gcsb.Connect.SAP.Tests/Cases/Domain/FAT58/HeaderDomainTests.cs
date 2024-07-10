using Gcsb.Connect.SAP.Tests.Builders.FAT.FATBase;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.FAT58
{
    public class HeaderDomainTests
    {
        #region Should Create
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateHeader()
        {
            var model = HeaderBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region Tests constants
        [Theory]
        [Trait("Action", "None")]
        [InlineData("HH", "FAT", "TBRA", "29SP")]
        public void ShouldMatchConstantsHeaderDomain(string linetype, string origin, string company, string division)
        {
            var model = HeaderBuilder.New().Build();
            Assert.True(model.LineType == linetype);
            Assert.True(model.Origin == origin);
            Assert.True(model.Company == company);
            Assert.True(model.Division == division);
        }
        #endregion

    }
}
