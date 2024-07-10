using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.Config.CreditGrantedFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.GetAll;
using Gcsb.Connect.SAP.Tests.Builders.Config.CreditGrantedFinancialAccount;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.CreditGrantedFinancialAccount.GetAll
{
    [UseAutofacTestFramework]
    public class GetAllUseCaseTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IGetAllUseCase useCase;
        private readonly ICreditGrantedFinancialAccountWriteOnlyRepository writeOnlyRepository;

        public GetAllUseCaseTests(Fixture.ApplicationFixture fixture)
        {
            useCase = fixture.Container.Resolve<IGetAllUseCase>();
            writeOnlyRepository = fixture.Container.Resolve<ICreditGrantedFinancialAccountWriteOnlyRepository>();
        }

        [Fact]
        public void ShouldGetAccounts()
        {
            var account = CreditGrantedFinancialAccountBuilder.New().Build();
            writeOnlyRepository.Add(account);
            var request = new GetAllRequest();
            useCase.Execute(request);
            request.Output.Should().NotBeNull();
            request.Output.CreditGrantedFinancialAccounts.Should().NotBeEmpty();
        }
    }
}
