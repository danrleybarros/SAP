using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers;
using Gcsb.Connect.SAP.Tests.Builders.Config;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.CounterChargeDispute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.CounterchargeDispute.RequestHandlers
{
    public class DigitalCertificateHandlerTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly DigitalCertificateLaunchHandler digitalCertificateLaunchHandler;

        public DigitalCertificateHandlerTests(Fixture.ApplicationFixture fixture)
        {
            this.digitalCertificateLaunchHandler = fixture.Container.Resolve<DigitalCertificateLaunchHandler>();
        }

        [Fact]
        public void ShouldHaveContestedValueNotEmittedPaid()
        {
            var financialAccount = FinancialAccountBuilder.New()
                .WithFaturamentoAJU("FAT000001")
                .WithServiceCode("SerasaCertificadoDigital")
                .WithContaContabilProdutoNaoEmitidoPagoCred("NaoEmitidoPagoCred")
                .WithContaContabilProdutoNaoEmitidoPagoDeb("NaoEmitidoPagoDeb")
                .Build();

            var counterchargeDispute = CounterchargeDisputeBuilder.New()
                .WithTipoSubscricao("SAAS")
                .WithNumeroPedido(12345)
                .WithCodigoServico("SerasaCertificadoDigital")
                .WithValorContestado(120)
                .WithFinancialAccount(financialAccount)
                .WithStatusPagamento("Pago")
                .WithActivityType("Adjustment")
                .Build();

            var request = new SAP.Application.UseCases.CounterchargeDispute.CounterchargeDisputeRequest(DateTime.Now, DateTime.Now)
            {
                CounterchargeDisputesAdjustment = new List<SAP.Domain.JSDN.CounterChargeDispute.CounterchargeDispute> { counterchargeDispute },
                ServiceAccountingAccountNotEmittedPaid = new List<SAP.Domain.AJU.ServiceAccountingAccountAJU>()
                {
                   new SAP.Domain.AJU.ServiceAccountingAccountAJU("FAT000001", SAP.Domain.AJU.TypeAccounting.Credito,"NaoEmitidoPagoCred"),
                   new SAP.Domain.AJU.ServiceAccountingAccountAJU("FAT000001", SAP.Domain.AJU.TypeAccounting.Debito,"NaoEmitidoPagoDeb")
                }
            };

            digitalCertificateLaunchHandler.ProcessRequest(request);

            var lines = request.Lines.SelectMany(s => s.Value).ToList();

            lines.Should().HaveCount(12);
            lines.FirstOrDefault().LaunchValue.Should().Be(20);
            lines.Where(w => w.AccountingAccount == "NaoEmitidoPagoCred").Should().HaveCount(6);
            lines.Where(w => w.AccountingAccount == "NaoEmitidoPagoDeb").Should().HaveCount(6);


        }

        [Fact]
        public void ShouldHaveContestedValueNotEmittedNotPaid()
        {
            var financialAccount = FinancialAccountBuilder.New()
                .WithFaturamentoAJU("FAT000001")
                .WithServiceCode("SerasaCertificadoDigital")
                .WithContaContabilProdutoNaoEmitidoPagoCred("NaoEmitidoNaoPagoCred")
                .WithContaContabilProdutoNaoEmitidoPagoDeb("NaoEmitidoNaoPagoDeb")
                .Build();

            var counterchargeDispute = CounterchargeDisputeBuilder.New()
                .WithTipoSubscricao("SAAS")
                .WithNumeroPedido(23456)
                .WithCodigoServico("SerasaCertificadoDigital")
                .WithValorContestado(100)
                .WithFinancialAccount(financialAccount)
                .WithStatusPagamento("Vencido")
                .WithActivityType("Adjustment")
                .Build();

            var request = new SAP.Application.UseCases.CounterchargeDispute.CounterchargeDisputeRequest(DateTime.Now, DateTime.Now)
            {
                CounterchargeDisputesAdjustment = new List<SAP.Domain.JSDN.CounterChargeDispute.CounterchargeDispute> { counterchargeDispute },
                ServiceAccountingAccountNotEmittedNotPaid = new List<SAP.Domain.AJU.ServiceAccountingAccountAJU>()
                {
                   new SAP.Domain.AJU.ServiceAccountingAccountAJU("FAT000001", SAP.Domain.AJU.TypeAccounting.Credito,"NaoEmitidoNaoPagoCred"),
                   new SAP.Domain.AJU.ServiceAccountingAccountAJU("FAT000001", SAP.Domain.AJU.TypeAccounting.Debito,"NaoEmitidoNaoPagoDeb")
                }
            };

            digitalCertificateLaunchHandler.ProcessRequest(request);

            var lines = request.Lines.SelectMany(s => s.Value).ToList();

            lines.Should().HaveCount(4);
            lines.FirstOrDefault().LaunchValue.Should().Be(50);
            lines.Where(w => w.AccountingAccount == "NaoEmitidoNaoPagoCred").Should().HaveCount(2);
            lines.Where(w => w.AccountingAccount == "NaoEmitidoNaoPagoDeb").Should().HaveCount(2);


        }


        [Theory]
        [InlineData(789456)]
        [InlineData(456654)]
        public void ShouldHaveContestedValueEmittedOrRevoke(int orderNumber)
        {
            var financialAccount = FinancialAccountBuilder.New()
                .WithFaturamentoAJU("FAT000001")
                .WithServiceCode("SerasaCertificadoDigital")
                .WithContaContabilContestacaoCred("123456")
                .WithContaContabilContestacaoDeb("654321")
                .WithContaContabilProdutoNaoEmitidoPagoCred("NaoEmitidoNaoPagoCred")
                .WithContaContabilProdutoNaoEmitidoPagoDeb("NaoEmitidoNaoPagoCred")
                .WithContaContabilProdutoNaoEmitidoPagoCred("NaoEmitidoPagoCred")
                .WithContaContabilProdutoNaoEmitidoPagoDeb("NaoEmitidoPagoDeb")
                .Build();

            var counterchargeDispute = CounterchargeDisputeBuilder.New()
               .WithTipoSubscricao("SAAS")
               .WithNumeroPedido(orderNumber)
               .WithCodigoServico("SerasaCertificadoDigital")
               .WithValorContestado(100)
               .WithFinancialAccount(financialAccount)
               .WithStatusPagamento("Vencido")
               .WithActivityType("Adjustment")
               .Build();


            var request = new SAP.Application.UseCases.CounterchargeDispute.CounterchargeDisputeRequest(DateTime.Now, DateTime.Now)
            {
                CounterchargeDisputesAdjustment = new List<SAP.Domain.JSDN.CounterChargeDispute.CounterchargeDispute> { counterchargeDispute },
                ServiceAccountingAccountNotEmittedNotPaid = new List<SAP.Domain.AJU.ServiceAccountingAccountAJU>()
                {

                   new SAP.Domain.AJU.ServiceAccountingAccountAJU("FAT000001", SAP.Domain.AJU.TypeAccounting.Credito,"NaoEmitidoNaoPagoCred"),
                   new SAP.Domain.AJU.ServiceAccountingAccountAJU("FAT000001", SAP.Domain.AJU.TypeAccounting.Debito,"NaoEmitidoNaoPagoCred")

                }
                ,
                ServiceAccountingAccountAdjusment = new List<SAP.Domain.AJU.ServiceAccountingAccountAJU>()
                {
                   new SAP.Domain.AJU.ServiceAccountingAccountAJU("FAT000001", SAP.Domain.AJU.TypeAccounting.Credito,"99999999","123456"),
                   new SAP.Domain.AJU.ServiceAccountingAccountAJU("FAT000001", SAP.Domain.AJU.TypeAccounting.Debito,"77777777","654321")
                }

            };

            digitalCertificateLaunchHandler.ProcessRequest(request);

            var lines = request.Lines.SelectMany(s => s.Value).ToList();

            lines.Should().HaveCount(2);
            lines.FirstOrDefault().LaunchValue.Should().Be(100);
            lines.Where(w => w.AccountingAccount == "123456").Should().HaveCount(1);
            lines.Where(w => w.AccountingAccount == "654321").Should().HaveCount(1);


        }
    }
}
