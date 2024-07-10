using Autofac;
using Gcsb.Connect.SAP.Application.UseCases.Files.UploadType;
using Gcsb.Connect.SAP.Domain.UploadTypeDto;
using Gcsb.Connect.SAP.Tests.Builders.UploadType;
using Gcsb.Connect.SAP.Tests.Mock;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.UploadType;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.SAP.Tests.Cases.WebApi.Controllers.UploadType
{
    [UseAutofacTestFramework]
    public class UploadTypeControllerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IGetUploadTypeUseCase getUploadTypeUseCase;
        private readonly UploadTypePresenter presenter;
        private readonly IdentityParser identityParser;
        private UploadTypeDto uploadType;
        private HttpContext httpContext; 

        public UploadTypeControllerTest(Fixture.ApplicationFixture fixture)
        {
            getUploadTypeUseCase = fixture.Container.Resolve<IGetUploadTypeUseCase>();
            presenter = fixture.Container.Resolve<UploadTypePresenter>();
            identityParser = fixture.Container.Resolve<IdentityParser>();
        }

        private void Mock()
        {
            uploadType = UploadTypeBuilder.New().Build();
            var mock = new HttpContextMock();
            httpContext = mock.Execute().Object;
        }

        [Fact(DisplayName = "Should Execute Controller")]
        [Trait("Action", "Get")]
        public void ShouldExecuteController()
        {
            //Assert
            Mock();

            //Action
            var controller = new SAP.WebApi.Config.UseCases.Files.UploadType.FileController(identityParser, getUploadTypeUseCase, presenter);
            controller.ControllerContext.HttpContext = httpContext;
            var output = controller.GetUploadType();

            //Assert
            Assert.True(output.Result.GetType() == typeof(OkObjectResult));
        }
    }
}
