using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.Repositories.Lei1601;
using Gcsb.Connect.SAP.Application.UseCases.Lei1601.RequestHandlers;
using Gcsb.Connect.SAP.Domain.LEI1601;
using Gcsb.Connect.SAP.Tests.Builders.LEIS.Lei1601;
using Moq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.LEIS.Lei1601.Handlers
{
    public class GetDataHandlerTests
    {
        private readonly Mock<ILei1601Repository> _repository = new Mock<ILei1601Repository>();

        private readonly GetDataHandler handler;

        public GetDataHandlerTests()
        {
            handler = new GetDataHandler(_repository.Object);
        }

        [Fact]
        public void Execute()
        {
            var result = new List<Launch>
            {
                LaunchBuilder.New().Build()
            };

            _repository
                .Setup(x => x.GetAll())
                .Returns(result);

            var request = new SAP.Application.UseCases.Lei1601.Lei1601Request();

            handler.ProcessRequest(request);

            Assert.True(request.Lines.Count.Equals(1));
        }

        [Fact]
        public void ExecuteWithNoContent()
        {
            var result = new List<Launch>();

            _repository
                .Setup(x => x.GetAll())
                .Returns(result);

            var request = new SAP.Application.UseCases.Lei1601.Lei1601Request();

            handler.ProcessRequest(request);

            Assert.True(request.Lines.Count.Equals(0));
        }
    }
}
