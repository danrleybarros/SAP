using Gcsb.Connect.SAP.Application.UseCases.Config;
using Gcsb.Connect.SAP.WebApi.Config.Filters;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccount.Save
{
    [Route("/api/FinancialAccount")]
    public class FinancialAccountController : ControllerBase
    {
        IFinancialAccountSaveUseCase FinancialAccountSave;
        private IIdentityParser<UserInfo> IdentityParser;

        public FinancialAccountController(IFinancialAccountSaveUseCase FinancialAccountSave,
            IIdentityParser<UserInfo> identityParser)
        {
            this.FinancialAccountSave = FinancialAccountSave;
            this.IdentityParser = identityParser;
        }
        
        /// <summary>
        /// Save the financial Account
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Permission(4551)]
        [Route("Save")]
        public IActionResult Save([FromBody]FinancialAccountResult message)
        {
            var user = IdentityParser.Parse(HttpContext.User);
            return Ok(FinancialAccountSave.Execute(message, user.LoginName, user.Name));
        }
    }
}