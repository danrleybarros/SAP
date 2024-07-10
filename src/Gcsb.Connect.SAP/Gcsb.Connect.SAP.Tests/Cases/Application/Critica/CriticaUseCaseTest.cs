using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Pay.Critical;
using Gcsb.Connect.SAP.Application.UseCases.Critical;
using Gcsb.Connect.SAP.Application.UseCases.Critical.RequestHandlers;
using Gcsb.Connect.SAP.Domain.PAY;
using Gcsb.Connect.SAP.Tests.Builders.PAY;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Critica
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class CriticaUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly AccountsHandler accountsHandler;
        private readonly CriticaHandler criticaHandler;
        private readonly GetAccountingEntryHandler getAccountingEntryHandler;
        private readonly LaunchHandler launchHandler;
        private readonly ICriticaUseCase criticaUseCase;

        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteRepo;
        private readonly ICriticaWriteRepository criticaWriteRepository;
        private static Guid IdPaymentFeed = Guid.NewGuid();

        public CriticaUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            accountsHandler = fixture.Container.Resolve<AccountsHandler>();
            criticaHandler = fixture.Container.Resolve<CriticaHandler>();
            getAccountingEntryHandler = fixture.Container.Resolve<GetAccountingEntryHandler>();
            launchHandler = fixture.Container.Resolve<LaunchHandler>();

            managementFinancialAccountWriteRepo = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();
            criticaWriteRepository = fixture.Container.Resolve<ICriticaWriteRepository>();
            criticaUseCase = fixture.Container.Resolve<ICriticaUseCase>();

            accountsHandler.SetSucessor(getAccountingEntryHandler);
            getAccountingEntryHandler.SetSucessor(criticaHandler);
            criticaHandler.SetSucessor(launchHandler);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(1)]
        public void RepoFinancialAccountAddManyTest()
        {
            Guid ret = managementFinancialAccountWriteRepo.Add(Fixture.ApplicationFixture.ManagementFinancialsAccount());
            Assert.True(ret != Guid.Empty);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(2)]
        public void RepoCriticalAddManyTest()
        {
            var listCritical = new List<Critical>()
            {
                CriticalBuilder.New().WithIdFile(IdPaymentFeed).WithBankCode("005").WithInvoiceAmount(50).Build(),
                CriticalBuilder.New().WithIdFile(IdPaymentFeed).WithBankCode("005").WithInvoiceAmount(100).Build(),
                CriticalBuilder.New().WithIdFile(IdPaymentFeed).WithBankCode("010").WithInvoiceAmount(200).Build(),
            };

            Assert.True(criticaWriteRepository.Add(listCritical) > 0);
        }

        [Fact]
        [TestPriority(3)]
        public void ShouldExecuteCriticaUseCase()
        {
            var registerDate = DateTime.Now;
            var request = new CriticaRequest(IdPaymentFeed);

            criticaUseCase.Execute(request);
            Assert.True(request.LaunchItems.Count > 0);
            Assert.True(request.LaunchItems.Count(f => f.LaunchDate.Date == registerDate.Date) == 4) ;
        }
    }
}
