using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.UseCases.ARR;
using Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCard;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Tests.Builders;
using Gcsb.Connect.SAP.Tests.Builders.ARR;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.ARR.ARRCREDITCARD.Handler
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("H")]
    public class LaunchHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        [Fact]
        public void ReturnTwoLinesForOneAccount()
        {
            Guid idFilePayment = Guid.NewGuid();
            var transactionDate = DateTime.Now;

            ARRRequest<ARRCreditCard> request = new ARRRequest<ARRCreditCard>(TypeRegister.ARR, idFilePayment)
            {
                AccountingEntriesArrecadacao = new List<SAP.Domain.ARR.AccountingEntry>
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
                },

                AccountsARR = new List<AccountARR>
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
                }
            };

            var file = FileBuilder.New().WithId(idFilePayment).Build();

            request.ARRDomain.Add(new ARRCreditCard(file));

            request.paymentCreditCards = new List<PaymentCreditCard>
            {
                new PaymentFeedDocBuilder()
                    .WithInvoiceNumberJsdn("TlA-1-00000001")
                    .WithTransactionDate(transactionDate)
                    .WithTransactionAmount(100)
                    .Build(),

                new PaymentFeedDocBuilder()
                    .WithInvoiceNumberJsdn("TlA-1-00000001")
                    .WithTransactionDate(transactionDate)
                    .WithTransactionAmount(900)
                    .Build(),

                new PaymentFeedDocBuilder()
                    .WithInvoiceNumberJsdn("TlA-1-00000001")
                    .WithTransactionDate(transactionDate)
                    .WithTransactionAmount(900)
                    .Build(),

                new PaymentFeedDocBuilder()
                    .WithInvoiceNumberJsdn("TlA-1-00000001")
                    .WithTransactionDate(transactionDate)
                    .WithTransactionAmount(900)
                    .Build(),

                new PaymentFeedDocBuilder()
                    .WithInvoiceNumberJsdn("TlA-1-00000001")
                    .WithTransactionDate(transactionDate)
                    .WithTransactionAmount(200)
                    .Build()
            };

            request.PaymentReports = new List<PaymentReport>()
            {
                PaymentReportBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")
                .WithInvoiceNumber(request.paymentCreditCards[0].InvoiceNumberJsdn)
                .WithPaymentDate(transactionDate)
                .WithPaymentValue(10)
                .Build(),

                PaymentReportBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")                
                .WithInvoiceNumber(request.paymentCreditCards[0].InvoiceNumberJsdn)
                .WithPaymentDate(transactionDate)
                .WithPaymentValue(90)
                .Build(),

                PaymentReportBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")                
                .WithInvoiceNumber(request.paymentCreditCards[0].InvoiceNumberJsdn)
                .WithPaymentDate(transactionDate)
                .WithPaymentValue(90)
                .Build(),

                PaymentReportBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")                
                .WithInvoiceNumber(request.paymentCreditCards[0].InvoiceNumberJsdn)
                .WithPaymentDate(transactionDate)
                .WithPaymentValue(90)
                .Build(),

                PaymentReportBuilder.New()
                .WithInvoiceNumber("TlA-1-00000001")
                .WithServiceCode("ServiceCodeTest")
                .WithInvoiceNumber(request.paymentCreditCards[0].InvoiceNumberJsdn)
                .WithPaymentDate(transactionDate)
                .WithPaymentValue(20)
                .Build()
            };

            request.Services = new List<ServiceFilter> 
            { 
                ServiceFilterBuilder.New()
                .WithInvoice(
                    InvoiceBuilder.New()
                    .WithInvoiceNumber(request.paymentCreditCards[0].InvoiceNumberJsdn)
                    .WithStoreAcronym("telerese")
                    .Build())
                .WithStoreAcronym("telerese")
                .WithProviderCompanyAcronym("telerese")
                .Build() 
            };

            new LaunchHandler().ProcessRequest(request);

            var lines = request.Lines[StoreType.TBRA];

            Assert.True(lines.Count == 2);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("AAA") && p.AccountingEntry == "D").LaunchValue == 300m);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("AAA") && p.AccountingEntry == "C").LaunchValue == 300m);
        }
    }
}
