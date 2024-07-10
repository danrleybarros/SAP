using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport;
using Gcsb.Connect.SAP.Domain.GF;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.TextFile
{
    public class IndividualReportNFFileGeneratorTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IFileGenerator<List<IndividualReportNF>> fileGenerator;
        private readonly string individualReport = @"^(\w);(\d{2}\/\d{2}\/\d{4});(\d{2}\/\d{2}\/\d{4});(?:[^_\W]|-)+;(\d{2}\/\d{2}\/\d{4});(1);\d+,\d{2};\w{2};\d+;0,00;(\d+,\d{2});(\d+,\d{2});(\d+,\d{2});(\d{14}|\d{11});(\d{2}\/\d{2}\/\d{4});(001);(1.03);\d+;(UM);(Processamento,armaz. ou hosped. de dados, textos, imagens, videos, paginas eletronicas, apps e sist. de info., entre outros formatos e congeneres);\d+,\d{2};(\w+(\s+\w+)*);(\w+(\s+\w+)*);(\w+(\s+\w+)*);(\w+(\s+\w+)*);(\w+(\s+\w+)*);(\d{8});([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+);(\w+(\s+\w+)*)";

        public IndividualReportNFFileGeneratorTest(Fixture.ApplicationFixture fixture)
        {
            this.fileGenerator = fixture.Container.Resolve<IFileGenerator<List<IndividualReportNF>>>();
        }

        [Fact]
        [Trait("Action", "Validate")]
        public void ShouldGenerateValidLineReport()
        {
            var request = new IndividualReportRequestNF(Guid.NewGuid());

            request.IndividualReports.AddRange(new List<IndividualReportNF>()
            {
                new IndividualReportNFBuilder().Build(),
            });

            var output = fileGenerator.Generate(request.IndividualReports);
            var txt = output.Split(Environment.NewLine)[1];
            var r = new Regex(individualReport, RegexOptions.Singleline);
            var m = r.Match(txt);

            Assert.True(m.Success);
        }

        [Theory]
        [InlineData("EMISSAO-NF-IND-032019.csv")]
        public void ShouldSaveFile(string fileName)
        {
            var request = new IndividualReportRequestNF(Guid.NewGuid());

            for (var i = 0; i < 100; i++)
                request.IndividualReports.Add(new IndividualReportNFBuilder().WithCCM((i + 1).ToString()).Build());

            var output = fileGenerator.Generate(request.IndividualReports);
            fileGenerator.SaveFile(output, Environment.GetEnvironmentVariable("OUTPUT_SAP"), fileName);

            Assert.True(output.Length > 0);
        }
    }
}
