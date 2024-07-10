using Autofac;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Config;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.FAT;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.Tests.Cases.Application.FAT;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.IO;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.FATaFaturarACM
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("H")]
    public class FATaFaturarACMUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        public readonly IBillFeedReadCsvRepository billFeedReadCsvRepository;
        private readonly IBillFeedUseCase billFeedUC;
        public readonly IFinancialAccountReadOnlyRepository financialAccountReadOnlyRepository;
        public readonly IFileGenerator<SAP.Domain.FAT.FATaFaturarACM.FATaFaturarACM> fileGenerator;
        public readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;
        public readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        public readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        public readonly IFileReadOnlyRepository fileReadOnlyRepository;
        public readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository;
        public readonly IFATUseCase<SAP.Domain.FAT.FATaFaturarACM.FATaFaturarACM> fatUseCase;
        //public readonly IFATFaturadoUseCase fatFaturadoUseCase;

        private static Guid idFileBill;
        private static Guid idFileBill_Faturado;
        private readonly IFinancialAccountWriteOnlyRepository financialAccountWrite;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;

        public FATaFaturarACMUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.billFeedReadCsvRepository = fixture.Container.Resolve<IBillFeedReadCsvRepository>();
            this.billFeedUC = fixture.Container.Resolve<IBillFeedUseCase>();
            this.financialAccountReadOnlyRepository = fixture.Container.Resolve<IFinancialAccountReadOnlyRepository>();
            this.fileGenerator = fixture.Container.Resolve<IFileGenerator<SAP.Domain.FAT.FATaFaturarACM.FATaFaturarACM>>();
            this.invoiceReadOnlyRepository = fixture.Container.Resolve<IInvoiceReadOnlyRepository>();
            this.fileWriteOnlyRepository = fixture.Container.Resolve<IFileWriteOnlyRepository>();
            this.logWriteOnlyRepository = fixture.Container.Resolve<ILogWriteOnlyRepository>();
            this.fileReadOnlyRepository = fixture.Container.Resolve<IFileReadOnlyRepository>();
            this.serviceInvoiceReadOnlyRepository = fixture.Container.Resolve<IServiceInvoiceReadOnlyRepository>();
            this.fatUseCase = fixture.Container.Resolve<IFATUseCase<SAP.Domain.FAT.FATaFaturarACM.FATaFaturarACM>>();
            this.financialAccountWrite = fixture.Container.Resolve<IFinancialAccountWriteOnlyRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("InputFiles/FAT/Sample_BillFeed_Faturado.csv")]
        [TestPriority(0)]
        public void RepoBillFeedAddOneTest_Faturado(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(FATaFaturarACMUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = billFeedReadCsvRepository.ReadCsvFile(pathShortSample);
            DocFeedRequest request = new DocFeedRequest(TypeRegister.BILL, "Sample_BillFeed_Fat", base64);
            idFileBill_Faturado = request.File.Id;
            var count = billFeedUC.Execute(request);
            Assert.True(count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("InputFiles/FAT/Sample_BillFeed_AFaturar.csv")]
        [TestPriority(1)]
        public void RepoBillFeedAddOneTest(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(FATaFaturarACMUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = billFeedReadCsvRepository.ReadCsvFile(pathShortSample);
            DocFeedRequest request = new DocFeedRequest(TypeRegister.BILL, "Sample_BillFeed", base64);
            idFileBill = request.File.Id;
            var count = billFeedUC.Execute(request);
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
        [Trait("Action", "Create")]
        [TestPriority(3)]
        public void ShouldCreateFatUseCaseMonthPrevious()
        {
            var resquest = new FATRequest(TypeRegister.FATAFATURARACM, idFileBill_Faturado, DateTime.UtcNow.AddMonths(-1));
            var fat = fatUseCase.Execute(resquest);
            Assert.NotNull(resquest.Logs);
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(4)]
        public void ShouldCreateFatUseCaseActiveMonth()
        {
            var resquest = new FATRequest(TypeRegister.FATAFATURARACM, idFileBill, DateTime.UtcNow);
            var fat = fatUseCase.Execute(resquest);
            Assert.NotNull(resquest.Logs);
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(5)]
        public void DigestInvoices()
        {
            invoiceWriteOnlyRepository.DeleteAll();
        }

        [Fact]
        [Trait("Action", "none")]
        [TestPriority(6)]
        public void FATaFaturarUseCaseNullTest()
        {
            Assert.Throws<NullReferenceException>(() => fatUseCase.Execute(null));
        }
    }
}
