using Autofac;
using Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService.RequestHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.TextFile
{
    public class IndividualReportServiceFileGeneratorTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private SAP.Application.Repositories.IFileGenerator<ISIObj> fileGenerator;
        private List<SAP.Domain.GF.IndividualReportService> individualReportServices;
        private readonly string lineFormat = @"^(1.03)\s{56}(\d{4}\d{2}\d{2})(Processamento,armaz. ou hosped. de dados, textos, imagens, videos, paginas eletronicas, apps e sist. de info., entre outros formatos e congeneres)\s{5}(SP)(Vivo Plataforma Digital)\s{127}(1.03)\s{1}";

        public IndividualReportServiceFileGeneratorTest(Fixture.ApplicationFixture fixture)
        {
            fileGenerator = fixture.Container.Resolve <SAP.Application.Repositories.IFileGenerator<ISIObj>>();

            individualReportServices = new List<SAP.Domain.GF.IndividualReportService>()
            {
                Builders.GF.IndividualReportServiceBuilder.New().Build(),
            };
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShouldGenerateFile()
        {
            var model = new ISIObj(individualReportServices);
            var strFile = fileGenerator.Generate(model);
            Assert.NotNull(strFile);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateValidLine()
        {
            var r = new Regex(lineFormat, RegexOptions.Singleline);
            var model = new ISIObj(individualReportServices);
            var strFile = fileGenerator.Generate(model);
            var valid = true;

            strFile.Split(Environment.NewLine)
                .Select(s => s)
                .ToList()
                .ForEach(e => {
                    if (string.IsNullOrEmpty(e))
                        return;

                    Match m = r.Match(e);
                    if (!m.Success)
                        valid = false;
                });

            Assert.True(valid);

            Assert.NotNull(strFile);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShouldGenerateISIFileInOutputFolder()
        {
            var model = new ISIObj(individualReportServices);
            var strFile = fileGenerator.Generate(model);

            var updateDataService = individualReportServices.Select(s => s.UpdateDataService).FirstOrDefault();
            var MMyyyy = updateDataService.ToString("MM") + updateDataService.ToString("yyyy");

            fileGenerator.SaveFile(strFile, Environment.GetEnvironmentVariable("OUTPUT_SAP"), $"GW_SERVICOS_01_" + MMyyyy + ".TXT");
        }
    }
}
