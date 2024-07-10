using System.Security.Claims;
using System.Threading.Tasks;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.GetServices
{
    [Route("/api/Services")]
    public class ServiceController : ControllerBase
    {
        IGetServiceUseCase ServiceUseCase;
        private IIdentityParser<UserInfo> IdentityParser;

        public ServiceController(IGetServiceUseCase serviceUseCase,
            IIdentityParser<UserInfo> identityParser)
        {
            this.ServiceUseCase = serviceUseCase;
            this.IdentityParser = identityParser;
        }

        /// <summary>
        /// Return services from jsdn
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost()]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> GetServicesCodes(GetServiceRequest request)
        {
            var user = IdentityParser.Parse(HttpContext.User);
            if (!(user.RoleName == "Marketplace Admin"))
            {
                return Unauthorized();
            }

            //JsdnToken
            request.Token = ((ClaimsPrincipal)HttpContext.User).FindFirstValue("JsdnToken");

            return Ok(await ServiceUseCase.Execute(request));
        }
    }
}