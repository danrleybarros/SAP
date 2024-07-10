using System;
using Autofac;
using FluentAssertions;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.File;
using Gcsb.Connect.SAP.Application.UseCases.File.Upload;
using Gcsb.Connect.SAP.Tests.Builders;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Files.UploadStatus
{
  
    public class UploadTypeUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IUploadStatusUseCase uploadStatusUseCase;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public UploadTypeUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.uploadStatusUseCase = fixture.Container.Resolve<IUploadStatusUseCase>();
            this.fileWriteOnlyRepository = fixture.Container.Resolve<IFileWriteOnlyRepository>();

        }


        [Fact]
        [TestPriority(0)]
        public void ShouldAddFile()
        {
            File file = FileBuilder.New().Build();

            fileWriteOnlyRepository.Add(file).Should().BeGreaterThan(0);

        }


        [Fact(DisplayName = "Should Execute with success")]
        [TestPriority(1)]

        public void GetUploadStatusUseCase_ShouldExecuteWithSucess()
        {
            var request = new UploadStatusRequest("");

                
            uploadStatusUseCase.Execute(request);

            Assert.True(request.Uploads.Count > 0);
            Assert.True(request.HasExecuted);
        }

    }
}
