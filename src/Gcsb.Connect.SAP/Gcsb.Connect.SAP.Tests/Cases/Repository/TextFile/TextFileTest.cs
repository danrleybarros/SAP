using System;
using System.Text;
using Gcsb.Connect.SAP.Application.Repositories;
using Xunit;
using Autofac;
using System.IO;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.TextFile
{
    public class TextFileTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IMakeTextFile makeTextFileRepository;

        public TextFileTest(Fixture.ApplicationFixture fixture)
            => makeTextFileRepository = fixture.Container.Resolve<IMakeTextFile>();

        [Fact]
        [Trait("Action", "Read")]
        public void ShouldReceiveModelAndReadProperties()
        {
            var modelHeader = new SAP.Domain.ARR.Header("01012019", "01022019");
            var modelRegister = new SAP.Domain.ARR.CreditCard.IdentificationRegisterCreditCard(1, StoreType.TBRA);
            var modelLaunchItem = new SAP.Domain.ARR.LaunchItem(1, DateTime.UtcNow, "", 2500.00M, "", "GP", "", "C", "Crédito");
            var modelFooter = new SAP.Domain.ARR.CreditCard.FooterCreditCard(2500.00M, "", "", 2500.00M);

            Assert.True(makeTextFileRepository.ProcessRequestWithSpace(modelRegister).Length > 0);
            Assert.True(makeTextFileRepository.ProcessRequestWithSpace(modelHeader).Length > 0);
            Assert.True(makeTextFileRepository.ProcessRequestWithSpace(modelLaunchItem).Length > 0);
            Assert.True(makeTextFileRepository.ProcessRequestWithSpace(modelFooter).Length > 0);
        }

        [Theory]
        [InlineData("ARR55TB29190001.TXT")]
        public void ShouldCreateAndWriteTextFile(string strFileName)
        {
            var strPath = $"{Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())).Replace("\\bin", "\\OutputFiles\\")}{strFileName}";
            var strBuilder = new StringBuilder();
            var modelHeader = new SAP.Domain.ARR.Header("", "");
            var modelRegister = new SAP.Domain.ARR.CreditCard.IdentificationRegisterCreditCard(1, StoreType.TBRA);
            var modelLaunchItem = new SAP.Domain.ARR.LaunchItem(0000000001, DateTime.UtcNow, "ARRECGEN000GW", 2500.00M, "", "GP", "", "C", "Crédito");
            var modelFooter = new SAP.Domain.ARR.CreditCard.FooterCreditCard(2500.00M, "", "", 2500.00M);

            strBuilder.AppendLine(makeTextFileRepository.ProcessRequestWithSpace(modelRegister).ToString());
            strBuilder.AppendLine(makeTextFileRepository.ProcessRequestWithSpace(modelHeader).ToString());
            strBuilder.AppendLine(makeTextFileRepository.ProcessRequestWithSpace(modelLaunchItem).ToString());
            strBuilder.AppendLine(makeTextFileRepository.ProcessRequestWithSpace(modelLaunchItem).ToString());
            strBuilder.AppendLine(makeTextFileRepository.ProcessRequestWithSpace(modelLaunchItem).ToString());
            strBuilder.AppendLine(makeTextFileRepository.ProcessRequestWithSpace(modelLaunchItem).ToString());
            strBuilder.AppendLine(makeTextFileRepository.ProcessRequestWithSpace(modelLaunchItem).ToString());
            strBuilder.AppendLine(makeTextFileRepository.ProcessRequestWithSpace(modelFooter).ToString());

            makeTextFileRepository.Execute(strBuilder.ToString(), strPath);

            Assert.True(File.Exists(strPath));
        }
    }
}
