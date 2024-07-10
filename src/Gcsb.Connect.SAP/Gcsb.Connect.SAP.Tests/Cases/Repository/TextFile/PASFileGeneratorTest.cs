using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.TextFile
{
    public class PASFileGeneratorTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private SAP.Application.Repositories.IFileGenerator<SAP.Domain.PAS.PAS> pasFileGeneration;

        private readonly string headerFormat = @"(HD);(TBRA);(19|20)\d\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01]);([0-5]?\d+);(GLWEB);(29SP);";
        private readonly string lineFormat = @"^\d{6};(19|20)\d\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01]);(\w+);((\w|\s|\d)+);(([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]|\s)+);[A-Z]{2};\d{5}-\d{3};\d+;\d+,\d{2};[a-zA-Z0-9\-'\s]+;;;;;;\d{4}\*{8}\d{4};\d+;\d+;00[1-6];;002;";
        private readonly string footerFormat = @"^TR;\d{7};";

        public PASFileGeneratorTest(Fixture.ApplicationFixture fixture)
        {
            pasFileGeneration = fixture.Container.Resolve<SAP.Application.Repositories.IFileGenerator<SAP.Domain.PAS.PAS>>();
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateFile()
        {
            var model = Builders.Build.PAS.Build();

            var strFile = pasFileGeneration.Generate(model);

            Assert.NotNull(strFile);

        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateValidHeader()
        {
            var model = Builders.Build.PAS.Build();
            var strFile = pasFileGeneration.Generate(model);
            var txt = strFile.Split(Environment.NewLine)[0];

            Regex r = new Regex(headerFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);

            Assert.NotNull(strFile);

        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateValidLine()
        {
            var model = Builders.Build.PAS.Build();
            var strFile = pasFileGeneration.Generate(model);
            var txt = strFile.Split(Environment.NewLine)[1];

            Regex r = new Regex(lineFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);

            Assert.NotNull(strFile);
        }
        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateValidFooter()
        {
            var model = Builders.Build.PAS.Build();
            var strFile = pasFileGeneration.Generate(model);
            var txt = strFile.Split(Environment.NewLine).ToList().Last();

            Regex r = new Regex(footerFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);

            Assert.NotNull(strFile);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShouldGeneratePASFileInOutputFolder()
        {
            var model = Builders.Build.PAS.Build();
            var strFile = pasFileGeneration.Generate(model);            
            pasFileGeneration.SaveFile(strFile, Environment.GetEnvironmentVariable("OUTPUT_SAP"), model.Header.GetFileName());            
        }
    }
}
