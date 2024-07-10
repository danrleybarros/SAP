using Autofac;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Remove;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Remove.Handler;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using System;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.ManagementFinancialAccount.Remove.Handler
{
    public class RemoveHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly RemoveHandler removeHandler;
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;
        private readonly Guid Id = Guid.NewGuid();
        private SAP.Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount managementFinancialAccount;

        public RemoveHandlerTest(Fixture.ApplicationFixture fixture)
        {
            removeHandler = fixture.Container.Resolve<RemoveHandler>();
            this.managementFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();
        }

        private void AddMock()
        {
            managementFinancialAccount = ManagementFinancialAccountBuilder.New().WithId(Id).Build();
            managementFinancialAccountWriteOnlyRepository.Add(managementFinancialAccount);
        }


        [Theory]
        [InlineData("123")]
        public void ShouldRemoveManagementFinancialAccount(string userId)
        {
            AddMock();

            var request = new ManagementFinancialAccountRequest(userId, Id);

            request.AddManagementFinancialAccount(managementFinancialAccount);

            removeHandler.ProcessRequest(request);

            Assert.True(!request.Logs.Any(w => w.TypeLog.Equals(TypeLog.Error)));

        }

    }
}
