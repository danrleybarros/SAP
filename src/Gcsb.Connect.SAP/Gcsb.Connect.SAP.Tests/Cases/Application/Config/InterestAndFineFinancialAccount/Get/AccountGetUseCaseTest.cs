using Autofac;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Get;
using Gcsb.Connect.SAP.Tests.Builders.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.InterestAndFineFinancialAccount.Get
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class AccountGetUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IUseCase<AccountGetRequest> useCase;
        private readonly IInterestAndFineFinancialAccountWriteOnlyRepository interestAndFineFinancialAccountWriteOnlyRepository;
        private readonly Guid Id = Guid.NewGuid();

        public AccountGetUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            useCase = fixture.Container.Resolve<IUseCase<AccountGetRequest>>();
            interestAndFineFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IInterestAndFineFinancialAccountWriteOnlyRepository>();
        }

        private void AddMock()
        {
            var interestAndFineFinancialAccount = InterestAndFineFinancialAccountBuilder.New().WithId(Id).Build();
            interestAndFineFinancialAccountWriteOnlyRepository.Add(interestAndFineFinancialAccount);
        }

        [Theory]
        [TestPriority(0)]
        [InlineData("123")]
        public void ShouldGetFinancialAccount(string userId)
        {
            AddMock();

            var request = new AccountGetRequest(userId, SAP.Domain.JSDN.Stores.StoreType.TBRA);

            useCase.Execute(request);

            Assert.True(request.InterestAndFineFinancialAccount != null);
            Assert.True(!request.Logs.Any(c => c.TypeLog.Equals(TypeLog.Error)));
        }

        [Theory]
        [TestPriority(1)]
        [InlineData("No data found", "123")]
        public void GetFinancialAccountNotFound(string message, string userId)
        {
            var request = new AccountGetRequest(userId, SAP.Domain.JSDN.Stores.StoreType.TBRA);

            useCase.Execute(request);

            var output = request.Logs.Where(c => c.TypeLog.Equals(TypeLog.Processing) && c.Message.Contains(message));

            Assert.True(output != null);

        }
    }
}
