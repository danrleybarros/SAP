using Autofac;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Add;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.ManagementFinancialAccount.Add
{   
    public class ManagementFinancialAccountAddUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IManagementFinancialAccountAddUseCase managementFinancialAccountAddUseCase;
      
        public ManagementFinancialAccountAddUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.managementFinancialAccountAddUseCase = fixture.Container.Resolve<IManagementFinancialAccountAddUseCase>();         
        }

        [Theory]
        [InlineData("123")]
        public void ShouldCreateMananagementFinancialAccount(string userId)
        {
            var request = new ManagementFinancialAccountRequest(userId,ManagementFinancialAccountBuilder.New().Build());

            managementFinancialAccountAddUseCase.Execute(request);         

            Assert.False(!request.Logs.Any(c=> c.TypeLog.Equals(TypeLog.Error)));
        }
        
    }
}
