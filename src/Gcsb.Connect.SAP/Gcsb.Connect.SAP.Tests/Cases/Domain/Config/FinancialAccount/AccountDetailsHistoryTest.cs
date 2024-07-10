using System;
using Gcsb.Connect.SAP.Tests.Builders.Config;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Config.FinancialAccount
{
    [UseAutofacTestFramework]
    public class AccountDetailsHistoryTest
    {
        [Fact]
        public void ShouldCreateAccountDetailsHistory()
        {
            var model = AccountDetailsHistoryBuilder.New().Build();

            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void NullOrEmptyShouldNotCreateWithIdService()
        {
            var model = AccountDetailsHistoryBuilder.New().WithIdService(new Guid()).Build();
            Assert.False(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void NullOrEmptyShouldNotCreateWithIdInterface()
        {
            var model = AccountDetailsHistoryBuilder.New().WithIdInterface(new Guid()).Build();
            Assert.False(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void NullOrEmptyShouldNotCreateWithIdAccountType()
        {
            var model = AccountDetailsHistoryBuilder.New().WithIdAccountType(new Guid()).Build();
            Assert.False(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithAccount(string financialAccount)
        {
            var model = AccountDetailsHistoryBuilder.New().WithFinancialAccount(financialAccount).Build();
            Assert.False(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithAccountDebit(string accountDebit)
        {
            var model = AccountDetailsHistoryBuilder.New().WithAccountDebit(accountDebit).Build();
            Assert.False(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithAccountCredit(string accountCredit)
        {
            var model = AccountDetailsHistoryBuilder.New().WithAccountDebit(accountCredit).Build();
            Assert.False(Util.ValidateModel(model).Count == 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void NullOrEmptyShouldNotCreateWithInclusionDate()
        {
            var model = AccountDetailsHistoryBuilder.New().WithInclusionDate(DateTime.UtcNow).Build();
            Assert.False(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void NullOrEmptyShouldNotCreateWithLastUpdate()
        {
            var model = AccountDetailsHistoryBuilder.New().WithLastUpdate(DateTime.UtcNow).Build();
            Assert.False(Util.ValidateModel(model).Count > 0);
        }


    }
}
