using Autofac;
using Gcsb.Connect.SAP.Domain.FAT.FATaFaturarECM;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.TextFile
{
    public class FatECMFileGeneratorTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private SAP.Application.Repositories.IFileGenerator<FATaFaturarECM> fatFileGeneration;

        private const string headerFormat = @"(IDFAT58TB)(\d\d\d\d\d\d\d\d\d\d)(19|20)\d\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])\.TXT (0[1-9]|[12][0-9]|3[01])(0[1-9]|1[012])(19|20)\d\d([0-5]?\d)([0-5]?\d)([0-5]?\d)";
        private const string valueFormat = @"(D1)(\d{10})(0[1-9]|[12][0-9]|3[01])(0[1-9]|1[012])(19|20)\d{2}(ECM)(\s{7})((\w|\s){15})(\s{2})(\s*)(\d+\,\d{2})(\s{15}\s{16}(\s{7}))(GW29TR018233)((\w|\s){12})(\s{12})(01)(19|20)\d\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])(\s{10}\s{16})(\d{4})([a-zA-Z\u00C0-\u00FF ]{20})(Pos|Pre)(\s{1})((D|C)\s{1})([a-zA-Z\u00C0-\u00FF ]{10})(\w{2})";
        private const string header2Format = @"(HH)(FAT)(TBRA)(29SP)";
        private const string footerFormat = @"(FF)(\d+).*?(\d+)(,)(\d\d)";

        public FatECMFileGeneratorTest(Fixture.ApplicationFixture fixture)
        {
            fatFileGeneration = fixture.Container.Resolve<SAP.Application.Repositories.IFileGenerator<FATaFaturarECM>>();
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateFile()
        {
            var model = Builders.Build.FAT58.Build();
            string strFile = fatFileGeneration.Generate(model);
            Assert.NotNull(strFile);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateValidHeaderFile()
        {
            var model = Builders.Build.FAT58.Build();
            string strFile = fatFileGeneration.Generate(model);

            var txt = strFile.Split(Environment.NewLine)[0];

            Regex r = new Regex(headerFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateInValidHeaderFile()
        {
            var model = Builders.Build.FAT58.Build();
            string strFile = fatFileGeneration.Generate(model);

            var txt = strFile.Split(Environment.NewLine)[0];
            txt = txt.Replace("FAT", "FAS");

            Regex r = new Regex(headerFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.False(m.Success);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateValidSecondLine()
        {
            var model = Builders.Build.FAT58.Build();
            string strFile = fatFileGeneration.Generate(model);

            var txt = strFile.Split(Environment.NewLine)[1];

            Regex r = new Regex(header2Format, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateValidValueLine()
        {
            var model = Builders.Build.FAT58.Build();
            string strFile = fatFileGeneration.Generate(model);

            var txt = strFile.Split(Environment.NewLine)[2];

            Regex r = new Regex(valueFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateValidLastLine()
        {
            var model = Builders.Build.FAT58.Build();
            string strFile = fatFileGeneration.Generate(model);

            var txt = strFile.Split(Environment.NewLine).ToList().Last();

            Regex r = new Regex(footerFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }

        [Fact]
        public void ShouldGenerateFATFileInOutputFolder()
        {
            var model = Builders.Build.FAT58.Build();
            string strFile = fatFileGeneration.Generate(model);

            fatFileGeneration.SaveFile(strFile, Environment.GetEnvironmentVariable("OUTPUT_SAP"), model.IdentificationRecord.FileName);
        }
    }
}
