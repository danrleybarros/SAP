using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Tests.Builders;
using System;
using System.IO;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.CsvConvertTests
{
    public class ReturnNFConvertTest : IClassFixture<Fixture.ApplicationFixture>
    {
        public readonly IReturnNFConvertRepository returnNFConvertRepository;
        public readonly IReturnNFReadCsvRepository returnNFReadCsvRepository;

        public ReturnNFConvertTest(Fixture.ApplicationFixture fixture)
        {
            this.returnNFConvertRepository = fixture.Container.Resolve<IReturnNFConvertRepository>();
            this.returnNFReadCsvRepository = fixture.Container.Resolve<IReturnNFReadCsvRepository>();
        }

        [Theory]
        [Trait("Action", "Read")]
        [InlineData("InputFiles/Sample_ReturnNF.csv")]
        public void ShouldReadPaymentTsv(string relativePath)
        {
            var file = new FileBuilder().Build();
            var dir = Path.GetDirectoryName(typeof(ReturnNFConvertTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            var base64 = returnNFReadCsvRepository.ReadCsvFile(pathShortSample);
            var collection = returnNFConvertRepository.FromCsv(base64, file.Id, "telerese");

            Assert.True(collection.Count > 0);
        }
    }
}
