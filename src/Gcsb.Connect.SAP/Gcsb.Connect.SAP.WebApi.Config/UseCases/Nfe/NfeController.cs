using Gcsb.Connect.SAP.Application;
using Gcsb.Connect.SAP.Application.UseCases.GF.ReturnNF;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Nfe
{
    [Route("/api/Nfe")]
    public class NfeController : Controller
    {
        IReturnNFListUseCase NfListUseCase;
        IIdentityParser<UserInfo> identityParser;
        private string[] permissions;

        public NfeController(IReturnNFListUseCase NfListUseCase, IIdentityParser<UserInfo> identityParser)
        {
            this.NfListUseCase = NfListUseCase;
            this.identityParser = identityParser;
        }
        [HttpPost()]
        [Authorize]
        [ProducesResponseType(typeof(List<ReturnNF>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetNfeCodes([FromBody]List<string> array)
        {
            var user = identityParser.Parse(HttpContext.User);
            var userPermissions = Environment.GetEnvironmentVariable("USER_PERMISSIONS");

            permissions = userPermissions != null ? userPermissions.Split('|') : new string[0];

            if (!(permissions.Contains(Util.RemoveAccents(user.RoleName))))
                return Unauthorized();

            return Ok(NfListUseCase.Execute(array));
        }
    }
}
