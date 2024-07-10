using Gcsb.Connect.SAP.Application.UseCases.Files.Download;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.Download
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {        
        private readonly IIdentityParser<UserInfo> identityParser;
        private readonly IDownloadUseCase downloadUseCase;
        // private  string permissions = "Super Admin";

        public FileController(IIdentityParser<UserInfo> identityParser, IDownloadUseCase downloadUseCase)
        {
            this.identityParser = identityParser;
            this.downloadUseCase = downloadUseCase;
        }

        /// <summary>
        /// Download interfaces from FileId by Billfeed, PaymentFeed or ReturnNF
        /// </summary>               
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(FileResult), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [Route("Download")]
        public IActionResult Download([FromBody] FileInput input)
        {
            var response = downloadUseCase.Execute(new DownloadUseCaseRequest((Guid)input.FileId));
            if (response == null || response?.Base64 == null)
                return BadRequest(response?.Logs.Where(s=>s.TypeLog == Messaging.Messages.Log.Enum.TypeLog.Error).Select(s=>s.Message).FirstOrDefault() ?? "Not Found or Status Processing/Error");
            return File(response.BytesFile, "application/zip", "Interfaces.zip");
        }

        /// <summary>
        /// Download interfaces from FileId by Billfeed, PaymentFeed or ReturnNF in Base64
        /// </summary>               
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(DownloadResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [Route("DownloadBase64")]
        public IActionResult DownloadBase64([FromBody] FileInput input)
        {
            var response = downloadUseCase.Execute(new DownloadUseCaseRequest((Guid)input.FileId));
            if (response == null || response?.Base64 == null)
                return BadRequest(response?.Logs.Where(s => s.TypeLog == Messaging.Messages.Log.Enum.TypeLog.Error).Select(s => s.Message).FirstOrDefault() ?? "Not Found or Status Processing/Error");
            return Ok(new DownloadResponse() { Base64 = response.Base64 });
        }
    }
}
