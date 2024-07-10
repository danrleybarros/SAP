using Gcsb.Connect.SAP.Tests.Builders.Config.InterestAndFineFinancialAccount;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Config.InterestAndFineFinancialAccount
{
    public class InterestAndFineFinancialAccountTest
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateDomain()
        {
            var model = InterestAndFineFinancialAccountBuilder.New().Build();

            Assert.True(Util.ValidateModel(model).Count == 0);
        }
    }
}
