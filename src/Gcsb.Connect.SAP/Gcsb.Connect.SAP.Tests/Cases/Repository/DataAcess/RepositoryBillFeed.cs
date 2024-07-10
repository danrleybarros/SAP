using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Tests.Builders;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

 
namespace Gcsb.Connect.SAP.Tests.Cases.Repository.DataAcess
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("B")]
    public class RepositoryBillFeed : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IBillFeedReadOnlyRepository billFeedReadOnlyRepository;
        private readonly IBillFeedWriteOnlyRepository billFeedWriteOnlyRepository;
        private readonly IBillFeedConvertRepository billFeedConvertRepository;
        private readonly IBillFeedReadCsvRepository billFeedReadCsvRepository;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;

        public RepositoryBillFeed(Fixture.ApplicationFixture fixture)
        {
            this.billFeedReadOnlyRepository = fixture.Container.Resolve<IBillFeedReadOnlyRepository>();
            this.billFeedWriteOnlyRepository = fixture.Container.Resolve<IBillFeedWriteOnlyRepository>();
            this.billFeedConvertRepository = fixture.Container.Resolve<IBillFeedConvertRepository>();
            this.billFeedReadCsvRepository = fixture.Container.Resolve<IBillFeedReadCsvRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Theory]
        [Trait("Action","Create")]
        [TestPriority(0)]
        [InlineData("InputFiles/Sample_BillFeed.csv")]        
        public void RepoBillFeedAddOneTest(string relativePath)
        {            
            var dir = Path.GetDirectoryName(typeof(BillFeedConvertTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = billFeedReadCsvRepository.ReadCsvFile(pathShortSample);
            var collection = billFeedConvertRepository.FromCsv(base64, Guid.NewGuid());
            int ret = billFeedWriteOnlyRepository.Add(collection);
            Assert.True(ret > 0);
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(1)]
        public void RepoBillFeedAddManyTest()
        {
            var models = new List<SAP.Domain.JSDN.BillFeedDoc>
            {
                BillFeedDocBuilder.New().WithMarketplace("MarketPlace1").Build(),
                BillFeedDocBuilder.New().WithMarketplace("MarketPlace2").Build(),
                BillFeedDocBuilder.New().WithMarketplace("MarketPlace3").Build(),
                BillFeedDocBuilder.New().WithMarketplace("MarketPlace4").Build(),
                BillFeedDocBuilder.New().WithMarketplace("MarketPlace5").Build()
            };
            int ret = billFeedWriteOnlyRepository.Add(models);
            Assert.True(ret > 0);
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(3)]
        public void RepoBillFeedDelete()
        {            
            var ret = billFeedWriteOnlyRepository.Delete(billFeedReadOnlyRepository.GetBillFeed().FirstOrDefault());
            Assert.True(ret == 1);            
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(4)]
        public void DigestAllInvoices()
        {
            invoiceWriteOnlyRepository.DeleteAll();
        }

        [Fact]
        public void ShouldBeObjectEmptyOrNull()
        {
            var deferralCycleDate = billFeedReadOnlyRepository.GetCycleByBillFeedId(Guid.NewGuid());

            deferralCycleDate.Should().BeNull();            
        }

    }
}
