using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.Services.ServiceResponse;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.Services
{
    public class ServicesPresenter : IOutputPort<List<ServiceInvoice>>
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

        public void Standard(List<ServiceInvoice> output)
        {   
            var response = output.GroupBy(g => g.InvoiceNumber).Select(s => new ServiceOutput()
            {
                InvoiceNumber = s.Key,
                Services = s.GroupBy(g2 => g2.ServiceType).Select(s2 => new Service()
                {
                    ServiceType = s2.Key,
                    Value = s2.Sum(sum => sum.GrandTotalRetailPrice ?? 0)
                }).ToList()
            }).ToList();

            ViewModel = new OkObjectResult(response);
        }
    }
}
