using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.Boundaries;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.UploadType
{
    public class UploadTypePresenter : IOutputPort<List<Domain.UploadTypeDto.UploadTypeDto>>
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

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);

        public void Standard(List<Domain.UploadTypeDto.UploadTypeDto> output)
        {
            ViewModel = new OkObjectResult(output);
        }
    }

}
