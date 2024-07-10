using System;
using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.UseCases.File;
using Gcsb.Connect.SAP.Domain.Upload;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.GetUploadStatus;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.UploadStatus
{
    public class StatusPresenter : IOutputPort<List<UploadStatusDto>>
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void Standard(List<UploadStatusDto> output)
            => ViewModel = new OkObjectResult(new FileResponse() { Uploads = output });

        public void NotFound(string message)
            => ViewModel = new OkObjectResult(new FileResponse() { Uploads = new List<UploadStatusDto>()}); 
    }
}
