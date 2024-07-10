using Autofac;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Add;
using Gcsb.Connect.SAP.Tests.Builders.Config.InterestAndFineFinancialAccount;
using System;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.InterestAndFineFinancialAccount.Add
{
    public class AccountAddUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IUseCase<AccountAddRequest> useCase;
        private readonly IInterestAndFineFinancialAccountWriteOnlyRepository interestAndFineFinancialAccountWriteOnlyRepository;
        private readonly IInterestAndFineFinancialAccountReadOnlyRepository interestAndFineFinancialAccountReadOnlyRepository;

        public AccountAddUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.useCase = fixture.Container.Resolve<IUseCase<AccountAddRequest>>();
            interestAndFineFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IInterestAndFineFinancialAccountWriteOnlyRepository>();
            interestAndFineFinancialAccountReadOnlyRepository = fixture.Container.Resolve<IInterestAndFineFinancialAccountReadOnlyRepository>();
        }

        private void DeleteMock()
        {
            var financialAccounts = interestAndFineFinancialAccountReadOnlyRepository.GetAll();
            interestAndFineFinancialAccountWriteOnlyRepository.RemoveAll(financialAccounts);
        }

        [Theory]
        [InlineData("123")]
        public void ShouldCreateFinancialAccount(string userId)
        {
            DeleteMock();

            var request = new AccountAddRequest(userId, InterestAndFineFinancialAccountBuilder.New().WithId(Guid.NewGuid()).Build());

            useCase.Execute(request);

            Assert.True(!request.Logs.Any(c => c.TypeLog.Equals(TypeLog.Error)));
        }
    }
}
