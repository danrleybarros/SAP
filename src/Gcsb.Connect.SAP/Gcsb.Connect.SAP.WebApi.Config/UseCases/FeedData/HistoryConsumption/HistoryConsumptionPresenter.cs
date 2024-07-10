using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Domain.Config.HistoryConsumption;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.HistoryConsumption
{
    public class HistoryConsumptionPresenter : IOutputPort<List<HistoryConsumptionValue>>
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

        public void Standard(List<HistoryConsumptionValue> output)
        {
            var response = new List<OutputHistoryResponse>();
            output.ForEach(f => response.Add(new OutputHistoryResponse(f.ServiceType, f.MonthYear, f.Value)));

            ViewModel = new OkObjectResult(response);
        }
    }
}
