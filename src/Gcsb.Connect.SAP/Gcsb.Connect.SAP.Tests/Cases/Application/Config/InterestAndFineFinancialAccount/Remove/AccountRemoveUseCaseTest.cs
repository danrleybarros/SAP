using Autofac;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Remove;
using Gcsb.Connect.SAP.Tests.Builders.Config.InterestAndFineFinancialAccount;
using System;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.InterestAndFineFinancialAccount.Remove
{
    public class AccountRemoveUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IUseCase<AccountRemoveRequest> useCase;
        private readonly IInterestAndFineFinancialAccountWriteOnlyRepository interestAndFineFinancialAccountWriteOnlyRepository;
        private readonly Guid Id = Guid.NewGuid();

        public AccountRemoveUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            useCase = fixture.Container.Resolve<IUseCase<AccountRemoveRequest>>();
            interestAndFineFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IInterestAndFineFinancialAccountWriteOnlyRepository>();
        }

        private void AddMock()
        {
            var interestAndFineFinancialAccount = InterestAndFineFinancialAccountBuilder.New().WithId(Id).Build();
            interestAndFineFinancialAccountWriteOnlyRepository.Add(interestAndFineFinancialAccount);
        }

        [Theory]
        [InlineData("123")]
        public void ShouldRemoveFinancialAccount(string userId)
        {
            AddMock();

            var request = new AccountRemoveRequest(Id, userId);

            useCase.Execute(request);

            Assert.True(!request.Logs.Any(c => c.TypeLog.Equals(TypeLog.Error)));
        }
    }
}
