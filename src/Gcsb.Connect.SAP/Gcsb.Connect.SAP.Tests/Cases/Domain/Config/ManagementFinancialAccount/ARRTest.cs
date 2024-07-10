using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Config.ManagementFinancialAccount
{
    public class ARRTest
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateDomain()
        {
            var model = ARRBuilder.New().Build();

            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Fact]
        public void ShouldNotCreateDomainWithBoletoNull()
        {
            var model = ARRBuilder.New().WithBoleto(null).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void ShouldNotCreateDomainWithCreditCardNull()
        {
            var model = ARRBuilder.New().WithCreditCard(null).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }
    }
}
