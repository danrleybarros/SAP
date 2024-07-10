using Gcsb.Connect.SAP.Tests.Builders.Config.FinancialAccounts;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Config.FinancialAccounts
{
    public class InterfaceTests
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateInterfaceDomain()
        {
            var model = InterfaceBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithType(string type)
        {
            var model = InterfaceBuilder.New().WithType(type).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithDescription(string description)
        {
            var model = InterfaceBuilder.New().WithDescription(description).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
    }
}
