using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using FluentAssertions;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.Upload;
using Gcsb.Connect.SAP.Application.UseCases.Files.Upload.Handlers;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Files.Upload
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class UploadUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly RegisterUploadHandler registerUploadHandler;
        private readonly CleanDataHandler cleanDataHandler;
        private readonly UploadFileHandler uploadFileHandler;
        private readonly InsertQueueHandler insertQueueHandler;

        private readonly IUploadUseCase uploadUseCase;

        public UploadUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            registerUploadHandler = fixture.Container.Resolve<RegisterUploadHandler>();
            cleanDataHandler = fixture.Container.Resolve<CleanDataHandler>();
            uploadFileHandler = fixture.Container.Resolve<UploadFileHandler>();
            insertQueueHandler = fixture.Container.Resolve<InsertQueueHandler>();

            registerUploadHandler.SetSucessor(cleanDataHandler);
            cleanDataHandler.SetSucessor(uploadFileHandler);
            uploadFileHandler.SetSucessor(insertQueueHandler);

            uploadUseCase = fixture.Container.Resolve<IUploadUseCase>();
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldExecuteUploadUseCase()
        {
            var request = new UploadUseCaseRequest(SAP.Domain.Upload.Enum.UploadTypeEnum.Billfeed, "TestName", "Base64String", "1234");

            uploadUseCase.Execute(request);
            Assert.True(request.Logs.Count > 0);
        }
    }
}
