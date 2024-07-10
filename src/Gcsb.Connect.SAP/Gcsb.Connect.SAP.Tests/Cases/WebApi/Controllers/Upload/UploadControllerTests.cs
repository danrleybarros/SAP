using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.UseCases.Files.Upload;
using Gcsb.Connect.SAP.Tests.Builders.Upload;
using Gcsb.Connect.SAP.Tests.Mock;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.Upload;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.SAP.Tests.Cases.WebApi.Controllers.Upload
{
    [UseAutofacTestFramework]
    public class UploadControllerTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IUploadUseCase uploadUseCase;
        private readonly IdentityParser identityParser;
        private SAP.Domain.Upload.Upload upload;
        private HttpContext httpContext;

        public UploadControllerTests(Fixture.ApplicationFixture fixture)
        {
            uploadUseCase = fixture.Container.Resolve<IUploadUseCase>();
            identityParser = fixture.Container.Resolve<IdentityParser>();
        }
        private void Mock()
        {
            upload= UploadBuilder.New().Build();
            var mock = new HttpContextMock();
            httpContext = mock.Execute().Object;
        }

        [Fact]
        public void ShouldExecuteUploadController()
        {
            Mock();

            var controller = new FileController(identityParser, uploadUseCase);
            controller.ControllerContext.HttpContext = httpContext;
            var request = UploadRequestBuilder.New().Build();
            var output = controller.Upload(request);

            output.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldExecuteUploadBase64Controller()
        {
            Mock();

            var controller = new FileController(identityParser, uploadUseCase);
            controller.ControllerContext.HttpContext = httpContext;
            var request = UploadRequestBuilder.New().Build64();
            var output = controller.UploadBase64(request);

            output.Should().BeOfType<OkObjectResult>();
        }
    }
}
