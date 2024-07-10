using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.OrdemInterna;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetOrdemInterna
{
    public class GetOrdemInternaPresenter : IOutputPort<OrdemInternaOutput>
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

        public void Standard(OrdemInternaOutput output)
        {
            var uFsCompResponse = new List<UFCompResponse>();

            output.OrdensInterna.ForEach(f =>
            {
                var uFCompResponse = new UFCompResponse(f.UF, f.Estado, f.OrdemInterna);
                uFsCompResponse.Add(uFCompResponse);
            });

            var response = new GetOrdemInternaResponse(uFsCompResponse);

            ViewModel = new OkObjectResult(response);
        }
    }
}
