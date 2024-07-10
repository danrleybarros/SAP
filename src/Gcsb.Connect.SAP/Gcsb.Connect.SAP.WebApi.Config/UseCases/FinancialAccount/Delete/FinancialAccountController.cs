using System;
using Gcsb.Connect.SAP.Application.UseCases.Config;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccount.Delete
{
    [Route("/api/FinancialAccount")]
    public class FinancialAccountController : ControllerBase
    {
        IFinancialAccountDeleteUseCase FinancialAccountDelete;
        private IIdentityParser<UserInfo> IdentityParser;

        public FinancialAccountController(IFinancialAccountDeleteUseCase FinancialAccountDelete,
            IIdentityParser<UserInfo> identityParser)
        {
            this.FinancialAccountDelete = FinancialAccountDelete;
            this.IdentityParser = identityParser;
        }

        /// <summary>
        /// Delete financial Account
        /// </summary>
        /// <param name="FinancialAccountID"></param>
        /// <returns></returns>
        [HttpDelete()]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("Delete")]
        public IActionResult Delete([FromBody]Guid FinancialAccountID)
        {
            var user = IdentityParser.Parse(HttpContext.User);
            if (!(user.RoleName == "Marketplace Admin"))
            {
                return Unauthorized();
            }
            // TODO recuperar informações do usario.
            return Ok(FinancialAccountDelete.Execute(FinancialAccountID, user.LoginName, user.Name));
        }
    }
}