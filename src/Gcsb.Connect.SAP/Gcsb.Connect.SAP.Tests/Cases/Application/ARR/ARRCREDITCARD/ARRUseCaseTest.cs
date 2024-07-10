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


namespace Gcsb.Connect.SAP.Tests.Cases.Application.ARR.ARRCREDITCARD
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("F")]
    public class ARRUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        public readonly IARRUseCase<ARRCreditCard> arrUseCase;
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


        public ARRUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            arrUseCase = fixture.Container.Resolve<IARRUseCase<ARRCreditCard>>();
            serviceInvoiceReadRepo = fixture.Container.Resolve<IServiceInvoiceReadOnlyRepository>();
            managementFinancialAccountReadRepo = fixture.Container.Resolve<IManagementFinancialAccountReadOnlyRepository>();
            paymentFeedConvertRepository = fixture.Container.Resolve<IPaymentFeedConvertRepository<PaymentCreditCard>>();
            paymentFeedReadTsvRepository = fixture.Container.Resolve<IPaymentFeedReadTsvRepository>();
            billFeedConvertRepository = fixture.Container.Resolve<IBillFeedConvertRepository>();
            billFeedReadCsvRepository = fixture.Container.Resolve<IBillFeedReadCsvRepository>();
            billFeedReadOnlyRepository = fixture.Container.Resolve<IBillFeedReadOnlyRepository>();
            billFeedWriteOnlyRepository = fixture.Container.Resolve<IBillFeedWriteOnlyRepository>();
            billFeedUC = fixture.Container.Resolve<IBillFeedUseCase>();
            paymentFeedUseCase = fixture.Container.Resolve<IPaymentFeedUseCase<PaymentCreditCard>>();
            managementFinancialAccountWriteRepo = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();
            invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Theory]
        [Trait("Action", "Read")]
        [InlineData("InputFiles/Sample_BillFeed.csv")]
        [TestPriority(0)]
        public void RepoBillFeedAddOneTest(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(ARRUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            var base64 = billFeedReadCsvRepository.ReadCsvFile(pathShortSample);
            var request = new DocFeedRequest(TypeRegister.BILL, "Sample_BillFeed", base64);
            var count = billFeedUC.Execute(request);
            Assert.True(count > 0);
        }

        [Theory]
        [Trait("Action", "Read")]
        [InlineData("InputFiles/Sample_PaymentFeed_7-3-2020.tsv")]
        [TestPriority(1)]
        public void ShouldReadPaymentTsv(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(ARRUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            var base64 = paymentFeedReadTsvRepository.ReadTsvFile(pathShortSample);
            var request = new DocFeedRequest(TypeRegister.PAYMENT, "Sample_PaymentFeed_7-3-2020.tsv", base64);
            idFilePayment = request.File.Id;
            var count = paymentFeedUseCase.Execute(request);
            Assert.True(count > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(2)]
        public void RepoFinancialAccountAddManyTest()
        {
            var ret = managementFinancialAccountWriteRepo.Add(Fixture.ApplicationFixture.ManagementFinancialsAccount());
            Assert.True(ret != Guid.Empty);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(3)]
        public void ARRUseCaseTestShouldExecute()
        {
            var request = new ARRRequest<ARRCreditCard>(TypeRegister.ARR, idFilePayment);
            var arr = arrUseCase.Execute(request);
            Assert.True(arr > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(4)]
        public void ARRUseCaseNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => arrUseCase.Execute(null));
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(5)]
        public void DigestInvoices()
        {
            invoiceWriteOnlyRepository.DeleteAll();
        }
    }
}
