using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.JSDN
{
    public class ServiceFinancialAccountTest
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateBillFeedDocDomain()
        {
            var model = Builders.Build.ServiceFinancialAccount.Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Fact]
        public void ShouldNotCreateIdNullOrEmpty()
        {
            var model = Builders.Build.ServiceFinancialAccount.WithId(new Guid()).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithStore(string valor)
        {
            var model = Builders.Build.ServiceFinancialAccount.WithStore(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithServiceCode(string valor)
        {
            var model = Builders.Build.ServiceFinancialAccount.WithServiceCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithProviderCompany(string valor)
        {
            var model = Builders.Build.ServiceFinancialAccount.WithProviderCompany(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

    }
}
