using Autofac;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Config;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.PAS;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System; 
using System.IO; 
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.PAS
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("D")]
    public class PASUseCaseTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadRepo;
        private readonly IFinancialAccountReadOnlyRepository FinancialAccountReadRepo;
        private readonly IPASUseCase pASUseCase;
        private readonly IPaymentFeedConvertRepository<PaymentCreditCard> paymentFeedConvertRepository;
        private readonly IPaymentFeedReadTsvRepository paymentFeedReadTsvRepository;
        private readonly IBillFeedConvertRepository billFeedConvertRepository;
        private readonly IBillFeedReadCsvRepository billFeedReadCsvRepository;
        private readonly IBillFeedReadOnlyRepository billFeedReadOnlyRepository;
        private readonly IBillFeedWriteOnlyRepository billFeedWriteOnlyRepository;
        private readonly IBillFeedUseCase billFeedUC;
        private readonly IPaymentFeedUseCase<PaymentCreditCard> paymentFeedUseCase;
        private static Guid idFilePayment;
        private readonly IFinancialAccountWriteOnlyRepository financialAccountWrite;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;

        public PASUseCaseTests(Fixture.ApplicationFixture fixture)
        {
            this.serviceInvoiceReadRepo = fixture.Container.Resolve<IServiceInvoiceReadOnlyRepository>();
            this.FinancialAccountReadRepo = fixture.Container.Resolve<IFinancialAccountReadOnlyRepository>();
            this.pASUseCase = fixture.Container.Resolve<IPASUseCase>();
            this.paymentFeedConvertRepository = fixture.Container.Resolve<IPaymentFeedConvertRepository<PaymentCreditCard>>();
            this.paymentFeedReadTsvRepository = fixture.Container.Resolve<IPaymentFeedReadTsvRepository>();
            this.billFeedConvertRepository = fixture.Container.Resolve<IBillFeedConvertRepository>();
            this.billFeedReadCsvRepository = fixture.Container.Resolve<IBillFeedReadCsvRepository>();
            this.billFeedReadOnlyRepository = fixture.Container.Resolve<IBillFeedReadOnlyRepository>();
            this.billFeedWriteOnlyRepository = fixture.Container.Resolve<IBillFeedWriteOnlyRepository>();
            this.billFeedUC = fixture.Container.Resolve<IBillFeedUseCase>();
            this.paymentFeedUseCase = fixture.Container.Resolve<IPaymentFeedUseCase<PaymentCreditCard>>();
            this.financialAccountWrite = fixture.Container.Resolve<IFinancialAccountWriteOnlyRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
            this.customerWriteOnlyRepository = fixture.Container.Resolve<ICustomerWriteOnlyRepository>();
            this.managementFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();
        }
         
 
       
        
        [Theory]
        [Trait("Action", "Create")]
        [InlineData("InputFiles/Sample_BillFeed.csv")]
        [TestPriority(0)]
        public void BillFeedIngestPrepare(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(PASUseCaseTests).Assembly.Location);
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
        public void PaymentFeedIngestPrepare(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(PASUseCaseTests).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = paymentFeedReadTsvRepository.ReadTsvFile(pathShortSample);

            DocFeedRequest request = new DocFeedRequest(TypeRegister.PAYMENT, "Sample_PaymentFeed_7-3-2020.tsv", base64);

            idFilePayment = request.File.Id;

            var count = paymentFeedUseCase.Execute(request);

            Assert.True(count > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(2)]
        public void RepoFinancialAccountAddManyTest()
        { 
            int ret = financialAccountWrite.Add(Fixture.ApplicationFixture.FinancialsAccounts);

            Assert.True(ret > 0);
        }

        [Fact]  
        [Trait("Action", "None")]
        [TestPriority(3)]
        public void ShouldExecuteWithSuccess()
        {
            var model = ManagementFinancialAccountBuilder.New().Build();
            Guid item = managementFinancialAccountWriteOnlyRepository.Add(model);
            var file = Builders.FileBuilder.New().WithFileName("PAS20190101.csv").WithType(TypeRegister.PAS).WithId(idFilePayment).Build();
            int ret = pASUseCase.Execute(new PASRequest(file));
            Assert.True(ret == 1);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(4)]
        public void DigestInvoices()
        {
            invoiceWriteOnlyRepository.DeleteAll();
            customerWriteOnlyRepository.DeleteAll();           
        }
    }
}
