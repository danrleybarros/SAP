using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.Model
{
    public abstract class PresenterBase
    {
        public IActionResult ViewModel { get; protected set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }
    }
}
