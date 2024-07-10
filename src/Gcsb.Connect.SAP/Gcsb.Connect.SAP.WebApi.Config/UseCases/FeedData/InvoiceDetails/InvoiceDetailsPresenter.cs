using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.CustomerConsumption;
using Consumption = Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomerConsumption;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.InvoiceDetails
{
    public class InvoiceDetailsPresenter : IOutputPort<InvoiceDetailsOutput>
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

        public void Standard(InvoiceDetailsOutput output)
        {
            var response = new List<Consumption::CustomerResponse>();

            output.ConsumptionOutputs.ForEach(f =>
            {
                var services = new List<Consumption::Services>();

                f.Services.ForEach(service => services.Add(new Consumption::Services(
                    service.ServiceCode, 
                    service.ServiceName, 
                    service.ServiceType, 
                    service.GrandTotalRetailPrice, 
                    service.Activity,
                    service.OrderCreationDate)));

                response.Add(new Consumption::CustomerResponse(f.CustomerCode, f.CompanyName, 
                    f.CycleCode, f.InvoiceNumber, f.InvoiceDate, f.InvoiceValue, 
                    services, f.PaymentStatus, f.PaymentDate, f.StoreAcronym));
            });

            ViewModel = new OkObjectResult(response);
        }
    }
}
