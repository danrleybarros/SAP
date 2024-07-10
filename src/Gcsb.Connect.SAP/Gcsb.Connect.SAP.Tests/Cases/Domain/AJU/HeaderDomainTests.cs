using Gcsb.Connect.SAP.Tests.Builders.AJU;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.AJU
{
    public class HeaderDomainTests
    {

        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateHeader()
        {
            var model = HeaderBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("FAT", "TBRA", "29SP")]
        public void ShouldMatchConstantsHeaderDomain(string origin, string company, string division)
        {
            var model = HeaderBuilder.New().Build();
            Assert.True(model.Origin == origin);
            Assert.True(model.Company == company);
            Assert.True(model.Division == division);
        }
    }
}
