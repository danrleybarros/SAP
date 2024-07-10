using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.Config.CreditGrantedFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.GetByStore;
using Gcsb.Connect.SAP.Tests.Builders.Config.CreditGrantedFinancialAccount;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.CreditGrantedFinancialAccount.GetByStore
{
    public class GetByStoreUseCaseTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IGetByStoreUseCase useCase;
        private readonly ICreditGrantedFinancialAccountWriteOnlyRepository writeOnlyRepository;

        public GetByStoreUseCaseTests(Fixture.ApplicationFixture fixture)
        {
            useCase = fixture.Container.Resolve<IGetByStoreUseCase>();
            writeOnlyRepository = fixture.Container.Resolve<ICreditGrantedFinancialAccountWriteOnlyRepository>();
            Fixture.ApplicationFixture.ClearCreditGrantedFinancialAccounts();
        }

        [Fact]
        public void ShouldGetNotFound()
        {
            var request = new GetByStoreRequest(SAP.Domain.JSDN.Stores.StoreType.TBRA);
            useCase.Execute(request);
            request.Output.Should().BeNull();
        }

        [Fact]
        public void ShouldGetAccount()
        {
            writeOnlyRepository.Add(CreditGrantedFinancialAccountBuilder.New().Build());
            var request = new GetByStoreRequest(SAP.Domain.JSDN.Stores.StoreType.TBRA);
            useCase.Execute(request);
            request.Output.Should().NotBeNull();
        }
    }
}
