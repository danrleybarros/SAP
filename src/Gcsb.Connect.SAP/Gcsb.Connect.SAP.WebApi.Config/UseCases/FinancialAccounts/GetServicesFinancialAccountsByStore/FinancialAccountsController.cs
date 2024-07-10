using System;
using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.SAP.Application;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccounts.GetServicesFinancialAccountsByStore
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialAccountsController : ControllerBase
    {
        private readonly IIdentityParser<UserInfo> identityParser;
        private string[] permissions;
        public FinancialAccountsController(IIdentityParser<UserInfo> identityParser)
        {
            this.identityParser = identityParser;
        }

        [HttpPost()]
        //[Authorize]
        [ProducesResponseType(typeof(FinancialAccountsByStoreResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Route("GetServicesFinancialAccountsByStore")]
        public IActionResult GetFinancialAccounts([FromBody] FinancialAccountsByStoreInput input)
        {

            //var user = identityParser.Parse(HttpContext.User);
            //var userPermissions = Environment.GetEnvironmentVariable("USER_PERMISSIONS");

            //permissions = userPermissions != null ? userPermissions.Split('|') : new string[0];

            //if (!(permissions.Contains(Util.RemoveAccents(user.RoleName))))
            //    return Unauthorized();

            //TODO: call usecase

            //return presenter.ViewModel;

            // Mock response
            var response = new FinancialAccountsByStoreResponse()
            {
                ServiceFinancialAccounts = new List<ServiceFinancialAccount>()
                {
                    new ServiceFinancialAccount()
                    {
                        Id = Guid.NewGuid(),
                        ServiceCode = "Office365",
                        ServiceName = "Office 365",
                        StoreAcronym = input.StoreAcronym,
                        StoreAcronymServiceProvider = "telerese"
                    },
                    new ServiceFinancialAccount()
                    {
                        Id = Guid.NewGuid(),
                        ServiceCode = "Office365",
                        ServiceName = "Office 365",
                        StoreAcronym = input.StoreAcronym,
                        StoreAcronymServiceProvider = "cloudco"
                    }
                }
            };        

            return Ok(response);
        }
    }
}
