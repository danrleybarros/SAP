using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.Config.CreditGrantedFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.Save;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Tests.Builders.Config.CreditGrantedFinancialAccount;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.CreditGrantedFinancialAccount.Save
{
    [UseAutofacTestFramework]
    public class SaveUseCaseTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly ISaveUseCase useCase;
        private readonly ICreditGrantedFinancialAccountReadOnlyRepository readOnlyRepository;
        private readonly ICreditGrantedFinancialAccountWriteOnlyRepository writeOnlyRepository;

        public SaveUseCaseTests(Fixture.ApplicationFixture fixture)
        {
            useCase = fixture.Container.Resolve<ISaveUseCase>();
            readOnlyRepository = fixture.Container.Resolve<ICreditGrantedFinancialAccountReadOnlyRepository>();
            writeOnlyRepository = fixture.Container.Resolve<ICreditGrantedFinancialAccountWriteOnlyRepository>();
            Fixture.ApplicationFixture.ClearCreditGrantedFinancialAccounts();
        }

        [Fact]
        public void ShouldAdd()
        {
            var request = new SaveRequest(CreditGrantedFinancialAccountBuilder.New().Build());
            useCase.Execute(request);
            var account = readOnlyRepository.GetByStore(StoreType.TBRA);
            account.Should().NotBeNull();
        }

        [Fact]
        public void ShouldUpdate()
        {
            var id = Guid.NewGuid();
            writeOnlyRepository.Add(CreditGrantedFinancialAccountBuilder.New().WithId(id).Build());
            var account = CreditGrantedFinancialAccountBuilder.New().WithId(id).WithCreditGrantedAJU("AJUUpd").Build();
            var request = new SaveRequest(account);
            useCase.Execute(request);
            var accountUpdated = readOnlyRepository.GetByStore(StoreType.TBRA);
            accountUpdated.CreditGrantedAJU.Should().Be("AJUUpd");
        }
    }
}
