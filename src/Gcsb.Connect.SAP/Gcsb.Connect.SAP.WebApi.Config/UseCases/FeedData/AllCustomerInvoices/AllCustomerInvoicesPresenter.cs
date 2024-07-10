using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.AllCustomerInvoices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.AllCustomerInvoices
{
    public class AllCustomerInvoicesPresenter : IOutputPort<List<AllCustomerInvoicesOutput>>
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

        public void Standard(List<AllCustomerInvoicesOutput> output)
        {
            var response = new List<AllCustomerInvoicesResponse>();

            output.ForEach(f =>
            {
                var services = new List<Services>();

                f.Services.ForEach(service => services.Add(new Services(
                    service.ServiceCode,
                    service.ServiceName,
                    service.ServiceType,
                    service.GrandTotalRetailPrice,
                    service.Activity,
                    service.OrderCreationDate)));

                response.Add(new AllCustomerInvoicesResponse(f.CustomerCode, f.CompanyName, f.CycleCode, f.InvoiceNumber, f.InvoiceDate, f.InvoiceValue, services, f.PaymentStatus, f.PaymentDate));
            });

            ViewModel = new OkObjectResult(response);
        }
    }
}
