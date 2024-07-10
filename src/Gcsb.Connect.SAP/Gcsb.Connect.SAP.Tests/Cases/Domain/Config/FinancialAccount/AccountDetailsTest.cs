using System;
using Gcsb.Connect.SAP.Tests.Builders.Config;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Config.FinancialAccount
{
    [UseAutofacTestFramework]
    public class AccountDetailsTest
    {

        [Fact]
        public void ShouldCreateAccountDetails()
        {
            var model = AccountDetailsBuilder.New().Build();

            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void NullOrEmptyShouldNotCreateWithIdService()
        {
            var model = AccountDetailsBuilder.New().WithIdService(new Guid()).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void NullOrEmptyShouldNotCreateWithIdInterface()
        {
            var model = AccountDetailsBuilder.New().WithIdInterface(new Guid()).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithAccountType(string accountType)
        {
            var model = AccountDetailsBuilder.New().WithAccountType(accountType).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithAccount(string financialAccount)
        {
            var model = AccountDetailsBuilder.New().WithFinancialAccount(financialAccount).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithAccountDebit(string financialAccountDebit)
        {
            var model = AccountDetailsBuilder.New().WithIdFinancialAccountDeb(financialAccountDebit).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithAccountCredit(string financialAccountCredit)
        {
            var model = AccountDetailsBuilder.New().WithIdFinancialAccountCred(financialAccountCredit).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }


    }
}
