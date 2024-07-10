using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.GF;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.TextFile
{
    public class SpecialRegimeFileGeneratorTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IFileGenerator<List<SpecialRegime>> srFileGeneration;
        private readonly string lineFormat = @"^([a-zA-Z0-9\-]+;)([\w\s]){1,10};([\w\s]){1,};([\w\s]){1,};;;([0-9]{1,2}\/[0-9]{1,2}\/[0-9]{4});([\w\s]){1,};[0-9]+(\,[0-9]{1,2})?;[0-9]+(\,[0-9]{1,2})?;[-]?[0-9]+(\,[0-9]{1,2})?;[0-9]+(\,[0-9]{1,2})?;[0-9]+(\,[0-9]{1,2})?;[0-9]+(\,[0-9]{1,2})?;;;[\d]{1,14};([a-zA-Z0-9\-]+;);([\w\s]){1,35};[\d]{1,8};([\w\s]){1,60};;[\d]{1,11};[\d]{1,14};([\w\s]){1,};([\w\s]){1,};([/]?[\w\s]){1,150};([.]?[\w\s]){1,10};\d+;([0-9]{1,2}\/[0-9]{1,2}\/[0-9]{4})";

        public SpecialRegimeFileGeneratorTest(Fixture.ApplicationFixture fixture)
        {
            srFileGeneration = fixture.Container.Resolve<IFileGenerator<List<SpecialRegime>>>();
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateFile()
        {
            var model = new List<SpecialRegime>()
            {
                SpecialRegimeBuilder.New().Build(),
                SpecialRegimeBuilder.New().Build(),
                SpecialRegimeBuilder.New().Build()
            };

            var strFile = srFileGeneration.Generate(model);

            Assert.NotNull(strFile);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateValidLine()
        {
            var model = new List<SpecialRegime>()
            {
                SpecialRegimeBuilder.New().Build(),
                SpecialRegimeBuilder.New().Build(),
            };

            var r = new Regex(lineFormat, RegexOptions.Singleline);
            var strFile = srFileGeneration.Generate(model);
            var txt = strFile.Split(Environment.NewLine)[1];
            var m = r.Match(txt);

            Assert.True(m.Success);
            Assert.NotNull(strFile);
        }
    }
}
