using Gcsb.Connect.SAP.Tests.Builders.Config.InterestAndFineFinancialAccount;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Config.InterestAndFineFinancialAccount
{
    public class AccountingAccountTest
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateDomain()
        {
            var model = AccountingAccountBuilder.New().Build();

            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [InlineData("Lorem Ipsum is simply dummy text")]
        public void ShouldNotCreateDomainWithCreditGreaterThan15(string credit)
        {
            var model = AccountingAccountBuilder.New().WithCredit(credit).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("Lorem Ipsum is simply dummy text")]
        public void ShouldNotCreateDomainWithDebitGreaterThan15(string debit)
        {
            var model = AccountingAccountBuilder.New().WithDebit(debit).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }
    }
}
