using Autofac;
using Gcsb.Connect.SAP.Application.UseCases.GF.Items;
using Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.Items.RequestHandlersTest
{
    public class GenerateOutputHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly GenerateOutputHandler generateOutputHandler;

        public GenerateOutputHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.generateOutputHandler = fixture.Container.Resolve<GenerateOutputHandler>();
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShouldGenerateOutput()
        {
            var request = new ItemsRequest(Guid.NewGuid());
            request.FileName = "GFItemsInterface";
            var item = new ItemsBuilder().Build();

            request.Items.Add(item);
            request.Items.Add(item);
            request.Items.Add(item);

            generateOutputHandler.ProcessRequest(request);

            Assert.True(!string.IsNullOrEmpty(request.OutputFile));
            Assert.True(request.OutputFile.Length > 0);
        }

        [Fact]
        [Trait("Action", "Exception")]
        public void ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => generateOutputHandler.ProcessRequest(null));
        }
    }
}
