using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.GF.CISS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.TextFile
{
    public class CISSFileGeneratorTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IFileGenerator<CISSRequest> cissFileGeneration;

        private const string valueFormat = @"^(TBRA)(\s{5})((\d|\s){9})(@\s{4})(\d{15})(\d{8})(\d{5})((Vivo Plataforma Digital)\s{127})(\d{17})(\d{7})(\d{17})(\d{7})(\d{17})(01)(01)";

        public CISSFileGeneratorTest(Fixture.ApplicationFixture fixture)
        {
            cissFileGeneration = fixture.Container.Resolve<IFileGenerator<CISSRequest>>();
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateFile()
        {
            var request = new CISSRequest(Guid.NewGuid());
            var model = Builders.Build.CISS.Build();

            request.LaunchItems.Add(model);
           
            var strFile = cissFileGeneration.Generate(request);
            Assert.NotNull(strFile);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateValidValueLine()
        {
            var request = new CISSRequest(Guid.NewGuid());
            var model = Builders.Build.CISS.Build();

            request.LaunchItems.Add(model);

            var strFile = cissFileGeneration.Generate(request);
            var txt = strFile.Split(Environment.NewLine)[0];

            Regex r = new Regex(valueFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }

        [Fact]
        public void ShouldGenerateCISSFileInOutputFolder()
        {
            var request = new CISSRequest(Guid.NewGuid());
            var model = Builders.Build.CISS.Build();
            var fileName = $"GW_CISS_01_{model.CycleDate.ToString("MMyyyy")}.TXT";

            request.LaunchItems.Add(model);
            var strFile = cissFileGeneration.Generate(request);

            cissFileGeneration.SaveFile(strFile, Environment.GetEnvironmentVariable("OUTPUT_SAP"), fileName);
            Assert.True(File.Exists(Path.Combine(Environment.GetEnvironmentVariable("OUTPUT_SAP"), fileName)));
        }
    }
}
