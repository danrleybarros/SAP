using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Domain.Config.CustomerService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomerServices
{
    public class CustomerServicesPresenter : IOutputPort<List<CustomerService>>
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

        public void Standard(List<CustomerService> output)
        {
            var response = new List<CustomerServicesResponse>();

            output.ForEach(o =>
            {
                response.Add(new CustomerServicesResponse()
                {
                    AccountStartDate = o.AccountStartDate,
                    AccountStatus = o.AccountStatus,
                    CustomerAccount = o.CustomerAccount,
                    CustomerCode = o.CustomerCode,
                    OldestDueDate = o.OldestDueDate,
                    OrignalDueDate = o.OrignalDueDate,
                    PaymentMethod = o.PaymentMethod,
                    ProductType = o.ProductType,
                    TotalInvoicePrice = o.TotalInvoicePrice,
                    UF = o.UF,
                    InvoiceNumber = o.InvoiceNumber,
                    ServiceCode = o.ServiceCode
                });
            });

            ViewModel = new OkObjectResult(response);
        }
    }
}
