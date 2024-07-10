using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.GetDetailServiceByInvoice;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetDetailServiceByInvoice
{
    public class GetDetailServicePresenter : IOutputPort<GetDetailServiceByInvoiceOutput>
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

        public void Standard(GetDetailServiceByInvoiceOutput output)
        {
            var invoices = new List<InvoiceRequest>();

            output.Invoices.ForEach(inv => 
            {
                var invoice = new InvoiceRequest(
                    inv.CustomerCode,
                    inv.InvoiceNumber,
                    inv.DueDate,
                    inv.BillingCycle,
                    inv.InvoiceAmount,
                    inv.CustomerId,
                    new CustomerRequest(
                        inv.Customer.CustomerCode,
                        inv.Customer.CompanyName,
                        inv.Customer.FirstName,
                        inv.Customer.LastName,
                        inv.Customer.Cpf,
                        inv.Customer.Cnpj,
                        inv.Customer.Segment,
                        inv.Customer.UF,
                        inv.Customer.City,
                        inv.Customer.ZipCode,
                        inv.Customer.Email
                    ),
                    inv.Services.Select(serv => new ServiceRequest(
                        serv.InvoiceNumber,
                        serv.Name,
                        serv.Price,
                        serv.ServiceType,
                        serv.Quantity
                        )).ToList()
                );

                invoices.Add(invoice);
            });

            var response = new GetDetailServiceResponse(invoices);

            ViewModel = new OkObjectResult(response);
        }
    }
}
