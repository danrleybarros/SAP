using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Get;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Tests.Builders.HttpContext;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount.Get;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.WebApi.Controllers.ManagementFinancialAccount.Get
{
    public class ManagementFinancialAccountControllerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IdentityParser identity;
        private readonly IManagementFinancialAccountGetUseCase managementFinancialAccountGetUseCase;
        private readonly ManagementFinancialAccountPresenter presenter;
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;
        private readonly Guid Id = Guid.NewGuid();


        public ManagementFinancialAccountControllerTest(Fixture.ApplicationFixture fixture)
        {
            this.managementFinancialAccountGetUseCase = fixture.Container.Resolve<IManagementFinancialAccountGetUseCase>();
            this.managementFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();
            this.presenter = fixture.Container.Resolve<ManagementFinancialAccountPresenter>();
            this.identity = fixture.Container.Resolve<IdentityParser>();
        }

        private void AddMock()
        {
            var managementFinancialAccount = ManagementFinancialAccountBuilder.New().WithId(Id).Build();
            managementFinancialAccountWriteOnlyRepository.Add(managementFinancialAccount);
        }


        [Fact]
        public void ShouldAddManagementFinancialAccount()
        {
            AddMock();

            var controller = new ManagementFinancialAccountController(identity, managementFinancialAccountGetUseCase, presenter);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.Get(new ManagementFinancialAccountGetInput() { StoreType = StoreType.TBRA });

            Assert.True(output.GetType() == typeof(OkObjectResult));
        }
    }
}
