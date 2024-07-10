using Autofac;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Get;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.ManagementFinancialAccount.Get
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class ManagementFinancialAccountGetUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IManagementFinancialAccountGetUseCase managementFinancialAccountGetUseCase;       
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;
        private readonly Guid Id = Guid.NewGuid();

        public ManagementFinancialAccountGetUseCaseTest(Fixture.ApplicationFixture fixture)
        {           
            this.managementFinancialAccountGetUseCase = fixture.Container.Resolve<IManagementFinancialAccountGetUseCase>(); 
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

            var request = new ManagementFinancialAccountRequest(storeType,userId);

            managementFinancialAccountGetUseCase.Execute(request);

            Assert.True(request.ManagementFinancialAccount != null);
            Assert.True(!request.Logs.Any(c => c.TypeLog.Equals(TypeLog.Error)));
        }


        [Theory]
        [TestPriority(1)]
        [InlineData("No data found", "123", StoreType.TBRA)]
        public void GetManagementFinancialAccountNotFound(string message, string userId, StoreType storeType)
        {
            var request = new ManagementFinancialAccountRequest(storeType,userId);

            managementFinancialAccountGetUseCase.Execute(request);

            var output = request.Logs.Where(c => c.TypeLog.Equals(TypeLog.Processing) && c.Message.Contains(message));

            Assert.True(output != null);

        }
    }
}
