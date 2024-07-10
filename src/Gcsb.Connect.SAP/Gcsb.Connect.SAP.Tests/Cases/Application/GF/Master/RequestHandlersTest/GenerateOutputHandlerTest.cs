using Autofac;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.UseCases.GF.Master;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.Master.RequestHandlersTest
{
    public class GenerateOutputHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IGenerateOutputHandler<MasterRequest> generateOutputHandler;

        public GenerateOutputHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.generateOutputHandler = fixture.Container.Resolve<IGenerateOutputHandler<MasterRequest>>();
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShouldGenerateOutput()
        {
            var request = new MasterRequest(Guid.NewGuid());
            var item = new MasterBuilder().Build();

            request.Masters.Add(item);
            request.Masters.Add(item);
            request.Masters.Add(item);

            //create filename 
            //GW_MESTRE_ : Fixo
            //Ciclo: 01 Fixo
            //MMYYYY
            request.FileName = "GW_MESTRE_01_" + DateTime.UtcNow.ToString("MMYYYY") + ".TXT";
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
