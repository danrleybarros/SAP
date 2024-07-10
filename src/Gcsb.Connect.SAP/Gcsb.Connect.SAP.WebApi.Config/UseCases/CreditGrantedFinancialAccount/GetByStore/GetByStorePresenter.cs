using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.GetByStore;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.CreditGrantedFinancialAccount.GetByStore
{
    public class GetByStorePresenter : IOutputPort<GetByStoreOutput>
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

        public void Standard(GetByStoreOutput output)
        {
            var response = new GetByStoreResponse(
                output.CreditGrantedFinancialAccount.Id.Value,
                output.CreditGrantedFinancialAccount.StoreAcronym,
                output.CreditGrantedFinancialAccount.CreditGrantedAJU,
                output.CreditGrantedFinancialAccount.AccountingAccountDeb,
                output.CreditGrantedFinancialAccount.AccountingAccountCred);

            ViewModel = new OkObjectResult(response);
        }
    }
}
