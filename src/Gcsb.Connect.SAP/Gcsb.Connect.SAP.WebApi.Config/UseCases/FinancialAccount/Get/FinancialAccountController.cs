using Gcsb.Connect.SAP.Application.UseCases.Config;
using Gcsb.Connect.SAP.WebApi.Config.Filters;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccount.Get
{
    [Route("/api/FinancialAccount")]
    public class FinancialAccountController : ControllerBase
    {
        private readonly IFinancialAccountSearchUseCase FinancialAccountResult;
        private readonly IIdentityParser<UserInfo> identityParser;

        public FinancialAccountController(IFinancialAccountSearchUseCase FinancialAccountResult, IIdentityParser<UserInfo> identityParser)
        {
            this.FinancialAccountResult = FinancialAccountResult;
            this.identityParser = identityParser;
        }

        /// <summary>
        /// Return financial accounts
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [Authorize]
        [Permission(4551)]
        [ProducesResponseType(typeof(List<FinancialAccountResult>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Route("Get")]
        public IActionResult GetFinancialAccounts([FromBody]FinancialAccountRequest request)
        {

            return Ok(FinancialAccountResult.Execute(request));
        }
    }
}