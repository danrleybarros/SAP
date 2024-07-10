using Autofac;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Config;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.FAT;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.IO;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.FAT
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("H")]
    public class FATUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        public readonly IBillFeedReadCsvRepository billFeedReadCsvRepository;
        private readonly IBillFeedUseCase billFeedUC;
        public readonly IFinancialAccountReadOnlyRepository financialAccountReadOnlyRepository;
        public readonly IFileGenerator<SAP.Domain.FAT.FATFaturado.FATFaturado> fileGenerator;
        public readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;
        public readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        public readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        public readonly IFileReadOnlyRepository fileReadOnlyRepository;
        public readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository;
        public readonly IFATUseCase<SAP.Domain.FAT.FATFaturado.FATFaturado> fatUseCase;
        private readonly IInterestAndFineFinancialAccountWriteOnlyRepository interestAndFineFinancialAccountWriteOnlyRepository;        
        private static Guid idFileBill;
        private readonly IFinancialAccountWriteOnlyRepository financialAccountWrite;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;

        public FATUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.billFeedReadCsvRepository = fixture.Container.Resolve<IBillFeedReadCsvRepository>();
            this.billFeedUC = fixture.Container.Resolve<IBillFeedUseCase>();
            this.financialAccountReadOnlyRepository = fixture.Container.Resolve<IFinancialAccountReadOnlyRepository>();
            this.fileGenerator = fixture.Container.Resolve<IFileGenerator<SAP.Domain.FAT.FATFaturado.FATFaturado>>();
            this.invoiceReadOnlyRepository = fixture.Container.Resolve<IInvoiceReadOnlyRepository>();
            this.fileWriteOnlyRepository = fixture.Container.Resolve<IFileWriteOnlyRepository>();
            this.logWriteOnlyRepository = fixture.Container.Resolve<ILogWriteOnlyRepository>();
            this.fileReadOnlyRepository = fixture.Container.Resolve<IFileReadOnlyRepository>();
            this.serviceInvoiceReadOnlyRepository = fixture.Container.Resolve<IServiceInvoiceReadOnlyRepository>();            
            this.fatUseCase = fixture.Container.Resolve<IFATUseCase<SAP.Domain.FAT.FATFaturado.FATFaturado>>();
            this.financialAccountWrite = fixture.Container.Resolve<IFinancialAccountWriteOnlyRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
            this.interestAndFineFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IInterestAndFineFinancialAccountWriteOnlyRepository>();
        }


        [Theory]
        [Trait("Action", "Create")]
        [InlineData("InputFiles/Sample_BillFeed.csv")]
        [TestPriority(0)]
        public void RepoBillFeedAddOneTest(string relativePath)
        {
            var dir = System.IO.Path.GetDirectoryName(typeof(FATUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = billFeedReadCsvRepository.ReadCsvFile(pathShortSample);
            DocFeedRequest request = new DocFeedRequest(TypeRegister.BILL, "Sample_BillFeed", base64);
            idFileBill = request.File.Id;
            var count = billFeedUC.Execute(request);
            Assert.True(count > 0);
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(1)]
        public void ShouldAddManyFinacialAccount()
        {
            var account = InterestAndFineFinancialAccountBuilder.New().Build();
            var saveAccountReturn = interestAndFineFinancialAccountWriteOnlyRepository.Add(account);

            Assert.True(saveAccountReturn != Guid.Empty);
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
        [Trait("Action", "Create")]
        [TestPriority(3)]
        public void ShouldCreateFatUseCase()
        {
            var resquest = new FATRequest(TypeRegister.FAT, idFileBill, DateTime.UtcNow);
            var fat = fatUseCase.Execute(resquest);
            //Assert.True(fat != 0);
            Assert.NotNull(resquest.Logs);
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(4)]
        public void DigestInvoices()
        {
            invoiceWriteOnlyRepository.DeleteAll();
        }

        [Fact]
        [Trait("Action", "none")]
        [TestPriority(5)]
        public void FATUseCaseNullTest()
        {
            Assert.Throws<NullReferenceException>(() => (fatUseCase as FATFaturado).Execute(null));
        }
    }
}
