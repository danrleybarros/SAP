using Gcsb.Connect.SAP.Tests.Builders.AJU;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.AJU
{
    public class FooterDomainTests
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShoudCreateFooterDomain()
        {
            var model = FooterBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("FF")]
        public void TestsFooterConst(string value)
        {
            var model = FooterBuilder.New().Build();
            Assert.True(model.LineType == value);
        }
    }
}