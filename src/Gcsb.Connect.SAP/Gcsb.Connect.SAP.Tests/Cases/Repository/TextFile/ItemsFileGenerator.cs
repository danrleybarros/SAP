using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.GF.Items;
using Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using System;
using System.Text.RegularExpressions;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.TextFile
{
    public class ItemsFileGenerator : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IFileGenerator<ItemsRequest> fileGenerator;
        private readonly GenerateOutputHandler generateOutputHandler;
        private readonly string itemFormat = @"^(\w|\s){18}(NFS@)\s{4}\d{15}(\d{4}\d{2}\d{2})(CL)(GW(\w|\s){14})\s{28}(29TR018233\s{18})(1.03)(\w|\s){56}(Processamento,armaz. ou hosped. de dados, textos, imagens, videos, paginas eletronicas, apps e sist. de info., entre outros formatos e congeneres)(\s{5})(\d{17})(\d{17})(00)(\d{17})(\d{17})(\d{17})(\d{17})\d{5}(13)\d{7}(Vivo Plataforma Digital\s{127})(1.03)\s{1}(41431077)\s{20}";

        public ItemsFileGenerator(Fixture.ApplicationFixture fixture)
        {
            this.fileGenerator = fixture.Container.Resolve<IFileGenerator<ItemsRequest>>();
            this.generateOutputHandler = fixture.Container.Resolve<GenerateOutputHandler>();
        }

        [Fact]
        [Trait("Action", "Validate")]
        public void ShouldGenerateValidItem()
        {
            var request = new ItemsRequest(Guid.NewGuid())
            {
                FileName = "GW_ITENS_CC_032019.TXT"
            };

            var item = new ItemsBuilder().Build();

            request.Items.Add(item);

            generateOutputHandler.ProcessRequest(request);

            var txt = request.OutputFile.Split(Environment.NewLine)[0];

            Regex r = new Regex(itemFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }

        [Theory]
        [InlineData("GW_ITENS_CC_032019.TXT")]
        public void ShouldSaveFile(string fileName)
        {
            var request = new ItemsRequest(Guid.NewGuid());

            for (var i = 0; i < 100; i++)
                request.Items.Add(new ItemsBuilder().WithSequentialNumberNote(i + 1).Build());

            var output = fileGenerator.Generate(request);
            fileGenerator.SaveFile(output, Environment.GetEnvironmentVariable("OUTPUT_SAP"), fileName);

            Assert.True(output.Length > 0);
        }
    }
}