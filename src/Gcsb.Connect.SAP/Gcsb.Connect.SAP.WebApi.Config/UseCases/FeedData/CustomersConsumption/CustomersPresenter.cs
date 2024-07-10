using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.CustomersConsumption;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomersConsumption
{
    public class CustomersPresenter : IOutputPort<List<CustomersOutput>>
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

        public void Standard(List<CustomersOutput> output)
        {
            var response = new List<CustomersResponse>();

            output.ForEach(f =>
            {
                response.Add(new CustomersResponse(
                    f.CustomerCode, 
                    f.InvoiceNumber, 
                    f.AccountStartDate,
                    f.InvoiceStatus, 
                    f.InvoiceCreationDate,
                    f.CycleDate, 
                    f.PaymentDate, 
                    f.PaymentValue, 
                    f.InvoicePaid,
                    f.PaidBoleto,
                    f.CreditValue));
            });

            ViewModel = new OkObjectResult(response);
        }
    }
}
