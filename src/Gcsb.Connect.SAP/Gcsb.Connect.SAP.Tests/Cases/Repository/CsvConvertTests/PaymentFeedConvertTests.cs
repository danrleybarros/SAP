using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.CsvConvertTests
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("J")]
    public class PaymentFeedConvertTests : IClassFixture<Fixture.ApplicationFixture>
    {
        public readonly IPaymentFeedConvertRepository<PaymentCreditCard> paymentFeedConvertRepository;
        public readonly IPaymentFeedReadTsvRepository paymentFeedReadTsvRepository;

        public PaymentFeedConvertTests(Fixture.ApplicationFixture fixture)
        {
            this.paymentFeedConvertRepository = fixture.Container.Resolve<IPaymentFeedConvertRepository<PaymentCreditCard>>();
            this.paymentFeedReadTsvRepository = fixture.Container.Resolve<IPaymentFeedReadTsvRepository>();
        }

        [Theory]
        [Trait("Action", "Read")]
        [InlineData("InputFiles/Sample_PaymentFeed_7-3-2020.tsv")]
        public void ShouldReadPaymentTsv(string relativePath)
        {
            var fileName = relativePath.Replace("InputFiles/", "");
            var idFileGuid = Guid.Parse("e5ad299e-c52e-425b-9691-aeab98c8ff10");
            var dir = Path.GetDirectoryName(typeof(PaymentFeedConvertTests).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = paymentFeedReadTsvRepository.ReadTsvFile(pathShortSample);
            var collection = paymentFeedConvertRepository.FromTsv(base64, idFileGuid, fileName);
            Assert.True(collection.Count > 0);
        }
    }
}
