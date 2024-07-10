using FluentAssertions;
using Gcsb.Connect.SAP.Tests.Builders.Config.CreditGrantedFinancialAccount;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Config.CreditGrantedFinancialAccount
{
    [UseAutofacTestFramework]
    public class CreditGrantedFinancialAccountTests
    {
        [Fact]
        public void ShouldCreate()
        {
            var model = CreditGrantedFinancialAccountBuilder.New().Build();
            Util.ValidateModel(model).Count.Should().Be(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullCreditGrantedAJU(string value)
        {
            var model = CreditGrantedFinancialAccountBuilder.New().WithCreditGrantedAJU(value).Build();
            Util.ValidateModel(model).Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullAccountingAccountDeb(string value)
        {
            var model = CreditGrantedFinancialAccountBuilder.New().WithAccountingAccountDeb(value).Build();
            Util.ValidateModel(model).Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullAccountingAccountCred(string value)
        {
            var model = CreditGrantedFinancialAccountBuilder.New().WithAccountingAccountCred(value).Build();
            Util.ValidateModel(model).Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("1234657890123456")]
        public void MaxLengthCreditGrantedAJU(string value)
        {
            var model = CreditGrantedFinancialAccountBuilder.New().WithCreditGrantedAJU(value).Build();
            Util.ValidateModel(model).Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("1234657890123456")]
        public void MaxLengthAccountingAccountDeb(string value)
        {
            var model = CreditGrantedFinancialAccountBuilder.New().WithAccountingAccountDeb(value).Build();
            Util.ValidateModel(model).Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("1234657890123456")]
        public void MaxLengthAccountingAccountCred(string value)
        {
            var model = CreditGrantedFinancialAccountBuilder.New().WithAccountingAccountCred(value).Build();
            Util.ValidateModel(model).Count.Should().BeGreaterThan(0);
        }
    }
}
