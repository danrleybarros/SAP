using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.UseCases.Files.Download;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.Download
{
    public class DownloadPresenter : IOutputPort<DownloadOutput>
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "Error",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);
        

        public void Standard(DownloadOutput output)
        {
            throw new System.NotImplementedException();
        }
    }
}
