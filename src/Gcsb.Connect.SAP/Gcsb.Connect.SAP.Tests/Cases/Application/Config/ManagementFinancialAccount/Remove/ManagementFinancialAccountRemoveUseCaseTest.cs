using Autofac;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Remove;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using System;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.ManagementFinancialAccount.Remove
{
    public class ManagementFinancialAccountRemoveUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {     
        private readonly IManagementFinancialAccountRemoveUseCase managementFinancialAccountAddUseCase;
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;
        private readonly Guid Id = Guid.NewGuid();

        public ManagementFinancialAccountRemoveUseCaseTest(Fixture.ApplicationFixture fixture)
        {           
            managementFinancialAccountAddUseCase = fixture.Container.Resolve<IManagementFinancialAccountRemoveUseCase>();
            this.managementFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();

        }

        private void AddMock()
        {
           var managementFinancialAccount = ManagementFinancialAccountBuilder.New().WithId(Id).Build();
            managementFinancialAccountWriteOnlyRepository.Add(managementFinancialAccount);
        }


        [Theory]
        [InlineData("123")]
        public void ShouldRemoveMananagementFinancialAccount(string userId)
        {
           AddMock();

            var request = new ManagementFinancialAccountRequest(userId, Id);

            managementFinancialAccountAddUseCase.Execute(request);

            Assert.True(!request.Logs.Any(c => c.TypeLog.Equals(TypeLog.Error)));
        }
    }
}
