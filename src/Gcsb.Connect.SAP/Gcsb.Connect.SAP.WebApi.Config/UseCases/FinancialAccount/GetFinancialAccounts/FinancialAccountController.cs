using Gcsb.Connect.SAP.Application;
using Gcsb.Connect.SAP.Application.UseCases.Config.FinancialAccountDate;
using Gcsb.Connect.SAP.WebApi.Config.Filters;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccount.GetFinancialAccounts
{
    [Route("/api/FinancialAccount")]
    public class FinancialAccountController : ControllerBase
    {
        private readonly IFinancialAccountGetUseCase financialAccountGetUseCase;
        private readonly IIdentityParser<UserInfo> identityParser;
        private string[] permissions;

        public FinancialAccountController(IFinancialAccountGetUseCase financialAccountGetUseCase, IIdentityParser<UserInfo> identityParser)
        {
            this.financialAccountGetUseCase = financialAccountGetUseCase;
            this.identityParser = identityParser;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(List<Domain.Config.FinancialAccountDate.FinancialAccount>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Route("GetAll")]
        [Permission(90147)]
        public IActionResult GetAllFinancialAccounts([FromBody]DateTime date)
        {
            var user = identityParser.Parse(HttpContext.User);
            var userPermissions = Environment.GetEnvironmentVariable("USER_PERMISSIONS");

            permissions = userPermissions != null ? userPermissions.Split('|') : new string[0];

            if (!(permissions.Contains(Util.RemoveAccents(user.RoleName))))
                return Unauthorized();

            return Ok(financialAccountGetUseCase.Execute(date, user.TenantID));
        }
    }
}
