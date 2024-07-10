using Autofac;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Update.Handler;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Update;
using Xunit;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Application.Repositories;
using System;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.ManagementFinancialAccount.Update.Handler
{
    public class UpdateHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly UpdateHandler updateHandler;
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;
        private SAP.Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount managementFinancialAccount;
        private readonly Guid Id = Guid.NewGuid();

        public UpdateHandlerTest(Fixture.ApplicationFixture fixture)
        {
            updateHandler = fixture.Container.Resolve<UpdateHandler>();
            this.managementFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();
        }

        private void AddMock()
        {
            managementFinancialAccount = ManagementFinancialAccountBuilder.New().WithId(Id).Build();
            managementFinancialAccountWriteOnlyRepository.Add(managementFinancialAccount);
        }


        [Theory]
        [InlineData("123")]
        public void ShouldUpdateManagementFinancialAccount(string userId)
        {
            AddMock();

            var request = new ManagementFinancialAccountRequest(userId, managementFinancialAccount);          

            updateHandler.ProcessRequest(request);

            Assert.True(!request.Logs.Any(c => c.TypeLog.Equals(TypeLog.Error)));

        }
    }
}
