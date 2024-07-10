
using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Add;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Tests.Builders.HttpContext;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount.Add;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.WebApi.Controllers.ManagementFinancialAccount.Add
{
    public class ManagementFinancialAccountControllerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IdentityParser identity;
        private readonly IManagementFinancialAccountAddUseCase managementFinancialAccountAddUseCase;
        private readonly ManagementFinancialAccountPresenter presenter;
        private readonly IManagementFinancialAccountReadOnlyRepository managementFinancialAccountReadOnlyRepository;
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;


        public ManagementFinancialAccountControllerTest(Fixture.ApplicationFixture fixture)
        {
            this.managementFinancialAccountAddUseCase = fixture.Container.Resolve<IManagementFinancialAccountAddUseCase>();
            this.presenter = fixture.Container.Resolve<ManagementFinancialAccountPresenter>();
            this.identity = fixture.Container.Resolve<IdentityParser>();
            this.managementFinancialAccountReadOnlyRepository = fixture.Container.Resolve<IManagementFinancialAccountReadOnlyRepository>();
            this.managementFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();
        }


        private void RemoveManagementFinancialAccount()
        {
            var model = managementFinancialAccountReadOnlyRepository.GetAll();

            managementFinancialAccountWriteOnlyRepository.RemoveAll(model);
        }


        [Fact]
        public void ShouldAddManagementFinancialAccount()
        {
            RemoveManagementFinancialAccount();

            var boleto = BoletoBuilder.New().Build();
            var creditCard = CreditCardBuilder.New().Build();
            var critic = CriticBuilder.New().Build();
            var transferred = TransferBuilder.New().Build();
            var Unassigned = UnassignedBuilder.New().Build();

            var request = new ManagementFinancialAccountAddRequest()
            {
                Boleto = new SAP.WebApi.Config.Model.ManagementFinancialAccount.Boleto(boleto.FinancialAccount, boleto.AccountingAccount.Credit, boleto.AccountingAccount.Debit),
                CreditCard = new SAP.WebApi.Config.Model.ManagementFinancialAccount.CreditCard(creditCard.FinancialAccount, creditCard.AccountingAccount.Credit, creditCard.AccountingAccount.Debit),
                Critic = new SAP.WebApi.Config.Model.ManagementFinancialAccount.Critic(critic.FinancialAccount, critic.AccountingAccount.Credit, critic.AccountingAccount.Debit),
                Transferred = new SAP.WebApi.Config.Model.ManagementFinancialAccount.Transferred(transferred.FinancialAccount, transferred.AccountingAccount.Credit, transferred.AccountingAccount.Debit),
                Unassigned = new SAP.WebApi.Config.Model.ManagementFinancialAccount.Unassigned(Unassigned.FinancialAccount, Unassigned.AccountingAccount.Credit, Unassigned.AccountingAccount.Debit)
            };

            var controller = new ManagementFinancialAccountController(identity, managementFinancialAccountAddUseCase, presenter);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.Add(request);

            Assert.True(output.GetType() == typeof(OkObjectResult));
        }
    }
}
