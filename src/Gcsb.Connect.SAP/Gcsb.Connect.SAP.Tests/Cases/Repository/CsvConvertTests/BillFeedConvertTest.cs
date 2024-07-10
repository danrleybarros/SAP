using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.IO;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository
{
    public class BillFeedConvertTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IBillFeedConvertRepository billFeedConvertRepository;
        private readonly IBillFeedReadCsvRepository billFeedReadCsvRepository;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;

        public BillFeedConvertTest(Fixture.ApplicationFixture fixture)
        {
            this.billFeedConvertRepository = fixture.Container.Resolve<IBillFeedConvertRepository>();
            this.billFeedReadCsvRepository = fixture.Container.Resolve<IBillFeedReadCsvRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Theory]
        [Trait("Action","Read")]
        [InlineData("InputFiles/Sample_BillFeed.csv")]
        [TestPriority(0)]
        public void ShouldReadSampleCsv(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(BillFeedConvertTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = billFeedReadCsvRepository.ReadCsvFile(pathShortSample);
            var collection = billFeedConvertRepository.FromCsv(base64, Guid.NewGuid());
            Assert.True(collection.Count > 0);            
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(1)]
        public void DigestInvoices()
        {
            invoiceWriteOnlyRepository.DeleteAll();
        }
    }
}