using Autofac;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.ARR;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.IO;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.ARR.ARRCREDITCARDINTER
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("F")]
    public class ARRIntercompanyUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        public readonly IARRUseCase<ARRCreditCardInter> arrUseCase;
        private readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadRepo;
        private readonly IManagementFinancialAccountReadOnlyRepository managementFinancialAccountReadRepo;
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteRepo;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private readonly IPaymentFeedConvertRepository<PaymentCreditCard> paymentFeedConvertRepository;
        private readonly IPaymentFeedReadTsvRepository paymentFeedReadTsvRepository;
        private readonly IBillFeedConvertRepository billFeedConvertRepository;
        private readonly IBillFeedReadCsvRepository billFeedReadCsvRepository;
        private readonly IBillFeedReadOnlyRepository billFeedReadOnlyRepository;
        private readonly IBillFeedWriteOnlyRepository billFeedWriteOnlyRepository;
        private readonly IBillFeedUseCase billFeedUC;
        private readonly IPaymentFeedUseCase<PaymentCreditCard> paymentFeedUseCase;
        private static Guid idFilePayment;


        public ARRIntercompanyUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.arrUseCase = fixture.Container.Resolve<IARRUseCase<ARRCreditCardInter>>();
            this.serviceInvoiceReadRepo = fixture.Container.Resolve<IServiceInvoiceReadOnlyRepository>();
            this.managementFinancialAccountReadRepo = fixture.Container.Resolve<IManagementFinancialAccountReadOnlyRepository>();
            this.paymentFeedConvertRepository = fixture.Container.Resolve<IPaymentFeedConvertRepository<PaymentCreditCard>>();
            this.paymentFeedReadTsvRepository = fixture.Container.Resolve<IPaymentFeedReadTsvRepository>();
            this.billFeedConvertRepository = fixture.Container.Resolve<IBillFeedConvertRepository>();
            this.billFeedReadCsvRepository = fixture.Container.Resolve<IBillFeedReadCsvRepository>();
            this.billFeedReadOnlyRepository = fixture.Container.Resolve<IBillFeedReadOnlyRepository>();
            this.billFeedWriteOnlyRepository = fixture.Container.Resolve<IBillFeedWriteOnlyRepository>();
            this.billFeedUC = fixture.Container.Resolve<IBillFeedUseCase>();
            this.paymentFeedUseCase = fixture.Container.Resolve<IPaymentFeedUseCase<PaymentCreditCard>>();
            this.managementFinancialAccountWriteRepo = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Theory]
        [Trait("Action", "Read")]
        [InlineData("InputFiles/Sample_BillFeed.csv")]
        [TestPriority(0)]
        public void RepoBillFeedAddOneTest(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(ARRCREDITCARD.ARRUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = billFeedReadCsvRepository.ReadCsvFile(pathShortSample);
            DocFeedRequest request = new DocFeedRequest(TypeRegister.BILL, "Sample_BillFeed", base64);
            var count = billFeedUC.Execute(request);
            Assert.True(count > 0);
        }

        [Theory]
        [Trait("Action", "Read")]
        [InlineData("InputFiles/Sample_PaymentFeed_7-3-2020.tsv")]
        [TestPriority(1)]
        public void ShouldReadPaymentTsv(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(ARRCREDITCARD.ARRUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = paymentFeedReadTsvRepository.ReadTsvFile(pathShortSample);

            DocFeedRequest request = new DocFeedRequest(TypeRegister.PAYMENT, "Sample_PaymentFeed_7-3-2020.tsv", base64);

            idFilePayment = request.File.Id;

            var count = paymentFeedUseCase.Execute(request);

            Assert.True(count > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(1)]
        public void RepoFinancialAccountAddManyTest()
        {
            Guid ret = managementFinancialAccountWriteRepo.Add(Fixture.ApplicationFixture.ManagementFinancialsAccount());

            Assert.True(ret != Guid.Empty);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(2)]
        public void ARRUseCaseTestShouldExecute()
        {
            ARRRequest<ARRCreditCardInter> request = new ARRRequest<ARRCreditCardInter>(TypeRegister.ARRINTER, idFilePayment);
            var arr = arrUseCase.Execute(request);
            Assert.True(arr > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(3)]
        public void ARRUseCaseNullTest()
        {
            Assert.Throws<System.ArgumentNullException>(() => arrUseCase.Execute(null));
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(4)]
        public void DigestInvoices()
        {
            invoiceWriteOnlyRepository.DeleteAll();
        }
    }
}
