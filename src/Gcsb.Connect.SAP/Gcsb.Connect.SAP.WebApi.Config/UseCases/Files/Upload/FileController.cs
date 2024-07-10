using Gcsb.Connect.SAP.Application.UseCases.Files.Upload;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.Upload
{

    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IIdentityParser<UserInfo> identityParser;
        private readonly IUploadUseCase uploadUseCase;
        /*private string permissions = "Super Admin";*/
  
        public FileController(IIdentityParser<UserInfo> identityParser, IUploadUseCase uploadUseCase)
        {
            this.identityParser = identityParser;
            this.uploadUseCase = uploadUseCase;
        }

        /// <summary>
        /// Upload Billfeed, PaymentFeed or ReturnNF files
        /// </summary>               
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(FileResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [Route("Upload")]
        public IActionResult Upload([FromForm]FileInput input)
        {
            var user = identityParser.Parse(HttpContext.User);            
            if (input.File.Length == 0)
                return BadRequest("Null or Empty File");

            using (var ms = new MemoryStream())
            {
                input.File.CopyTo(ms);
                var fileBytes = ms.ToArray();
                var base64 = Convert.ToBase64String(fileBytes);
                var request = new UploadUseCaseRequest((Domain.Upload.Enum.UploadTypeEnum)input.Type, input.File.FileName, base64, user?.LoginName);                                
                uploadUseCase.Execute(request);
            }

            return Ok(new FileResponse() { Message = "Processing"});
        }


        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(FileResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [Route("UploadBase64")]
        public IActionResult UploadBase64([FromBody] FileInput64 input)
        {
            var user = identityParser.Parse(HttpContext.User);
            var request = new UploadUseCaseRequest((Domain.Upload.Enum.UploadTypeEnum)input.Type, input.FileName, input.Base64, user?.LoginName);
            uploadUseCase.Execute(request);

            return Ok(new FileResponse() { Message = "Processing" });
        }
    }
}
