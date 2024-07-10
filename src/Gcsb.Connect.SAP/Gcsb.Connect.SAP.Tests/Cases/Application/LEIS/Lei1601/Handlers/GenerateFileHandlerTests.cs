using System;
using Gcsb.Connect.SAP.Application.Repositories;
using Moq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.LEIS.Lei1601.Handlers
{
    public class GenerateFileHandlerTests
    {     
        private readonly Mock<IFileGenerator<SAP.Domain.LEI1601.Lei1601>> _fileGenerator = new Mock<IFileGenerator<SAP.Domain.LEI1601.Lei1601>>();

        private readonly SAP.Application.UseCases.Lei1601.RequestHandlers.GenerateFileHandler _handler;

        public GenerateFileHandlerTests()
        {
            _handler = new SAP.Application.UseCases.Lei1601.RequestHandlers.GenerateFileHandler(_fileGenerator.Object);
        }

        [Fact]
        public void Execute()
        {
            _fileGenerator
                .Setup(x => x.ValidateModel(It.IsAny<SAP.Domain.LEI1601.Lei1601>()))
                .Returns(true);

            _fileGenerator
                .Setup(x => x.Generate(It.IsAny<SAP.Domain.LEI1601.Lei1601>()))
                .Returns("test");

            var request = new SAP.Application.UseCases.Lei1601.Lei1601Request
            {
                ProcessDate = DateTime.Now,
                ReferenceDate = DateTime.Now.AddDays(-1),
                Sequence = 1
            };

            _handler.ProcessRequest(request);

            _fileGenerator
                .Verify(x => x.SaveFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once());

            Assert.True(request.Files.Count.Equals(1));
        }      
    }
}
