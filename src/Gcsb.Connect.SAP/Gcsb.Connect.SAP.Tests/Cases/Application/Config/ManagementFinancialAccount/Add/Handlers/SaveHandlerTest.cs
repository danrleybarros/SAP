
using Autofac;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Add;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Add.Handler;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.ManagementFinancialAccount.Add.Handlers
{
    public class SaveHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;
        private readonly SaveHandler saveHandler;

        public SaveHandlerTest(Fixture.ApplicationFixture fixture)
        {
            managementFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();
            saveHandler = fixture.Container.Resolve<SaveHandler>();
        }

        [Theory]
        [InlineData("123")]
        public void ShouldExecute(string userId)
        {
            var request = new ManagementFinancialAccountRequest(userId, ManagementFinancialAccountBuilder.New().Build());

            saveHandler.ProcessRequest(request);

            Assert.True(!request.Logs.Any(c => c.TypeLog.Equals(TypeLog.Error)));
        }
    }
}
