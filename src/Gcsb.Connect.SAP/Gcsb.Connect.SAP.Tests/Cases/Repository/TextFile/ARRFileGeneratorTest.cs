using Autofac;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.TextFile
{
    public class ARRFileGeneratorTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private SAP.Application.Repositories.IFileGenerator<SAP.Domain.ARR.CreditCard.ARRCreditCard> ARRFileGeneration;

        private string identificationFormat = @"^IDARR55TB29\d{2}\d{4}.TXT (0[1-9]|[12][0-9]|3[01])(0[1-9]|1[012])(19|20)\d\d\d{6}";
        private string headerFormat = @"^HHARRTBRA\s{8}\s{8}(0[1-9]|1[012])(19|20)\d\d29SP";
        private string lineFormat = @"^D1\d{10}(0[1-9]|[12][0-9]|3[01])(0[1-9]|1[012])(19|20)\d\dGP\s{8}[a-zA-Z0-9\s]{15}\s{2}\s*\d+,\d{2}\s{10}";
        private string footerFormat = @"^FF\d{6}\s{16}\s{16}\s*\d+,\d{2}";

        public ARRFileGeneratorTest(Fixture.ApplicationFixture fixture)
        {
            ARRFileGeneration = fixture.Container.Resolve<SAP.Application.Repositories.IFileGenerator<SAP.Domain.ARR.CreditCard.ARRCreditCard>>();
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateFile()
        {
            var model = Builders.Build.ARR.Build();
            ARRFileGeneration.Generate(model);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudIsValidIdentification()
        {

            var model = Builders.Build.ARR.Build();
            string strFile = ARRFileGeneration.Generate(model);

            var txt = strFile.Split(Environment.NewLine)[0];

            Regex r = new Regex(identificationFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }
        [Fact]
        [Trait("Action", "None")]
        public void ShoudIsValidHeader()
        {

            var model = Builders.Build.ARR.Build();
            string strFile = ARRFileGeneration.Generate(model);

            var txt = strFile.Split(Environment.NewLine)[1];

            Regex r = new Regex(headerFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }
        [Fact]
        [Trait("Action", "None")]
        public void ShoudIsValidLine()
        {
            var model = Builders.Build.ARR.Build();
            string strFile = ARRFileGeneration.Generate(model);

            var txt = strFile.Split(Environment.NewLine)[2];

            Regex r = new Regex(lineFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }
        [Fact]
        [Trait("Action", "None")]
        public void ShoudIsValidFooter()
        {
            var model = Builders.Build.ARR.Build();
            string strFile = ARRFileGeneration.Generate(model);

            var txt = strFile.Split(Environment.NewLine).ToList().Last();

            Regex r = new Regex(footerFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }

        [Fact]
        public void ShouldGenerateARRFileInOutputFolder()
        {
            var model = Builders.Build.ARR.Build();
            var strFile = ARRFileGeneration.Generate(model);
            ARRFileGeneration.SaveFile(strFile, Environment.GetEnvironmentVariable("OUTPUT_SAP"), model.IdentificationRegister.FileName);
        }
    }
}
