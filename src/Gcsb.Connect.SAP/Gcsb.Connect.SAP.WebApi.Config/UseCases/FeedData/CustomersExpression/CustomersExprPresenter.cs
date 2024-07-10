using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.AllCustomers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomersExpression
{
    public class CustomersExprPresenter : IOutputPort<List<AllCustomersOutput>>
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

        public void Standard(List<AllCustomersOutput> output)
        {
            var response = new List<CustomersExprResponse>();

            output.ForEach(e =>
            {
                response.Add(new CustomersExprResponse(
                    e.Cnpj,
                    e.CustomerCodeStr,
                    e.CustomerName,
                    e.StoreAcronym,
                    e.StoreName));
            });

            ViewModel = new OkObjectResult(response);
        }
    }
}
