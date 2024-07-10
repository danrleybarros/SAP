using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.UseCases.ARR;
using Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.Boleto;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.ARR.Boleto;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Tests.Builders;
using Gcsb.Connect.SAP.Tests.Builders.ARR;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.ARR.ARRBOLETO.Handler
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("I")]
    public class LaunchHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        [Fact]
        public void ReturnFourLinesForOneAccount()
        {
            Guid idFilePayment = Guid.NewGuid();
            var transactionDate = DateTime.Now;

            ARRRequest<ARRBoleto> request = new ARRRequest<ARRBoleto>(TypeRegister.ARR, idFilePayment);

            request.Files.Add(FileBuilder.New().WithId(idFilePayment).Build());
            request.ARRDomain.Add(new ARRBoleto(request.Files[0]));

            request.paymentBoletos = new List<PaymentBoleto>
            {
                new PaymentBoletoBuilder()
                    .WithInvoiceNumberJsdn("TlA-1-00000001")
                    .WithCodigoBanco(341)
                    .WithTransactionDate(transactionDate)
                    .WithValorRecebido(100)
                    .Build(),
                new PaymentBoletoBuilder()
                    .WithInvoiceNumberJsdn("TlA-1-00000001")
                    .WithCodigoBanco(341)
                    .WithTransactionDate(transactionDate)
                    .WithValorRecebido(200)
                    .Build(),
                new PaymentBoletoBuilder()
                    .WithInvoiceNumberJsdn("TlA-1-00000001")
                    .WithCodigoBanco(10)
                    .WithTransactionDate(transactionDate)
                    .WithValorRecebido(100)
                    .Build(),
                new PaymentBoletoBuilder()
                    .WithInvoiceNumberJsdn("TlA-1-00000001")
                    .WithCodigoBanco(10)
                    .WithTransactionDate(transactionDate)
                    .WithValorRecebido(50)
                    .Build()
            };

            request.PaymentReports = new List<PaymentReport>()
            {
                PaymentReportBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")
                .WithInvoiceNumber(request.paymentBoletos[0].InvoiceNumberJsdn)
                .WithPaymentDate(transactionDate)
                .WithBankCode("341")
                .WithPaymentValue(100)
                .WithTotalPaymentValue(100)
                .Build(),

                PaymentReportBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")
                .WithInvoiceNumber(request.paymentBoletos[0].InvoiceNumberJsdn)
                .WithPaymentDate(transactionDate)
                .WithBankCode("341")
                .WithPaymentValue(200)
                .WithTotalPaymentValue(200)
                .Build(),

                PaymentReportBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")
                .WithInvoiceNumber(request.paymentBoletos[0].InvoiceNumberJsdn)
                .WithPaymentDate(transactionDate)
                .WithBankCode("10")
                .WithPaymentValue(100)
                .WithTotalPaymentValue(100)
                .Build(),

                PaymentReportBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")
                .WithInvoiceNumber(request.paymentBoletos[0].InvoiceNumberJsdn)
                .WithPaymentDate(transactionDate)
                .WithBankCode("10")
                .WithPaymentValue(50)
                .WithTotalPaymentValue(50)
                .Build()
            };

            request.Services = new List<ServiceFilter> 
            { 
                ServiceFilterBuilder.New()
                .WithInvoice(
                    InvoiceBuilder.New()
                    .WithInvoiceNumber(request.paymentBoletos[0].InvoiceNumberJsdn)
                    .WithStoreAcronym("telerese")
                    .Build())
                .WithStoreAcronym("telerese")
                .WithProviderCompanyAcronym("telerese")
                .Build() 
            };

            request.AccountingEntriesArrecadacao = new List<AccountingEntry>
            {
                AccountingEntryBuilder.New()
                .WithArrecadacaoARR("AAA")
                .WithAccountingEntryType("C")
                .WithAccountingAccount("accountCredit")
                .WithStore(StoreType.TBRA)
                .Build(),

                AccountingEntryBuilder.New()
                .WithArrecadacaoARR("AAA")
                .WithAccountingEntryType("D")
                .WithAccountingAccount("accountDebito")
                .WithStore(StoreType.TBRA)
                .Build()
            };

            request.AccountsARR = new List<AccountARR>
            {
                AccountARRBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")
                .WithArrecadacaoARR("AAA")
                .WithAccountingEntryType("C")
                .WithAccountingAccount("accountCredit")
                .WithStore(StoreType.TBRA)
                .WithProvider(StoreType.TBRA)
                .WithHaveIntercompany(false)
                .WithValidAccount(true)
                .Build(),

                AccountARRBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")
                .WithArrecadacaoARR("AAA")
                .WithAccountingEntryType("D")
                .WithAccountingAccount("accountDebito")
                .WithStore(StoreType.TBRA)
                .WithProvider(StoreType.TBRA)
                .WithHaveIntercompany(false)
                .WithValidAccount(true)
                .Build()
            };

            new LaunchHandler().ProcessRequest(request);

            var lines = request.Lines[StoreType.TBRA];

            Assert.True(lines.Count == 4);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("AAA") && p.Type == "BCO341" && p.AccountingEntry == "D").LaunchValue == 300);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("AAA") && p.Type == "BCO341" && p.AccountingEntry == "C").LaunchValue == 300);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("AAA") && p.Type == "BCO010" && p.AccountingEntry == "D").LaunchValue == 150);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("AAA") && p.Type == "BCO010" && p.AccountingEntry == "C").LaunchValue == 150);
        }

        [Fact]
        public void ReturnTwoLinesForOneAccount()
        {
            var dateNow = DateTime.UtcNow;
            var dateBillTo = new DateTime(dateNow.Year, dateNow.Month, 26);

            Guid idFilePayment = Guid.NewGuid();
            Guid idPayment = Guid.NewGuid();
            var transactionDate = DateTime.Now;

            ARRRequest<ARRBoleto> request = new ARRRequest<ARRBoleto>(TypeRegister.ARR, idFilePayment);

            request.Files.Add(FileBuilder.New().WithId(idFilePayment).Build());
            request.ARRDomain.Add(new ARRBoleto(request.Files[0]));

            request.paymentBoletos = new List<PaymentBoleto>
            {
                new PaymentBoletoBuilder()
                    .WithInvoiceNumberJsdn("TlA-1-00000001")
                    .WithCodigoBanco(341)
                    .WithTransactionDate(transactionDate)
                    .WithValorRecebido(100)
                    .Build(),
                new PaymentBoletoBuilder()
                    .WithInvoiceNumberJsdn("TlA-1-00000001")
                    .WithCodigoBanco(341)
                    .WithTransactionDate(transactionDate)
                    .WithValorRecebido(200)
                    .Build(),
                new PaymentBoletoBuilder()
                    .WithInvoiceNumberJsdn("TlA-1-00000001")
                    .WithCodigoBanco(341)
                    .WithTransactionDate(transactionDate)
                    .WithValorRecebido(500)
                    .Build(),
                new PaymentBoletoBuilder()
                    .WithInvoiceNumberJsdn("TlA-1-00000001")
                    .WithCodigoBanco(341)
                    .WithTransactionDate(transactionDate)
                    .WithValorRecebido(50)
                    .Build(),
            };

            request.PaymentReports = new List<PaymentReport>()
            {
                PaymentReportBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")
                .WithInvoiceNumber(request.paymentBoletos[0].InvoiceNumberJsdn)
                .WithPaymentDate(transactionDate)
                .WithBankCode("341")
                .WithPaymentValue(100)
                .WithTotalPaymentValue(100)
                .Build(),

                PaymentReportBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")
                .WithInvoiceNumber(request.paymentBoletos[0].InvoiceNumberJsdn)
                .WithPaymentDate(transactionDate)
                .WithBankCode("341")
                .WithPaymentValue(200)
                .WithTotalPaymentValue(200)
                .Build(),

                PaymentReportBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")
                .WithInvoiceNumber(request.paymentBoletos[0].InvoiceNumberJsdn)
                .WithPaymentDate(transactionDate)
                .WithBankCode("341")
                .WithPaymentValue(500)
                .WithTotalPaymentValue(500)
                .Build(),

                PaymentReportBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")
                .WithInvoiceNumber(request.paymentBoletos[0].InvoiceNumberJsdn)
                .WithPaymentDate(transactionDate)
                .WithBankCode("341")
                .WithPaymentValue(50)
                .WithTotalPaymentValue(50)
                .Build()
            };

            request.Services = new List<ServiceFilter> { 
                ServiceFilterBuilder.New()
                .WithInvoice(
                    InvoiceBuilder.New()
                    .WithInvoiceNumber(request.paymentBoletos[0].InvoiceNumberJsdn)
                    .WithStoreAcronym("telerese")
                    .Build())
                .WithStoreAcronym("telerese")
                .WithProviderCompanyAcronym("telerese")
                .Build() 
            };

            request.AccountingEntriesArrecadacao = new List<AccountingEntry>
            {
                AccountingEntryBuilder.New()
                .WithArrecadacaoARR("AAA")
                .WithAccountingEntryType("C")
                .WithAccountingAccount("accountCredit")
                .WithStore(StoreType.TBRA)
                .Build(),

                AccountingEntryBuilder.New()
                .WithArrecadacaoARR("AAA")
                .WithAccountingEntryType("D")
                .WithAccountingAccount("accountDebito")
                .WithStore(StoreType.TBRA)
                .Build()
            };

            request.AccountsARR = new List<AccountARR>
            {
                AccountARRBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")
                .WithArrecadacaoARR("AAA")
                .WithAccountingEntryType("C")
                .WithAccountingAccount("accountCredit")
                .WithStore(StoreType.TBRA)
                .WithProvider(StoreType.TBRA)
                .WithHaveIntercompany(false)
                .WithValidAccount(true)
                .Build(),

                AccountARRBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")
                .WithArrecadacaoARR("AAA")
                .WithAccountingEntryType("D")
                .WithAccountingAccount("accountDebito")
                .WithStore(StoreType.TBRA)
                .WithProvider(StoreType.TBRA)
                .WithHaveIntercompany(false)
                .WithValidAccount(true)
                .Build()
            };

            new LaunchHandler().ProcessRequest(request);

            var lines = request.Lines[StoreType.TBRA];

            Assert.True(lines.Count == 2);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("AAA") && p.Type == "BCO341" && p.AccountingEntry == "D").LaunchValue == 850);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("AAA") && p.Type == "BCO341" && p.AccountingEntry == "C").LaunchValue == 850);
        }
    }
}
