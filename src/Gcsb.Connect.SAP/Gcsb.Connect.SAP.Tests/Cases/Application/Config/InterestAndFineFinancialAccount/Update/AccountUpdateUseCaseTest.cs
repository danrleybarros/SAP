using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount;
using Domain = Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using System;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Update;
using Autofac;
using Gcsb.Connect.SAP.Tests.Builders.Config.InterestAndFineFinancialAccount;
using Xunit;
using System.Linq;
using Gcsb.Connect.Messaging.Messages.Log.Enum;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.InterestAndFineFinancialAccount.Update
{
    public class AccountUpdateUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IUseCase<AccountUpdateRequest> useCase;
        private readonly IInterestAndFineFinancialAccountWriteOnlyRepository interestAndFineFinancialAccountWriteOnlyRepository;
        private Domain::InterestAndFineFinancialAccount interestAndFineFinancialAccount;
        private readonly Guid Id = Guid.NewGuid();

        public AccountUpdateUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            useCase = fixture.Container.Resolve<IUseCase<AccountUpdateRequest>>();
            interestAndFineFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IInterestAndFineFinancialAccountWriteOnlyRepository>();
        }

        private void AddMock()
        {
            interestAndFineFinancialAccount = InterestAndFineFinancialAccountBuilder.New().WithId(Id).Build();
            interestAndFineFinancialAccountWriteOnlyRepository.Add(interestAndFineFinancialAccount);
        }

        [Theory]
        [InlineData("123")]
        public void ShouldUpdateFinancialAccount(string userId)
        {
            AddMock();

            var request = new AccountUpdateRequest(userId, interestAndFineFinancialAccount);

            useCase.Execute(request);

            Assert.True(!request.Logs.Any(c => c.TypeLog.Equals(TypeLog.Error)));

        }
    }
}
