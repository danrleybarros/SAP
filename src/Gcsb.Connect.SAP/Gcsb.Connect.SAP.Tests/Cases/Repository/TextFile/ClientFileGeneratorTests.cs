using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.GF.Client.RequestHandlers;
using Gcsb.Connect.SAP.Domain.GF;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.TextFile
{
    public class ClientFileGeneratorTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IFileGenerator<ClientObj> srFileGeneration;
        private readonly string lineFormat = @"^([\w\s]){16}((?:19|20)\d\d)(0?[1-9]|1[012])([12][0-9]|3[01]|0?[1-9])([a-zA-Z]){2}([a-zA-Z]){3}([a-zA-Z]){2}((\d|\s){16})([J|F]){1}([\w\s]){14}([\w\s]){70}([\w\s]){70}((\d|\s)){12}([\w\s]){45}([\w\s?]){60}([\w\s]){50}(\d){8}([\w\s]){150}(\d){7}";

        public ClientFileGeneratorTests(Fixture.ApplicationFixture fixture)
        {
            this.srFileGeneration = fixture.Container.Resolve<IFileGenerator<ClientObj>>();
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShouldGenerateFileClientGF()
        {
            var listClient = new List<Client>()
            {
            ClientBuilder.New().Build(),
            ClientBuilder.New().Build(),
            ClientBuilder.New().Build()
            };

            var model = new ClientObj(listClient);
            var strFile = srFileGeneration.Generate(model);
            Assert.NotNull(strFile);
        }


        [Fact]
        [Trait("Action", "None")]
        public void ShoudGenerateValidLineGF()
        {
            var listClient = new List<Client>()
            {
                ClientBuilder.New().Build(),
                ClientBuilder.New().Build(),
                ClientBuilder.New().Build()
            };

            var model = new ClientObj(listClient);
            var strFile = srFileGeneration.Generate(model);

            var txt = strFile.Split(Environment.NewLine)[1];
            Regex r = new Regex(lineFormat, RegexOptions.Singleline);
            Match m = r.Match(txt);
            Assert.True(m.Success);
        }
    }
}
