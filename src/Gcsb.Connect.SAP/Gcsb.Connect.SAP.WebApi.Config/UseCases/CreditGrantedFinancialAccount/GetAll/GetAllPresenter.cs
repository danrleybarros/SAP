using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.GetAll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.CreditGrantedFinancialAccount.GetAll
{
    public class GetAllPresenter : IOutputPort<GetAllOutput>
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "Error",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);

        public void Standard(GetAllOutput output)
        {
            var response = new List<GetAllResponse>();
            output.CreditGrantedFinancialAccounts.ForEach(acc =>
            {
                response.Add(new GetAllResponse(acc.Id.Value, acc.StoreAcronym, acc.CreditGrantedAJU, acc.AccountingAccountDeb, acc.AccountingAccountCred));
            });

            ViewModel = new OkObjectResult(response);
        }
    }
}
