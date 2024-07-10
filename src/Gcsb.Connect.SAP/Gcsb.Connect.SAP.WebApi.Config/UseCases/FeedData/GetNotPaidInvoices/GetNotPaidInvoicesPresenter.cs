using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.NewPendingInvoices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetNotPaidInvoices
{
    public class GetNotPaidInvoicesPresenter : IOutputPort<List<NewPendingInvoicesOutput>>
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

        public void Standard(List<NewPendingInvoicesOutput> output)
        {
            var response = new List<GetNotPaidInvoicesResponse>();

            output.ForEach(f =>
            {
                response.Add(new GetNotPaidInvoicesResponse(
                    f.CustomerCode,
                    f.Cpf,
                    f.Cnpj,
                    f.InvoiceNumber,
                    f.AccountStartDate,
                    f.InvoiceStatus,
                    f.InvoiceCreationDate,
                    f.CycleDate,
                    f.InvoiceValue,
                    f.DueDate
                    ));
            });

            ViewModel = new OkObjectResult(response);
        }
    }
}
