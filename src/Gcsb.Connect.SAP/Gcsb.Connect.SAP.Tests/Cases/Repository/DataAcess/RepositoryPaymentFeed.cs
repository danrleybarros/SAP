using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.DataAcess
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("A")]
    public class RepositoryPaymentFeed : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;
        private readonly IPaymentFeedWriteOnlyRepository paymentFeedWriteOnlyRepository;
        private readonly IPaymentFeedConvertRepository<PaymentCreditCard> paymentFeedConvertRepository;
        private readonly IPaymentFeedReadTsvRepository paymentFeedReadTsvRepository;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;

        public RepositoryPaymentFeed(Fixture.ApplicationFixture fixture)
        {
            this.paymentFeedReadOnlyRepository = fixture.Container.Resolve<IPaymentFeedReadOnlyRepository>();
            this.paymentFeedWriteOnlyRepository = fixture.Container.Resolve<IPaymentFeedWriteOnlyRepository>();
            this.paymentFeedConvertRepository = fixture.Container.Resolve<IPaymentFeedConvertRepository<PaymentCreditCard>>();
            this.paymentFeedReadTsvRepository = fixture.Container.Resolve<IPaymentFeedReadTsvRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Theory]
        [Trait("Action", "Read")]
        [InlineData("InputFiles/Sample_PaymentFeed_7-3-2020.tsv")]
        public void ShouldReadPaymentTsv(string relativePath)
        {
            var fileName = relativePath.Replace("InputFiles/", "");
            var dir = Path.GetDirectoryName(typeof(RepositoryPaymentFeed).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = paymentFeedReadTsvRepository.ReadTsvFile(pathShortSample);
            var collection = paymentFeedConvertRepository.FromTsv(base64, Guid.NewGuid(),fileName);
            List<PaymentCreditCard> listPays = new List<PaymentCreditCard>();
            collection.ToList().ForEach(s => listPays.Add(s));
            int ret = paymentFeedWriteOnlyRepository.Add(listPays);
            Assert.True(ret > 0);
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(1)]
        public void RepoBillFeedAddManyTest()
        {
            var models = new List<SAP.Domain.JSDN.PaymentCreditCard>
            {
                PaymentFeedDocBuilder.New().WithOrderId("1").Build(),
                PaymentFeedDocBuilder.New().WithOrderId("2").Build(),
                PaymentFeedDocBuilder.New().WithOrderId("3").Build(),
                PaymentFeedDocBuilder.New().WithOrderId("4").Build(),
                PaymentFeedDocBuilder.New().WithOrderId("5").Build()
            };

            int ret = paymentFeedWriteOnlyRepository.Add(models);

            Assert.True(ret > 0);
        }

        [Fact]
        [Trait("Action", "Read")]
        [TestPriority(2)]
        public void ReadAllPaymentFeedDocs()
        {
            Assert.True(paymentFeedReadOnlyRepository.GetPaymentFeed().Count > 0);
        }

        [Theory]
        [InlineData("VVL-2-00002261")]
        [TestPriority(3)]
        public void ReadOnePaymentFeed(string invoiceJsdn)
        {
            Assert.NotNull(paymentFeedReadOnlyRepository.GetPaymentFeed(invoiceJsdn));
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(4)]
        public void RepoPaymentFeedDeleteOneTest()
        {
            var model = paymentFeedReadOnlyRepository.GetPaymentFeed("VVL-2-00002261");

            var ret = paymentFeedWriteOnlyRepository.Delete(model);

            Assert.True(ret > 0);
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(5)]
        public void RepoPaymentFeedDeleteAllTest()
        {
            var ret = paymentFeedWriteOnlyRepository.DeleteAll();

            Assert.True(ret > 0);
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(6)]
        public void DigestAllInvoices()
        {
            invoiceWriteOnlyRepository.DeleteAll();
        }

    }
}
