using Gcsb.Connect.SAP.Application.UseCases.File;
using Gcsb.Connect.SAP.Application.UseCases.File.Upload;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.UploadStatus;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.GetUploadStatus
{
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IIdentityParser<UserInfo> identityParser;
        private readonly IUploadStatusUseCase uploadStatusUseCase;
        private readonly StatusPresenter statusPresenter;

        public FileController(IIdentityParser<UserInfo> identityParser, IUploadStatusUseCase uploadStatusUseCase, StatusPresenter statusPresenter)
        {
            this.identityParser = identityParser;
            this.uploadStatusUseCase = uploadStatusUseCase;
            this.statusPresenter = statusPresenter;
        }

        /// <summary>
        /// Get status from all Uploads
        /// </summary>               
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(FileResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [Route("UploadStatus")]

        public IActionResult GetAllUploadStatus()
        {

            var user = identityParser.Parse(HttpContext.User);
            var request = new UploadStatusRequest(user.TenantID);         
            uploadStatusUseCase.Execute(request);
            return statusPresenter.ViewModel;
        }
    } 
}



