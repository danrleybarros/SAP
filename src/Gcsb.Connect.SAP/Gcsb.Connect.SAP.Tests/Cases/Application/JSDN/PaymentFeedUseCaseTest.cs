using Autofac;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System.IO;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.JSDN
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("I")]
    public class PaymentFeedUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IPaymentFeedUseCase<PaymentCreditCard> paymentFeedUC;
        private readonly IPaymentFeedReadTsvRepository paymentFeedReadTsvRepository;
        private readonly IBillFeedReadCsvRepository billFeedReadCsvRepository;
        private readonly IBillFeedUseCase billFeedUC;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;

        public PaymentFeedUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.paymentFeedUC = fixture.Container.Resolve<IPaymentFeedUseCase<PaymentCreditCard>>();
            this.paymentFeedReadTsvRepository = fixture.Container.Resolve<IPaymentFeedReadTsvRepository>();
            this.billFeedReadCsvRepository = fixture.Container.Resolve<IBillFeedReadCsvRepository>();
            this.billFeedUC = fixture.Container.Resolve<IBillFeedUseCase>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Theory]
        [Trait("Action", "Read")]
        [InlineData("InputFiles/Sample_BillFeed.csv")]
        [TestPriority(0)]
        public void RepoBillFeedAddOneTest(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(PaymentBoletoUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = billFeedReadCsvRepository.ReadCsvFile(pathShortSample);
            DocFeedRequest request = new DocFeedRequest(TypeRegister.BILL, "Sample_BillFeed", base64);
            var count = billFeedUC.Execute(request);
            Assert.True(count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("InputFiles/Sample_PaymentFeed_7-3-2020.tsv")]
        [TestPriority(1)]
        public void PaymentFeedShouldExecute(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(PaymentFeedUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            var base64 = paymentFeedReadTsvRepository.ReadTsvFile(pathShortSample);
            var request = new DocFeedRequest(TypeRegister.PAYMENT, "Sample_PaymentFeed_7-3-2020.tsv", base64);

            Assert.True(paymentFeedUC.Execute(request) > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void PaymentFeedUseCaseNullTest()
        {
            Assert.Throws<System.ArgumentNullException>(() => paymentFeedUC.Execute(null));
        }

        [Fact]
        [Trait("Action", "None")]
        public void PaymentFeedUseCaseTestInvalidFileMissingSomeFields()
        {
            DocFeedRequest request = new DocFeedRequest(TypeRegister.PAYMENT, "Sample_PaymentFeed", "JVGVybWluYWxJZAlFbnRpdHlJZAlNZXJjaGFudElkCVNlcnZpY2VJZAlVc2VySWQJVHlwZU9wZXJhdGlvbglQcm9jZXNzQ29kZQlPcmRlcklkCUNhcmRQYW4JQ2FyZEV4cGlyYXRpb25EYXRlCVRyYW5zYWN0aW9uQW1vdW50CU1lcmNoYW50Q3VycmVuY3kJQ3VycmVuY3kJT3JpZ2luSVBBZGRyZXNzCURhdGVUaW1lU0lBCURhdGVUaW1lUGF5bWVudAlUcmFuc2FjdGlvbkRhdGUJU0lBT3BlcmF0aW9uTnVtYmVyCUF1dGhvcml6YXRpb25JRAlBbHRlcm5hdGl2ZUFtb3VudAlBbHRlcm5hdGl2ZWN1cnJlbmN5CUN1c3RvbWVyRW1haWwJTWVyY2hhbnRTZXNzaW9uCUJhdGNoSUQJRGF0YVByaW50CVVSTFBVQ0UJVVJMX0FVVEhfUEFUSAlBY3F1aXJlckVudGl0eQlQbGFuVHlwZQlJbnN0YWxsbWVudHNOdW1iZXIJR3JhY2VQZXJpb2QJSW50ZXJlc3RBbW91bnQJRXh0ZW5kZWRTSUFPcGVyYXRpb25OdW1iZXIJQWNxdWlyZXJUcmFuc2FjdGlvbklECUJhbmtJZGVudGlmaWNhdGlvbk51bWJlcglDYXJkSXNzdWVyCUNhcmRJc3N1ZXJDb3VudHJ5CUNhcmRCcmFuZAlDYXJkQ2F0ZWdvcnkJQ2FyZFR5cGUNCjEJQVBQUk9WRUQJNQlUU1ZTCVRDQlIJMTIwMDAwMDAwMQkwCVBSVUVCQV9UT0tFTgkxNDMwCTk4NgkyLDAxOTM3RSsxOAk0NTQ4ODEqKioqKiowMDA0CTEyMjAJNTAwCTk4NglCUkwJMTkyLjE2OC4xNjgJCQkyMDE5LTAzLTEyVDE4Oj==E4OjQzLjAwMCBBbWVyaWNhL1Nhb19QYXVsbwkxNTgwNjk3CQk5LDAxCQkJCQkJCQkJCQkJCQkJCQkJCQkNCg" );            
            Assert.True(paymentFeedUC.Execute(request) == 0);
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(2)]
        public void DigestInvoices()
        {
            invoiceWriteOnlyRepository.DeleteAll();
        }
    }
}
