using Autofac;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.UseCases.GF.Master;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.Master.RequestHandlersTest
{
    public class SaveFileHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly ISaveFileHandler<MasterRequest> saveFileHandler;

        public SaveFileHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.saveFileHandler = fixture.Container.Resolve<ISaveFileHandler<MasterRequest>>();
        }

        [Fact]
        [Trait("Action", "None")]
        public void ShouldSaveFile()
        {
            string fileName = "GW_MESTRE_01_" + DateTime.UtcNow.ToString("MM") + DateTime.UtcNow.ToString("yyyy") + ".TXT";
            var request = new MasterRequest(Guid.NewGuid());
            var master = new MasterBuilder()
                .WithFileName(fileName)
                .Build();

            request.Masters.Add(master);
            request.FileName = fileName;
            request.TypeInterface = TypeRegister.MASTER;

            saveFileHandler.ProcessRequest(request);

            Assert.NotNull(request.File);
            Assert.Equal(fileName, request.File.FileName);
        }
    }
}
