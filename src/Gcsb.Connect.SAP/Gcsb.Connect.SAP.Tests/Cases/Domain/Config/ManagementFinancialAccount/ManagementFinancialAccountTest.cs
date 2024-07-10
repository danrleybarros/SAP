using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Config.ManagementFinancialAccount
{
    public class ManagementFinancialAccountTest
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateDomain()
        {
            var model = ManagementFinancialAccountBuilder.New().Build();

            Assert.True(Util.ValidateModel(model).Count == 0);        
        }

        [Fact]        
        public void ShouldNotCreateDomainWithARRNull()
        {
            var model = ManagementFinancialAccountBuilder.New().WithARR(null).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]       
        public void ShouldNotCreateDomainWithUnassignedNull()
        {
            var model = ManagementFinancialAccountBuilder.New().WithUnassigned(null).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]   
        public void ShouldNotCreateDomainWithCriticNull()
        {
            var model = ManagementFinancialAccountBuilder.New().WithCritic(null).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]        
        public void ShouldNotCreateDomainWithTransferNull()
        {
            var model = ManagementFinancialAccountBuilder.New().WithTransfer(null).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }
    }
}
