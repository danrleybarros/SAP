using FluentAssertions;
using Gcsb.Connect.SAP.Tests.Builders.Config.FinancialAccounts;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Config.FinancialAccounts
{
    [UseAutofacTestFramework]   
    public class AccountTypeTests
    {
        [Fact]
        public void ShouldCreate()
        {
            var model = AccountTypeBuilder.New().Build();
            Util.ValidateModel(model).Count.Should().Be(0);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateAccountTypeWithNullOrEmptyType(string value)
        {
            var model = AccountTypeBuilder.New().WithType(value).Build();
            Util.ValidateModel(model).Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateAccountTypeWithNullOrEmptyDescription(string value)
        {
            var model = AccountTypeBuilder.New().WithDescription(value).Build();
            Util.ValidateModel(model).Count.Should().BeGreaterThan(0);
        }
    }
}
