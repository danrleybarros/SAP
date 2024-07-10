using Autofac;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Get;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Get.Handler;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.ManagementFinancialAccount.Get.Handler
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
        [InlineData("123", StoreType.TBRA)]      
        public void ShouldGetManagementFinancialAccount(string userId, StoreType storeType)
        {
            AddMock();

            var request = new ManagementFinancialAccountRequest(storeType, userId);

            getHandler.ProcessRequest(request);

            Assert.True(request.ManagementFinancialAccount != null);
            Assert.True(!request.Logs.Any(w => w.TypeLog.Equals(TypeLog.Error)));
        }

        [Theory]
        [TestPriority(1)]
        [InlineData("123", "No Data Found", StoreType.TBRA)]
        public void ShouldReturnMessageNoDataFound(string userId, string message, StoreType storeType)
        {
            var request = new ManagementFinancialAccountRequest(storeType, userId);

            getHandler.ProcessRequest(request);

            Assert.True(!request.Logs.Any(w => w.TypeLog.Equals(TypeLog.Processing) && w.Message.Contains(message)));

        }


    }
}
