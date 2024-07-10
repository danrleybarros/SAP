using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.TextFile
{
    public class AJUFileGeneratorTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IFileGenerator<SAP.Domain.AJU.AJU> fileGenerator;
        private readonly string identificationFormat = @"^(ID)(FAT)(57)(TB)(29)\d{2}\d{4}\d{10}.TXT \d{14}";
        private readonly string headerFormat = @"^(HH)(FAT)(TBRA)(29SP)";
        private readonly string launchFormat = @"^(D1)(\d{10})((21)\d{6})(REVCONT\s{3}|CONT\s{6})((\w|\s|\d){15})(\s{2})([0-9 ]{13},\d{2})(\s{15})(\s{16})(\s{7})(GW)(29TR018233)((\w|\s|\d){12})(\s{12})((01)(\d{8}))(\s{10})(\s{16})(\d{4})((\w|\s){20})(Pre|Pos)(\s{1})(D|C)\s{1}([\w\s]{10})(\w{2})";
        private readonly string footerFormat = @"(FF)(\d+).*?(\d+)(,)(\d\d)";

        public AJUFileGeneratorTest(Fixture.ApplicationFixture fixture)
        {
            fileGenerator = fixture.Container.Resolve<IFileGenerator<SAP.Domain.AJU.AJU>>();
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateFile()
        {
            var model = Builders.Build.AJU.Build();
            var strFile = fileGenerator.Generate(model);

            Assert.NotNull(strFile);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudIsValidIdentification()
        {
            var model = Builders.Build.AJU.Build();
            var strFile = fileGenerator.Generate(model);
            var txt = strFile.Split(Environment.NewLine)[0];

            Regex r = new Regex(identificationFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudIsValidHeader()
        {
            var model = Builders.Build.AJU.Build();
            var strFile = fileGenerator.Generate(model);
            var txt = strFile.Split(Environment.NewLine)[1];

            Regex r = new Regex(headerFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudIsValidLaunch()
        {
            var model = Builders.Build.AJU.Build();
            var strFile = fileGenerator.Generate(model);
            var txt = strFile.Split(Environment.NewLine)[2];

            Regex r = new Regex(launchFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudIsValidFooter()
        {
            var model = Builders.Build.AJU.Build();
            var strFile = fileGenerator.Generate(model);
            var txt = strFile.Split(Environment.NewLine).ToList().Last();

            Regex r = new Regex(footerFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }

        [Fact]
        public void ShouldGenerateAJUFileInOutputFolder()
        {
            var model = Builders.Build.AJU.Build();
            var strFile = fileGenerator.Generate(model);

            fileGenerator.SaveFile(strFile, Environment.GetEnvironmentVariable("OUTPUT_SAP"), model.IdentificationRegister.FileName);
            Assert.True(File.Exists(Path.Combine(Environment.GetEnvironmentVariable("OUTPUT_SAP"), model.IdentificationRegister.FileName)));
        }
    }
}
