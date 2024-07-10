/*using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.UseCases.ARR;
using Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers;
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

namespace Gcsb.Connect.SAP.Tests.Cases.Application.ARR.ARRBOLETOINTERCOMPANY.Handler
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
                    new AccountingEntryBuilder().WithArrecadacaoARR("AAA").WithAccountingEntryType("C").WithAccountingAccount("accountCredit").WithStore(StoreType.TBRA).Build(),
                    new AccountingEntryBuilder().WithArrecadacaoARR("AAA").WithAccountingEntryType("D").WithAccountingAccount("accountDebito").WithStore(StoreType.TBRA).Build(),
                }
            };

            var file = FileBuilder.New().WithId(idFilePayment).Build();

            request.ARRDomain.Add(new ARRCreditCard(file));

            request.paymentCreditCards = new List<PaymentCreditCard>
            {
                new PaymentFeedDocBuilder().WithTransactionDate(transactionDate).WithTransactionAmount(100).Build(),
                new PaymentFeedDocBuilder().WithTransactionDate(transactionDate).WithTransactionAmount(900).Build(),
                new PaymentFeedDocBuilder().WithTransactionDate(transactionDate).WithTransactionAmount(900).Build(),
                new PaymentFeedDocBuilder().WithTransactionDate(transactionDate).WithTransactionAmount(900).Build(),
                new PaymentFeedDocBuilder().WithTransactionDate(transactionDate).WithTransactionAmount(200).Build(),
            };

            request.Services = new List<ServiceFilter> { ServiceFilterBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber(request.paymentCreditCards[0].InvoiceNumberJsdn).WithStoreAcronym("telerese").Build()).Build() };

            new LaunchHandler().ProcessRequest(request);

            var lines = request.Lines[StoreType.TBRA];

            Assert.True(lines.Count == 2);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("AAA") && p.AccountingEntry == "D").LaunchValue == 30m);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("AAA") && p.AccountingEntry == "C").LaunchValue == 30m);
        }
    }
}
*/
