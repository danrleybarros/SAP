using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers;
using Gcsb.Connect.SAP.Tests.Builders.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.CounterchargeDispute.RequestHandlers
{
    public class ChargeBackLaunchHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly ChargeBackLaunchHandler chargeBackLaunchHandler;

        public ChargeBackLaunchHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.chargeBackLaunchHandler = fixture.Container.Resolve<ChargeBackLaunchHandler>(); 
        }

        [Fact]
        public void ShouldChargeBackTotalNotUsed()
        {
            var financialAccount = new List<SAP.Domain.Config.FinancialAccount>()
                {
                  FinancialAccountBuilder.New()
                  .WithServiceCode("0000000001")
                  .WithContaFaturaEstornoContestacao("CONTAESTORNO")
                  .WithContaContabilESTCredFuturoValorNUTILDeb("21152918")
                  .WithContaContabilESTCredFuturoValorNUTILCred("444444444")
                  .Build()
                };

            var request = new CounterchargeDisputeRequest(new DateTime(2021, 01, 21), new DateTime(2021, 02, 20))
            {
                FinancialAccounts = financialAccount
            };

            chargeBackLaunchHandler.ProcessRequest(request);

            var launch = request.Lines.SelectMany(s => s.Value).Where(w => w.FinancialAccount == "CONTAESTORNO").ToList();

            launch.Should().HaveCountGreaterThan(0);
            launch.Find(w => w.AccountingAccount == "21152918").LaunchValue.Should().Be(20);
            launch.Find(w => w.AccountingAccount == "444444444").LaunchValue.Should().Be(50);

        }

        [Fact]
        public void ShouldChargeBackTotalUsed()
        {
            var financialAccount = new List<SAP.Domain.Config.FinancialAccount>()
                {
                  FinancialAccountBuilder.New()
                  .WithServiceCode("0000000001")
                  .WithContaFaturaEstornoContestacao("CONTAESTORNO")
                  .WithContaContabilESTCredFuturoValorUTILDeb("999999999")
                  .WithContaContabilESTCredFuturoValorUTILCred("88888888")
                  .Build()

                };

            var request = new CounterchargeDisputeRequest(new DateTime(2021, 01, 21), new DateTime(2021, 02, 20))
            {
                FinancialAccounts = financialAccount
            };

            chargeBackLaunchHandler.ProcessRequest(request);

            var launch = request.Lines.SelectMany(s => s.Value).Where(w => w.FinancialAccount == "CONTAESTORNO").ToList();

            launch.Should().HaveCountGreaterThan(0);
            launch.Find(w => w.AccountingAccount == "999999999").LaunchValue.Should().Be(30);
            launch.Find(w => w.AccountingAccount == "88888888").LaunchValue.Should().Be(70);

        }

        [Fact]
        public void ShouldChargeBackPartialUsed()
        {
            var financialAccount = new List<SAP.Domain.Config.FinancialAccount>()
                {
                  FinancialAccountBuilder.New()
                  .WithServiceCode("0000000001")
                  .WithContaFaturaEstornoContestacao("CONTAESTORNO")
                  .WithContaContabilESTCredFuturoValorNUTILDeb("21152918")
                  .WithContaContabilESTCredFuturoValorNUTILCred("444444444")
                  .WithContaContabilESTCredFuturoValorUTILDeb("999999999")
                  .WithContaContabilESTCredFuturoValorUTILCred("88888888")
                  .Build()

                };

            var request = new CounterchargeDisputeRequest(new DateTime(2021, 01, 21), new DateTime(2021, 02, 20))
            {
                FinancialAccounts = financialAccount
            };

            chargeBackLaunchHandler.ProcessRequest(request);

            var launch = request.Lines.SelectMany(s => s.Value).Where(w => w.FinancialAccount == "CONTAESTORNO").ToList();

            launch.Should().HaveCountGreaterThan(0);
            launch.Find(w => w.AccountingAccount == "999999999").LaunchValue.Should().Be(30);
            launch.Find(w => w.AccountingAccount == "88888888").LaunchValue.Should().Be(70);

        }

        [Fact]
        public void ShouldChargeBackDebtGranted()
        {
            var financialAccount = new List<SAP.Domain.Config.FinancialAccount>()
                {
                  FinancialAccountBuilder.New()
                  .WithServiceCode("0000000001")
                  .WithContaFaturaDebitoConcedido("DEBCONCEDIDO")
                  .WithContaContabilDebitoConcedidoDeb("11215115")
                  .WithContaContabilDebitoConcedidoCred("2222222222222")
                  .Build()

                };

            var request = new CounterchargeDisputeRequest(new DateTime(2021, 01, 21), new DateTime(2021, 02, 20))
            {
                FinancialAccounts = financialAccount
            };

            chargeBackLaunchHandler.ProcessRequest(request);

            var launch = request.Lines.SelectMany(s => s.Value).Where(w => w.FinancialAccount == "DEBCONCEDIDO").ToList();
            launch.Should().HaveCountGreaterThan(0);
            launch.Find(w => w.AccountingAccount == "11215115").LaunchValue.Should().Be(50);
            launch.Find(w => w.AccountingAccount == "2222222222222").LaunchValue.Should().Be(20);

        }

        [Fact]
        public void ShouldChargeBackInvoiceNotPaid()
        {
            var financialAccount = new List<SAP.Domain.Config.FinancialAccount>()
                {
                  FinancialAccountBuilder.New()
                  .WithServiceCode("0000000001")
                  .WithContaFaturaEstornoContestacao("CONTAESTORNO")
                  .WithEstBoletoRetificadoCred("11215117")
                  .WithEstBoletoRetificadoDeb("11215118")
                  .Build()

                };

            var request = new CounterchargeDisputeRequest(new DateTime(2021, 01, 21), new DateTime(2021, 02, 20))
            {
                FinancialAccounts = financialAccount
            };

            chargeBackLaunchHandler.ProcessRequest(request);

            var launch = request.Lines.SelectMany(s => s.Value).Where(w => w.FinancialAccount == "CONTAESTORNO").ToList();
            launch.Should().HaveCountGreaterThan(0);
            launch.Find(w => w.AccountingAccount == "11215118").LaunchValue.Should().Be(20);
            launch.Find(w => w.AccountingAccount == "11215117").LaunchValue.Should().Be(25);            

        }

    }
}
