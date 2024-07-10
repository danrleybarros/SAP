using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.ExportCSV;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount.Get;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount.ExportCSV
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestAndFineFinancialAccountController : ControllerBase
    {
        private readonly IUseCase<AccountExportCSVRequest> useCase;

        public InterestAndFineFinancialAccountController(IUseCase<AccountExportCSVRequest> useCase)
        {
            this.useCase = useCase;
        }

        /// <summary>
        /// Export Financial Accounts of Interest and Fine to CSV
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Route("ExportCSV")]
        public FileResult ExportCSV([FromBody] GetInput input)
        {
            var request = new AccountExportCSVRequest(input.StoreAcronym);
            useCase.Execute(request);

            return File(new UTF8Encoding().GetBytes(request.ContentCSV.ToString()), "text/csv", "ContasJurosEMultas.csv");
        }
    }
}
