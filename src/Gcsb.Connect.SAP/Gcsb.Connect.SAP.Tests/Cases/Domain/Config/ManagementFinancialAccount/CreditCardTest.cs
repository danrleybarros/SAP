using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Config.ManagementFinancialAccount
{
    public class CreditCardTest
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateDomain()
        {
            var model = CreditCardBuilder.New().Build();

            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateDomainWithFinancialAccountNullorEmpty(string financialAccount)
        {
            var model = CreditCardBuilder.New().WithFinancialAccount(financialAccount).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void ShouldNotCreateDomainWithAccountingAccountNull()
        {
            var model = CreditCardBuilder.New().WithAccountingAccount(null).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("Lorem Ipsum is simply dummy text")]
        public void ShouldNotCreateDomainWithFinancialAccountGreaterThan15(string financialAccount)
        {
            var model = BoletoBuilder.New().WithFinancialAccount(financialAccount).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }
    }
}
