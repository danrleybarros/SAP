using Autofac;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Update;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using System;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.ManagementFinancialAccount.Update
{
    public class ManagementFinancialAccountUpdateUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IManagementFinancialAccountUpdateUseCase managementFinancialAccountUpdateUseCase;
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;
        private SAP.Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount managementFinancialAccount;
        private readonly Guid Id = Guid.NewGuid();


        public ManagementFinancialAccountUpdateUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.managementFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();
            managementFinancialAccountUpdateUseCase = fixture.Container.Resolve<IManagementFinancialAccountUpdateUseCase>();
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

            managementFinancialAccountUpdateUseCase.Execute(request);

            Assert.True(!request.Logs.Any(c => c.TypeLog.Equals(TypeLog.Error)));

        }
    }
}
