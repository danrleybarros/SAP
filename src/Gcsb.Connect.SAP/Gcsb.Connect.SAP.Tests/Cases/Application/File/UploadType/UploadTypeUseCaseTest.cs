using Autofac;
using Xunit;
using Gcsb.Connect.SAP.Application.UseCases.Files.UploadType;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.UploadType
{
    public class UploadTypeUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IGetUploadTypeUseCase getUploadTypeUseCase;

        public UploadTypeUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.getUploadTypeUseCase = fixture.Container.Resolve<IGetUploadTypeUseCase>();
        }

        [Fact(DisplayName = "Should Execute with success")]
        [Trait("Action", "Execution")]
        public void GetUploadTypeUseCase_ShouldExecuteWithSucess()
        {
            var request = new GetUploadTypeUseCaseRequest(1);

            getUploadTypeUseCase.Execute(request);

            Assert.True(request.UploadTypes.Count > 0);
            Assert.True(request.HasExecuted);
        }
    }
}
