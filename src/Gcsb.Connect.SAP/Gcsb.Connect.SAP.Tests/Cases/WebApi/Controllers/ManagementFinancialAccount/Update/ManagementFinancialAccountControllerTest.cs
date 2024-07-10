using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Update;
using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Tests.Builders.HttpContext;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount.Update;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.WebApi.Controllers.ManagementFinancialAccount.Update
{
    public class ManagementFinancialAccountControllerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IdentityParser identity;
        private readonly IManagementFinancialAccountUpdateUseCase managementFinancialAccountUpdateUseCase;
        private readonly ManagementFinancialAccountPresenter presenter;
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;
        private readonly Guid Id = Guid.NewGuid();


        public ManagementFinancialAccountControllerTest(Fixture.ApplicationFixture fixture)
        {
            this.managementFinancialAccountUpdateUseCase = fixture.Container.Resolve<IManagementFinancialAccountUpdateUseCase>();
            this.managementFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();
            this.presenter = fixture.Container.Resolve<ManagementFinancialAccountPresenter>();
            this.identity = fixture.Container.Resolve<IdentityParser>();

            var context = new Context();
            context.Database.EnsureDeleted();
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

            var boleto = BoletoBuilder.New().WithFinancialAccount("Boleto001").Build();
            var creditCard = CreditCardBuilder.New().WithFinancialAccount("CreditCard002").Build();
            var critic = CriticBuilder.New().WithFinancialAccount("Critic003").Build();
            var transferred = TransferBuilder.New().WithFinancialAccount("Transf004").Build();
            var Unassigned = UnassignedBuilder.New().WithFinancialAccount("Un005").Build();

            var request = new ManagementFinancialUpdateRequest()
            {
                Id = Id,
                Boleto = new SAP.WebApi.Config.Model.ManagementFinancialAccount.Boleto(boleto.FinancialAccount, boleto.AccountingAccount.Credit, boleto.AccountingAccount.Debit),
                CreditCard = new SAP.WebApi.Config.Model.ManagementFinancialAccount.CreditCard(creditCard.FinancialAccount, creditCard.AccountingAccount.Credit, creditCard.AccountingAccount.Debit),
                Critic = new SAP.WebApi.Config.Model.ManagementFinancialAccount.Critic(critic.FinancialAccount, critic.AccountingAccount.Credit, critic.AccountingAccount.Debit),
                Transferred = new SAP.WebApi.Config.Model.ManagementFinancialAccount.Transferred(transferred.FinancialAccount, transferred.AccountingAccount.Credit, transferred.AccountingAccount.Debit),
                Unassigned = new SAP.WebApi.Config.Model.ManagementFinancialAccount.Unassigned(Unassigned.FinancialAccount, Unassigned.AccountingAccount.Credit, Unassigned.AccountingAccount.Debit)
            };


            var controller = new ManagementFinancialAccountController(identity, managementFinancialAccountUpdateUseCase, presenter);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();

            var output = controller.Update(request);

            Assert.True(output.GetType() == typeof(OkObjectResult));
        }
    }
}
