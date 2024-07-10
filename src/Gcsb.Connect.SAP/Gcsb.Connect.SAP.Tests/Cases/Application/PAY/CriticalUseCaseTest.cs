using Autofac;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.PAY;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.PAY
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class CriticalUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IBillFeedReadCsvRepository billFeedReadCsvRepository;
        private readonly IBillFeedUseCase billFeedUC;
        private readonly IPaymentFeedReadTsvRepository paymentFeedReadTsvRepository;
        private readonly IPaymentFeedUseCase<PaymentBoleto> paymentFeedUseCase;
        private readonly ICriticalUseCase criticalUseCase;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private static Guid idFilePayment;

        public CriticalUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.billFeedReadCsvRepository = fixture.Container.Resolve<IBillFeedReadCsvRepository>();
            this.billFeedUC = fixture.Container.Resolve<IBillFeedUseCase>();
            this.paymentFeedReadTsvRepository = fixture.Container.Resolve<IPaymentFeedReadTsvRepository>();
            this.criticalUseCase = fixture.Container.Resolve<ICriticalUseCase>();
            this.paymentFeedUseCase = fixture.Container.Resolve<IPaymentFeedUseCase<PaymentBoleto>>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Theory]
        [Trait("Action", "Read")]
        [InlineData("InputFiles/Sample_BillFeed_1-7-2019.csv")]
        [TestPriority(0)]
        public void RepoBillFeedAddOneTest(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(CriticalUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = billFeedReadCsvRepository.ReadCsvFile(pathShortSample);
            DocFeedRequest request = new DocFeedRequest(TypeRegister.BILL, "Sample_BillFeed_1-7-2019", base64);
            var count = billFeedUC.Execute(request);
            Assert.True(count > 0);
        }        

        [Theory]
        [Trait("Action", "Read")]
        [InlineData("InputFiles/Sample_PaymentBoleto_7-03-2020.tsv")]
        [TestPriority(1)]
        public void ShouldReadPaymentTsv(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(CriticalUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = paymentFeedReadTsvRepository.ReadTsvFile(pathShortSample);
            DocFeedRequest request = new DocFeedRequest(TypeRegister.PAYMENTBOLETO, "Sample_PaymentBoleto_7-03-2020.tsv", base64);

            idFilePayment = request.File.Id;
            var count = paymentFeedUseCase.Execute(request);
            Assert.True(count > 0);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldExecuteUseCase()
        {
            var request = new CriticalRequest(idFilePayment);

            criticalUseCase.Execute(request);

            Assert.True(request.Criticals.Count() > 0);
            Assert.True(request.Logs.Count() > 0);
            Assert.False(request.Logs.Where(x => x.TypeLog.Equals(TypeLog.Error)).Count() > 0);
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(3)]
        public void DigestInvoices()
        {
            invoiceWriteOnlyRepository.DeleteAll();
        }

    }
}
