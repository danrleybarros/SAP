using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport;
using Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport.RequestHandlers;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.IndividualReportNF.RequestHandlersTest
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class SaveLogsHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly MountIndividualReportHandler mountIndividualReport;
        private readonly GetInvoicesHandler getGetInvoicesHandler;
        private readonly GenerateOutputHandler generateOutputHandler;
        private readonly SaveFileHandler saveFileHandler;
        private readonly SaveLogsHandler saveLogsHandler;

        public SaveLogsHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.customerWriteOnlyRepository = fixture.Container.Resolve<ICustomerWriteOnlyRepository>();
            this.mountIndividualReport = fixture.Container.Resolve<MountIndividualReportHandler>();
            this.getGetInvoicesHandler = fixture.Container.Resolve<GetInvoicesHandler>();
            this.generateOutputHandler = fixture.Container.Resolve<GenerateOutputHandler>();
            this.saveFileHandler = fixture.Container.Resolve<SaveFileHandler>();
            this.saveLogsHandler = fixture.Container.Resolve<SaveLogsHandler>();
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void CustomerAddMany()
        {
            Assert.True(customerWriteOnlyRepository.Add(Fixture.ApplicationFixture.Customers(new Guid(), "INV-083")) > 0);
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(1)]
        public void ShouldGenerateOutputFile()
        {
            var request = new IndividualReportRequestNF(Guid.NewGuid());

            getGetInvoicesHandler.ProcessRequest(request);
            mountIndividualReport.ProcessRequest(request);
            saveFileHandler.ProcessRequest(request);
            generateOutputHandler.ProcessRequest(request);
            saveLogsHandler.ProcessRequest(request);
        }

        [Fact]
        [Trait("Action", "Exception")]
        public void ShouldThrowArgumentNullException()
        {
            Assert.Throws<NullReferenceException>(() => saveLogsHandler.ProcessRequest(null));
        }
    }
}
