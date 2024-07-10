using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.PaymentFeedConsumption;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.PaymentFeedConsumption
{
    public class PaymentFeedPresenter : IOutputPort<List<PaymentFeedOutput>>
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

        public void Standard(List<PaymentFeedOutput> output)
        {
            var response = new List<PaymentFeedResponse>();

            output.ForEach(f =>
            {
                response.Add(new PaymentFeedResponse(
                    f.PaymentDate,
                    f.AssignmentDate,
                    f.TransactionAmount,
                    f.AmountReceived,
                    f.PaymentMetohd,
                    f.InvoiceNumber,
                    f.Cycle,
                    f.InvoiceStatus,
                    f.AttributionMethod,
                    f.BankCode,
                    f.BankName,
                    f.CreditCardBrand,
                    f.CreditCardNumber,
                    f.Nsu
                    ));
            });

            ViewModel = new OkObjectResult(response);
        }
    }
}
