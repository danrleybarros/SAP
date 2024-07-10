using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.Config;
using Gcsb.Connect.SAP.Application.UseCases.Config.FinancialAccount.GetById;
using Gcsb.Connect.SAP.Tests.Builders.Config;
using Gcsb.Connect.SAP.Tests.Builders.HttpContext;
using Gcsb.Connect.SAP.Tests.Fixture;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccount.GetById;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.WebApi.Controllers.FinancialAccount.GetById
{
    public class FinancialAccountControllerTest : IClassFixture<Fixture.ApplicationFixture>
    {

        private readonly IdentityParser identity;
        private readonly FinancialAccountGetbyIdPresenter presenter;
        private readonly Guid Id = Guid.NewGuid();
        private readonly IFinancialAccountWriteOnlyRepository financialAccountWriteOnlyRepository;
        private readonly IFinancialAccountGetByIdUseCase financialAccountGetByIdUseCase;

        public FinancialAccountControllerTest(ApplicationFixture fixture)
        {
            this.presenter = fixture.Container.Resolve<FinancialAccountGetbyIdPresenter>();
            this.identity = fixture.Container.Resolve<IdentityParser>();
            this.financialAccountWriteOnlyRepository = fixture.Container.Resolve<IFinancialAccountWriteOnlyRepository>();
            this.financialAccountGetByIdUseCase = fixture.Container.Resolve<IFinancialAccountGetByIdUseCase>();
        }

        private void Mock()
        {
            var model = FinancialAccountBuilder.New().WithIdFinancialAccount(Id).Build();

            financialAccountWriteOnlyRepository.Add(model);
        }


        [Fact]
        public void ShouldAddManagementFinancialAccount()
        {
            Mock();

            var controller = new FinancialAccountController(identity, presenter, financialAccountGetByIdUseCase);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            controller.GetById(new FinancialAccountGetbyIdRequest { Id = Id });

            Assert.True(presenter.ViewModel.GetType() == typeof(OkObjectResult));
        }
    }
}
