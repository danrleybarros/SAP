using Autofac;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Remove;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Remove.Handler;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.ManagementFinancialAccount.Remove.Handler
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class GetHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        
        private readonly GetHandler getHandler;
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;
        private readonly Guid Id = Guid.NewGuid();

        public GetHandlerTest(Fixture.ApplicationFixture fixture)
        {           
            this.getHandler = fixture.Container.Resolve<GetHandler>();
            this.managementFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();
        }

        private void AddMock()
        {
            var managementFinancialAccount = ManagementFinancialAccountBuilder.New().WithId(Id).Build();
            managementFinancialAccountWriteOnlyRepository.Add(managementFinancialAccount);
        }       

        [Theory]
        [TestPriority(0)]
        [InlineData("123")]
        public void ShouldGetManagementFinancialAccount(string userId)
        {
            AddMock();

            var request = new ManagementFinancialAccountRequest(userId, Id);

            getHandler.ProcessRequest(request);

            Assert.True(request.ManagementFinancialAccount != null);
            Assert.True(!request.Logs.Any(w => w.TypeLog.Equals(TypeLog.Error)));

        }

        [Theory]
        [TestPriority(1)]
        [InlineData("123", "No Data Found")]
        public void ShouldReturnMessageNoDataFound(string userId, string message)
        {
            var request = new ManagementFinancialAccountRequest(userId, Guid.NewGuid());

            getHandler.ProcessRequest(request);

            Assert.True(!request.Logs.Any(w => w.TypeLog.Equals(TypeLog.Processing) && w.Message.Contains(message)));

        }
    }
}
