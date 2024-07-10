using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook;
using Gcsb.Connect.SAP.Domain.GF;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.TextFile
{
    public class AxiliaryBookTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IFileGenerator<AxiliaryBookRequest> srFileGeneration;
        private readonly string launchFormat = @"^([\w\s]{9})([\w\s]{9})(GW[\w]{14})(CL)(\d{8})(Fatura)(NFS)([\w\s]{28})([\w\W\s]{15})([\s]{5})(\d{8})(\d{8})(\d{15})(D)([\w\s]{40})([\d]{15})([\d]{15})([\d]{15})([\d]{15})([\w\s]{150})([\w\s]{150})([\w\s]{150})([\w\s]{150})([\w\s]{150})([\w\s]{9})";
        private readonly string FileNameFormat = @"^(GW_LIVRO)_([\d]{2})_([\d]{6})(.TXT)$";

        public AxiliaryBookTest(Fixture.ApplicationFixture fixture)
        {            
            srFileGeneration = fixture.Container.Resolve<IFileGenerator<AxiliaryBookRequest>>();
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateFile()
        {

            var model = AxiliaryBookBuilder.New().Build();
            var request = new AxiliaryBookRequest(Guid.NewGuid());

            request.LaunchItems.Add(model);

            var strFile = srFileGeneration.Generate(request);
            Assert.NotNull(strFile);

        }

        [Fact]
        [Trait("Action", "None")]
        public void ShouldIsValidLaunch()
        {
            var model = AxiliaryBookBuilder.New().Build();
            var request = new AxiliaryBookRequest(Guid.NewGuid());

            request.LaunchItems.Add(model);
            
            var strFile = srFileGeneration.Generate(request);

            Regex r = new Regex(launchFormat, RegexOptions.Singleline);
            Match m = r.Match(strFile);
            Assert.True(m.Success);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShouldisValidFileName()
        {
            var model = AxiliaryBookBuilder.New().Build();

            Regex r = new Regex(FileNameFormat, RegexOptions.Singleline);
            var m = r.Match(model.FileName);
            Assert.True(m.Success);
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShouldGenerateAxiliaryBookInOutputFolder()
        {
            var model = AxiliaryBookBuilder.New().Build();
            var request = new AxiliaryBookRequest(Guid.NewGuid());

            request.LaunchItems.Add(model);

            var strFile = srFileGeneration.Generate(request);
          
            srFileGeneration.SaveFile(strFile, Environment.GetEnvironmentVariable("OUTPUT_SAP"), model.FileName);
            Assert.True(File.Exists(Path.Combine(Environment.GetEnvironmentVariable("OUTPUT_SAP"), model.FileName)));
        }

    }
}
