using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.Application.UseCases.Files.UploadType;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.UploadType
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IGetUploadTypeUseCase getUploadTypeUseCase;
        private readonly IIdentityParser<UserInfo> identityParser;
        private readonly UploadTypePresenter presenter;

        public FileController(IIdentityParser<UserInfo> identityParser, IGetUploadTypeUseCase getUploadTypeUseCase,
                                    UploadTypePresenter presenter)
        {
            this.identityParser = identityParser;
            this.getUploadTypeUseCase = getUploadTypeUseCase;
            this.presenter = presenter;
        }

        /// <summary>
        ///  Get a collection of upload type items
        /// </summary>
        [HttpPost]
        [Route("GetAllUploadTypes")]
        [ApiExplorerSettings(GroupName = "Upload Type - Get a collection of upload types")]
        [ProducesResponseType(typeof(UploadTypeResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> GetUploadType()
        {
            var user = identityParser.Parse(HttpContext.User);
            
            var request = new GetUploadTypeUseCaseRequest(user.CustomerCode);
            getUploadTypeUseCase.Execute(request);

            return presenter.ViewModel;
        }
    }
}
