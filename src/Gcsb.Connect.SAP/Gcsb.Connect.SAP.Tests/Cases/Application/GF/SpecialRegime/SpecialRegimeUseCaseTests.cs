using Autofac;
using FluentAssertions;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.GF.SpecialRegime;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.Tests.Fixture;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System.Buffers.Text;
using System.IO;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.SpecialRegime
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("I")]
    public class SpecialRegimeUseCaseTests : IClassFixture<ApplicationFixture>
    {
        private readonly ISpecialRegimeUseCase specialRegimeUC;
        private readonly IBillFeedReadCsvRepository billFeedReadCsvRepository;
        private readonly IBillFeedUseCase billFeedUC;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private static DocFeedRequest docRequest = null;

        public SpecialRegimeUseCaseTests(ApplicationFixture fixture)
        {
            this.specialRegimeUC = fixture.Container.Resolve<ISpecialRegimeUseCase>();
            this.billFeedReadCsvRepository = fixture.Container.Resolve<IBillFeedReadCsvRepository>();
            this.billFeedUC = fixture.Container.Resolve<IBillFeedUseCase>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Theory]
        [Trait("Action", "Add")]
        [InlineData("InputFiles/Sample_BillFeed.csv")]
        [TestPriority(0)]
        public void ShouldExecuteBillFeedIngest(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(SpecialRegimeUseCase).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            var base64 = billFeedReadCsvRepository.ReadCsvFile(pathShortSample);

            docRequest = new DocFeedRequest(TypeRegister.BILLCSV, "Sample_BillFeed", base64);

            billFeedUC.Execute(docRequest).Should().BeGreaterThan(0);
        }

        [Fact]
        [Trait("Action", "Execute")]
        [TestPriority(1)]
        public void ShouldExecuteSpecialRegimeUseCase()
        {
            var dir = Path.GetDirectoryName(typeof(SpecialRegimeUseCase).Assembly.Location);
            var pathShortSample = Path.Combine(dir, "InputFiles/Sample_BillFeed.csv");
            var base64 = billFeedReadCsvRepository.ReadCsvFile(pathShortSample);

            docRequest = new DocFeedRequest(TypeRegister.BILLCSV, "Sample_BillFeed", base64);

            var request = new SpecialRegimeRequest(docRequest.File.Id);
            var ret = specialRegimeUC.Execute(request);

            request.Logs.Should().NotBeNullOrEmpty().And.HaveCountGreaterThan(0);
            ret.Should().Be(1);
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
