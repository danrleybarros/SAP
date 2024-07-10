using Gcsb.Connect.SAP.Application.Boundaries;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.CreditGrantedFinancialAccount.Save
{
    public class SavePresenter : IOutputPort<Guid>
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


        public void Standard(Guid id)
        {
            ViewModel = new OkObjectResult(id);
        }
    }
}
