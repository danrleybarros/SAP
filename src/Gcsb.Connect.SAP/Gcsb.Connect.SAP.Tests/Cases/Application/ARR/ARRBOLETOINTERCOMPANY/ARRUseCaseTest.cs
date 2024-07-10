using Autofac;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.ARR;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.Domain.ARR.ARRBoletoIntercompany;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.IO;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.ARR.ARRBOLETOINTERCOMPANY
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("F")]
    public class ARRUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        public readonly IARRUseCase<ARRBoletoInter> arrUseCase;
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteRepo;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private readonly IPaymentFeedReadTsvRepository paymentFeedReadTsvRepository;
        private readonly IBillFeedReadCsvRepository billFeedReadCsvRepository;
        private readonly IBillFeedUseCase billFeedUC;
        private readonly IPaymentFeedUseCase<PaymentBoleto> paymentFeedUseCase;
        private static Guid idFilePayment;


        public ARRUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.arrUseCase = fixture.Container.Resolve<IARRUseCase<ARRBoletoInter>>();
            this.paymentFeedReadTsvRepository = fixture.Container.Resolve<IPaymentFeedReadTsvRepository>();
            this.billFeedReadCsvRepository = fixture.Container.Resolve<IBillFeedReadCsvRepository>();
            this.billFeedUC = fixture.Container.Resolve<IBillFeedUseCase>();
            this.paymentFeedUseCase = fixture.Container.Resolve<IPaymentFeedUseCase<PaymentBoleto>>();
            this.managementFinancialAccountWriteRepo = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Theory]
        [Trait("Action", "Read")]
        [InlineData("InputFiles/Sample_BillFeed.csv")]
        [TestPriority(0)]
        public void RepoBillFeedAddOneTest(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(ARRUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = billFeedReadCsvRepository.ReadCsvFile(pathShortSample);
            DocFeedRequest request = new DocFeedRequest(TypeRegister.BILL, "Sample_BillFeed", base64);
            var count = billFeedUC.Execute(request);
            Assert.True(count > 0);
        }

        [Theory]
        [Trait("Action", "Read")]
        [InlineData("InputFiles/Sample_PaymentBoleto_7-03-2020.tsv")]
        [TestPriority(1)]
        public void ShouldReadPaymentTsv(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(ARRUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = paymentFeedReadTsvRepository.ReadTsvFile(pathShortSample);

            DocFeedRequest request = new DocFeedRequest(TypeRegister.ARRBOLETO, "Sample_PaymentBoleto_7-03-2020.tsv", base64);

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
            ARRRequest<ARRBoletoInter> request = new ARRRequest<ARRBoletoInter>(TypeRegister.ARRBOLETOINTER, idFilePayment);
            var arr = arrUseCase.Execute(request);
            //Assert.True(arr > 0);
            Assert.NotNull(request.Logs);
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
