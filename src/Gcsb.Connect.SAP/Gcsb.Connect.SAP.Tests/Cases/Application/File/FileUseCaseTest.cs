using Autofac;
using Gcsb.Connect.SAP.Application.UseCases.File;
using Xunit;
using System;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Tests.Builders;
using Gcsb.Connect.Messaging.Messages.File.Enum;

namespace Gcsb.Connect.SAP.Tests.Cases.Application
{
    public class FileUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IFileUseCase fileUseCase;
        private readonly IFileReprocessUseCase fileReprocessUseCase;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public FileUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.fileUseCase = fixture.Container.Resolve<IFileUseCase>();
            this.fileReprocessUseCase = fixture.Container.Resolve<IFileReprocessUseCase>();
            this.fileWriteOnlyRepository = fixture.Container.Resolve<IFileWriteOnlyRepository>();
        }

        [Fact]
        [Trait("Action", "Get")]
        public void FileUseCaseTestShouldExecuteARR()
        {
            FileRequest request = new FileRequest(TypeRegister.ARR, null, null, null, null, null, null, null);
            string linkLog = "http://linkLog"; //Link Log
            string linkReprocess = "http://linkReprocess"; //Link Reprocess

            var file = fileUseCase.Execute(request, linkLog, linkReprocess);

            Assert.True(file.Count >= 0);
                
        }

        [Fact]
        [Trait("Action", "Get")]
        public void FileUseCaseTestShouldExecuteARRWithStatus()
        {
            FileRequest request = new FileRequest(TypeRegister.ARR, null, null, null, null, null, null, Status.Error);
            string linkLog = "http://linkLog"; //Link Log
            string linkReprocess = "http://linkReprocess"; //Link Reprocess

            var file = fileUseCase.Execute(request, linkLog, linkReprocess);

            Assert.True(file.Count >= 0);

        }

        [Fact]
        [Trait("Action", "Get")]
        public void FileUseCaseTestShouldExecuteARRWithDate()
        {
            FileRequest request = new FileRequest(TypeRegister.ARR, null, null, DateTime.Now.AddDays(-1), null, null, null, null);
            string linkLog = "http://linkLog"; //Link Log
            string linkReprocess = "http://linkReprocess"; //Link Reprocess

            var file = fileUseCase.Execute(request, linkLog, linkReprocess);

            Assert.True(file.Count >= 0);

        }

        [Fact]
        [Trait("Action", "Get")]
        public void FileUseCaseTestShouldExecuteARRWithStatusAndDate()
        {
            FileRequest request = new FileRequest(TypeRegister.ARR, null, null, DateTime.Now.AddDays(-1), null, null, null, Status.Error);
            string linkLog = "http://linkLog"; //Link Log
            string linkReprocess = "http://linkReprocess"; //Link Reprocess

            var file = fileUseCase.Execute(request, linkLog, linkReprocess);

            Assert.True(file.Count >= 0);
        }

        [Fact]
        [Trait("Action", "Get")]
        public void FileUseCaseTestShouldExecutePAS()
        {
            FileRequest request = new FileRequest(TypeRegister.ARR, null, null, null, null, null, null, null);
            string linkLog = "http://linkLog"; //Link Log
            string linkReprocess = "http://linkReprocess"; //Link Reprocess

            var file = fileUseCase.Execute(request, linkLog, linkReprocess);

            Assert.True(file.Count >= 0);

        }

        [Fact]
        [Trait("Action", "Get")]
        public void FileUseCaseTestShouldExecutePASWithStatus()
        {
            FileRequest request = new FileRequest(TypeRegister.PAS, null, null, null, null, null, null, Status.Error);
            string linkLog = "http://linkLog"; //Link Log
            string linkReprocess = "http://linkReprocess"; //Link Reprocess

            var file = fileUseCase.Execute(request, linkLog, linkReprocess);

            Assert.True(file.Count >= 0);

        }

        [Fact]
        [Trait("Action", "Get")]
        public void FileUseCaseTestShouldExecutePASWithDate()
        {
            FileRequest request = new FileRequest(TypeRegister.PAS, null, null, DateTime.Now.AddDays(-1), null, null, null, null);
            string linkLog = "http://linkLog"; //Link Log
            string linkReprocess = "http://linkReprocess"; //Link Reprocess

            var file = fileUseCase.Execute(request, linkLog, linkReprocess);

            Assert.True(file.Count >= 0);

        }

        [Fact]
        [Trait("Action", "Get")]
        public void FileUseCaseTestShouldExecutePASWithStatusAndDate()
        {
            FileRequest request = new FileRequest(TypeRegister.PAS, null, null, DateTime.Now.AddDays(-1), null, null, null, Status.Error);
            string linkLog = "http://linkLog"; //Link Log
            string linkReprocess = "http://linkReprocess"; //Link Reprocess

            var file = fileUseCase.Execute(request, linkLog, linkReprocess);

            Assert.True(file.Count >= 0);

        }

        [Fact]
        [Trait("Action", "Get")]
        public void FileUseCaseTestShouldExecuteFATWithStatusAndCycle()
        {
            FileRequest request = new FileRequest(TypeRegister.FAT, DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Year, null, null, null, null, Status.Error);
            string linkLog = "http://linkLog"; //Link Log
            string linkReprocess = "http://linkReprocess"; //Link Reprocess

            var file = fileUseCase.Execute(request, linkLog, linkReprocess);

            Assert.False(file == null);
            Assert.True(file.Count >= 0);

        }

        [Fact]
        [Trait("Action", "Get")]
        public void FileUseCaseTestShouldExecuteFATWithStatus()
        {
            FileRequest request = new FileRequest(TypeRegister.FAT, null, null, null, null, null, null, Status.Error);
            string linkLog = "http://linkLog"; //Link Log
            string linkReprocess = "http://linkReprocess"; //Link Reprocess

            var file = fileUseCase.Execute(request, linkLog, linkReprocess);

            Assert.False(file == null);
            Assert.True(file.Count >= 0);

        }

        [Fact]
        [Trait("Action", "Get")]
        public void FileUseCaseTestShouldExecuteFATWithCycle()
        {
            FileRequest request = new FileRequest(TypeRegister.FAT, DateTime.UtcNow.AddMonths(-1).Month, DateTime.UtcNow.AddMonths(-1).Year, null, null, null, null, null);
            string linkLog = "http://linkLog"; //Link Log
            string linkReprocess = "http://linkReprocess"; //Link Reprocess

            var file = fileUseCase.Execute(request, linkLog, linkReprocess);

            Assert.False(file == null);
            Assert.True(file.Count >= 0);
        }

        [Fact]
        [Trait("Action", "FileReprocess")]
        public void ARRUseCaseTestFileReprocess()
        {
            var idFile = Guid.NewGuid();
            var fileParent = FileBuilder.New().WithId(Guid.NewGuid()).WithType(TypeRegister.PAYMENT).Build();
            var file = FileBuilder.New().WithId(idFile).WithIdParent(fileParent.Id).WithType(TypeRegister.ARR).Build();
            var request = new FileReprocessRequest(idFile);

            Assert.True(fileWriteOnlyRepository.Add(fileParent) > 0);
            Assert.True(fileWriteOnlyRepository.Add(file) > 0);
            Assert.True(fileReprocessUseCase.Execute(request) == 1);
        }

        [Fact]
        [Trait("Action", "FileReprocess")]
        public void ARRUseCaseTestFileNotFindExecute()
        {
            Assert.Throws<System.NullReferenceException>(() => fileReprocessUseCase.Execute(new FileReprocessRequest(new System.Guid())));
        }
    }
}
