using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.CounterChargeDispute;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Tests.Mock
{
    public class JsdnRepositoryMock
    {
        public Mock<IJsdnRepository> Execute()
        {
            var mockJsdnRepository = new Mock<IJsdnRepository>();

            mockJsdnRepository.Setup(i => i.GetAllCounterchargeDispute(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(new List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute>
                {
                    CounterchargeDisputeBuilder.New()
                    .WithCodigoServico("Office65Business")
                    .WithDataConcessaoCredito(DateTime.UtcNow)
                    .WithMetodoPagamento("Credit Card")
                    .WithTipoSubscricao("SAAS")
                    .WithValorContestado(100)
                    .WithUF("SP")
                    .WithDataIniciodoCiclo(DateTime.UtcNow)
                    .WithTipoDisputa("Future Account")
                    .WithTipoTransacao("Adjustment")
                    .Build(),
                    CounterchargeDisputeBuilder.New()
                    .WithCodigoServico("Office65Business")
                    .WithDataConcessaoCredito(DateTime.UtcNow)
                    .WithMetodoPagamento("Boleto")
                    .WithTipoSubscricao("IAAS")
                    .WithValorContestado(50)
                    .WithUF("MT")
                    .WithDataIniciodoCiclo(DateTime.UtcNow)
                    .WithTipoTransacao("Adjustment")
                    .WithTipoDisputa("Rectified Boleto")
                    .Build(),
                    CounterchargeDisputeBuilder.New()
                    .WithCodigoServico("PowerBIPro")
                    .WithDataConcessaoCredito(DateTime.UtcNow)
                    .WithMetodoPagamento("Credit Card")
                    .WithTipoSubscricao("SAAS")
                    .WithValorContestado(30)
                    .WithTipoDisputa("Future Account")
                    .WithUF("SP")
                    .WithTipoTransacao("Adjustment")
                    .WithDataIniciodoCiclo(DateTime.UtcNow)
                    .Build()
                });

            mockJsdnRepository.Setup(i => i.GetAllCounterchargeDisputeBilling(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(new List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute>
                {
                    CounterchargeDisputeBuilder.New()
                    .WithCodigoServico("Office65Business")
                    .WithDataConcessaoCredito(DateTime.UtcNow)
                    .WithMetodoPagamento("Credit Card")
                    .WithTipoSubscricao("SAAS")
                    .WithValorContestado(100)
                    .WithUF("SP")
                    .WithDataIniciodoCiclo(DateTime.UtcNow)
                    .WithTipoDisputa("Future Account")
                    .WithTipoTransacao("Billing")
                    .Build(),
                    CounterchargeDisputeBuilder.New()
                    .WithCodigoServico("Office65Business")
                    .WithDataConcessaoCredito(DateTime.UtcNow)
                    .WithMetodoPagamento("Boleto")
                    .WithTipoSubscricao("IAAS")
                    .WithValorContestado(50)
                    .WithUF("MT")
                    .WithDataIniciodoCiclo(DateTime.UtcNow)
                    .WithTipoTransacao("Billing")
                    .WithTipoDisputa("Rectified Boleto")
                    .Build(),
                    CounterchargeDisputeBuilder.New()
                    .WithCodigoServico("PowerBIPro")
                    .WithDataConcessaoCredito(DateTime.UtcNow)
                    .WithMetodoPagamento("Credit Card")
                    .WithTipoSubscricao("SAAS")
                    .WithValorContestado(30)
                    .WithTipoDisputa("Future Account")
                    .WithUF("SP")
                    .WithTipoTransacao("Billing")
                    .WithDataIniciodoCiclo(DateTime.UtcNow)
                    .Build(),
                    CounterchargeDisputeBuilder.New()
                    .WithCodigoServico("PowerBIPro")
                    .WithDataConcessaoCredito(DateTime.UtcNow)
                    .WithMetodoPagamento("Credit Card")
                    .WithTipoSubscricao("SAAS")
                    .WithValorContestado(30)
                    .WithTipoDisputa("Future Account")
                    .WithUF("SP")
                    .WithTipoTransacao("Billing")
                    .WithDataIniciodoCiclo(DateTime.UtcNow)
                    .WithActivityType("Payment Credit")
                    .Build(),
                    CounterchargeDisputeBuilder.New()
                    .WithCodigoServico("PowerBIPro")
                    .WithDataConcessaoCredito(DateTime.UtcNow)
                    .WithMetodoPagamento("Credit Card")
                    .WithTipoSubscricao("SAAS")
                    .WithValorContestado(30)
                    .WithTipoDisputa("Future Account")
                    .WithUF("SP")
                    .WithTipoTransacao("Billing")
                    .WithDataIniciodoCiclo(DateTime.UtcNow)
                    .WithActivityType("Interest")
                    .Build(),
                    CounterchargeDisputeBuilder.New()
                    .WithCodigoServico("PowerBIPro")
                    .WithDataConcessaoCredito(DateTime.UtcNow)
                    .WithMetodoPagamento("Credit Card")
                    .WithTipoSubscricao("SAAS")
                    .WithValorContestado(30)
                    .WithTipoDisputa("Future Account")
                    .WithUF("SP")
                    .WithTipoTransacao("Billing")
                    .WithDataIniciodoCiclo(DateTime.UtcNow)
                    .WithActivityType("Fine")
                    .Build(),
                });

            mockJsdnRepository.Setup(i => i.GetCounterChargeDisputeByCycle(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
             .Returns(new List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute>
             {
                 #region TotalNotUsed(
                 CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00031867")
                 .WithTipoTransacao("Payment")
                 .WithValorTransacao(100)
                 .WithStatusPagamento("Pago")
                 .WithCodigoServico("0000000001")
                 .WithDataMovimentacao(new DateTime(2021, 01, 25))
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00031867")
                 .WithStatusPagamento("Pago")
                 .WithTipoTransacao("Adjustment")
                 .WithActivityType("Credits")
                 .WithCodigoServico("0000000001")
                 .WithValorContestado(70)
                 .WithDataMovimentacao(new DateTime(2021, 02, 12))
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00031867")
                 .WithStatusPagamento("Pago")
                 .WithTipoTransacao("Adjust Reversal")
                 .WithCodigoServico("0000000001")
                 .WithActivityType("Countercharge Chargeback")
                 .WithValorTransacao(20)
                 .WithDataMovimentacao(new DateTime(2021, 02, 14))
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00041867")
                 .WithTipoTransacao("Payment")
                 .WithValorTransacao(100)
                 .WithStatusPagamento("Pago")
                 .WithCodigoServico("0000000001")
                 .WithDataMovimentacao(new DateTime(2021, 01, 25))
                 .WithAReceber("SPJURTBRAC")
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00041867")
                 .WithStatusPagamento("Pago")
                 .WithTipoTransacao("Adjustment")
                 .WithActivityType("Credits")
                 .WithCodigoServico("0000000001")
                 .WithValorContestado(70)
                 .WithDataMovimentacao(new DateTime(2021, 02, 12))
                 .WithAReceber("SPJURTBRAC")
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00041867")
                 .WithStatusPagamento("Pago")
                 .WithTipoTransacao("Adjust Reversal")
                 .WithCodigoServico("0000000001")
                 .WithActivityType("Countercharge Chargeback")
                 .WithValorTransacao(20)
                 .WithDataMovimentacao(new DateTime(2021, 02, 14))
                 .WithAReceber("SPJURTBRAC")
                 .Build(),
                  #endregion

                 #region TotalUsed                 
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00031868")
                 .WithTipoTransacao("Adjust Reversal")
                 .WithCodigoServico("0000000001")
                 .WithActivityType("Countercharge Chargeback")
                 .WithValorTransacao(30)
                 .WithDataMovimentacao(new DateTime(2021, 02, 28))
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00031868")
                 .WithTipoTransacao("Billing")
                 .WithCodigoServico("0000000001")
                 .WithValorContestado(100)
                 .WithDataMovimentacao(new DateTime(2021, 02, 28))
                 .Build(),

                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00041868")
                 .WithTipoTransacao("Adjust Reversal")
                 .WithCodigoServico("0000000001")
                 .WithActivityType("Countercharge Chargeback")
                 .WithValorTransacao(30)
                 .WithDataMovimentacao(new DateTime(2021, 02, 28))
                 .WithAReceber("SPJURTBRAC")
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00041868")
                 .WithTipoTransacao("Billing")
                 .WithCodigoServico("0000000001")
                 .WithValorContestado(50)
                 .WithDataMovimentacao(new DateTime(2021, 02, 28))
                 .WithAReceber("SPJURTBRAC")
                 .Build(),
                  #endregion                 

                 #region DebtGranted                
                 CounterchargeDisputeBuilder.New()
                .WithNumeroFatura("VVL-1-00031869")
                .WithTipoTransacao("Adjust Reversal")
                .WithStatusPagamento("Pago")
                .WithCodigoServico("0000000001")
                .WithActivityType("Countercharge Chargeback")
                .WithValorTransacao(50)
                .WithDataMovimentacao(new DateTime(2021, 02, 28))
                .Build(),
                 CounterchargeDisputeBuilder.New()
                .WithNumeroFatura("VVL-1-00041869")
                .WithTipoTransacao("Adjust Reversal")
                .WithStatusPagamento("Pago")
                .WithCodigoServico("0000000001")
                .WithActivityType("Countercharge Chargeback")
                .WithValorTransacao(50)
                .WithDataMovimentacao(new DateTime(2021, 02, 28))
                .WithAReceber("SPJURTBRAC")
                .Build(),
                 #endregion

                 #region PartialUsed               
                 CounterchargeDisputeBuilder.New()
                .WithNumeroFatura("VVL-1-00031870")
                .WithTipoTransacao("Adjust Reversal")
                .WithCodigoServico("0000000001")
                .WithActivityType("Countercharge Chargeback")
                .WithValorTransacao(30)
                .WithDataMovimentacao(new DateTime(2021, 02, 28))
                .Build(),
                 CounterchargeDisputeBuilder.New()
                .WithNumeroFatura("VVL-1-00031870")
                .WithTipoTransacao("Billing")
                .WithCodigoServico("0000000001")
                .WithValorContestado(20)
                .WithDataMovimentacao(new DateTime(2021, 02, 28))
                .Build(),
                 #endregion 

                 #region RectifiedBoleto
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00031871")
                 .WithTipoTransacao("Payment")
                 .WithValorTransacao(80)
                 .WithStatusPagamento("Vencido")
                 .WithCodigoServico("0000000001")
                 .WithDataMovimentacao(new DateTime(2021, 01, 25))
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00031871")
                 .WithTipoTransacao("Adjustment")
                 .WithActivityType("Credits")
                 .WithCodigoServico("0000000001")
                 .WithValorContestado(45)
                 .WithDataMovimentacao(new DateTime(2021, 02, 12))
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00031871")
                 .WithTipoTransacao("Adjust Reversal")
                 .WithValorContestado(15)
                 .WithCodigoServico("0000000001")
                 .WithActivityType("Countercharge Chargeback")
                 .WithTipoDisputa("Rectified Boleto")
                 .WithValorTransacao(20)
                 .WithDataMovimentacao(new DateTime(2021, 02, 14))
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00041871")
                 .WithTipoTransacao("Payment")
                 .WithValorTransacao(80)
                 .WithStatusPagamento("Vencido")
                 .WithCodigoServico("0000000001")
                 .WithDataMovimentacao(new DateTime(2021, 01, 25))
                 .WithAReceber("SPJURTBRAC")
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00041871")
                 .WithTipoTransacao("Adjustment")
                 .WithActivityType("Credits")
                 .WithCodigoServico("0000000001")
                 .WithValorContestado(45)
                 .WithDataMovimentacao(new DateTime(2021, 02, 12))
                 .WithAReceber("SPJURTBRAC")
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00041871")
                 .WithTipoTransacao("Adjust Reversal")
                 .WithValorContestado(15)
                 .WithCodigoServico("0000000001")
                 .WithActivityType("Countercharge Chargeback")
                 .WithTipoDisputa("Rectified Boleto")
                 .WithValorTransacao(20)
                 .WithDataMovimentacao(new DateTime(2021, 02, 14))
                 .WithAReceber("SPJURTBRAC")
                 .Build(),
               #endregion
             });


            mockJsdnRepository.Setup(i => i.GetCounterchargeDisputeByInvoice(It.IsAny<List<string>>()))
             .Returns(new List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute>
             {
                  #region TotalUsed
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00031868")
                 .WithTipoTransacao("Payment")
                 .WithStatusPagamento("Pago")
                 .WithValorTransacao(150)
                 .WithCodigoServico("0000000001")
                 .WithDataMovimentacao(new DateTime(2021, 01, 25))
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00031868")
                 .WithTipoTransacao("Adjustment")
                 .WithStatusPagamento("Pago")
                 .WithValorContestado(100)
                 .WithActivityType("Credits")
                 .WithCodigoServico("0000000001")
                 .WithDataMovimentacao(new DateTime(2021, 02, 22))
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00041868")
                 .WithTipoTransacao("Payment")
                 .WithStatusPagamento("Pago")
                 .WithValorTransacao(50)
                 .WithCodigoServico("0000000001")
                 .WithDataMovimentacao(new DateTime(2021, 01, 25))
                 .WithAReceber("SPJURTBRAC")
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00041868")
                 .WithTipoTransacao("Adjustment")
                 .WithStatusPagamento("Pago")
                 .WithValorContestado(50)
                 .WithActivityType("Credits")
                 .WithCodigoServico("0000000001")
                 .WithDataMovimentacao(new DateTime(2021, 02, 22))
                 .WithAReceber("SPJURTBRAC")
                 .Build(),
                 #endregion

                  #region DebtGranted  
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00031869")
                 .WithStatusPagamento("Pago")
                 .WithTipoTransacao("Payment")
                 .WithValorTransacao(100)
                 .WithCodigoServico("0000000001")
                 .WithDataMovimentacao(new DateTime(2021, 01, 25))
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00031869")
                 .WithStatusPagamento("Pago")
                 .WithTipoTransacao("Adjustment")
                 .WithActivityType("Credits")
                 .WithCodigoServico("0000000001")
                 .WithValorContestado(70)
                 .WithDataMovimentacao(new DateTime(2021, 02, 12))
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00041869")
                 .WithStatusPagamento("Pago")
                 .WithTipoTransacao("Payment")
                 .WithValorTransacao(100)
                 .WithCodigoServico("0000000001")
                 .WithDataMovimentacao(new DateTime(2021, 01, 25))
                 .WithAReceber("SPJURTBRAC")
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00041869")
                 .WithStatusPagamento("Pago")
                 .WithTipoTransacao("Adjustment")
                 .WithActivityType("Credits")
                 .WithCodigoServico("0000000001")
                 .WithValorContestado(70)
                 .WithDataMovimentacao(new DateTime(2021, 02, 12))
                 .WithAReceber("SPJURTBRAC")
                 .Build(),
                 #endregion

                  #region PartialUsed    
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00031870")
                 .WithStatusPagamento("Pago")
                 .WithTipoTransacao("Payment")
                 .WithValorTransacao(100)
                 .WithCodigoServico("0000000001")
                 .WithDataMovimentacao(new DateTime(2021, 01, 25))
                 .Build(),
                  CounterchargeDisputeBuilder.New()
                 .WithNumeroFatura("VVL-1-00031870")
                 .WithStatusPagamento("Pago")
                 .WithTipoTransacao("Adjustment")
                 .WithActivityType("Credits")
                 .WithCodigoServico("0000000001")
                 .WithValorContestado(70)
                 .WithDataMovimentacao(new DateTime(2021, 02, 12))
                 .Build(),
                 #endregion

             });

            mockJsdnRepository.Setup(i => i.GetPaymentReportsByInvoices(It.IsAny<List<string>>()))
             .Returns(new List<Domain.JSDN.PaymentReport>
             {
                PaymentReportBuilder.New()
                .WithServiceCode("MSintune")                
                .WithStoreAcronym("telerese")
                .WithProviderCompanyAcronym("telerese")
                .WithInvoiceNumber("VVL-2-00002261")
                .WithPaymentValue(100)
                .Build(),

                PaymentReportBuilder.New()
                .WithServiceCode("MicrosoftPowerAppsPlan2")
                .WithStoreAcronym("telerese")
                .WithProviderCompanyAcronym("telerese")
                .WithInvoiceNumber("VVL-2-00001980")
                .WithPaymentValue(100)
                .Build(),
             });

            return mockJsdnRepository;
        }
    }
}
