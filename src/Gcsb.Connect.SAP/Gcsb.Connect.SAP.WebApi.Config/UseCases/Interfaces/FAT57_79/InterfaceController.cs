using System.Linq;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Interfaces.FAT57_79
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterfaceController : ControllerBase
    {
        private readonly IIdentityParser<UserInfo> identityParser;
        private readonly ICounterchargeDisputeUseCase counterchargeDisputeUseCase;


        public InterfaceController(IIdentityParser<UserInfo> identityParser, ICounterchargeDisputeUseCase counterchargeDisputeUseCase)
        {
            this.identityParser = identityParser;
            this.counterchargeDisputeUseCase = counterchargeDisputeUseCase;
        }

        /// <summary>
        /// Generate Interface FAT 57 and FAT 79
        /// </summary>               
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(CounterChargeDisputeOutput), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Route("GenerateFAT57_79")]
        public IActionResult GenerateInterfaces(InterfaceInput input)
        {
            var user = identityParser.Parse(HttpContext.User);

            var request = new CounterchargeDisputeRequest(input.DateStart, input.DateEnd, false, user.LoginName);
            return new ObjectResult(counterchargeDisputeUseCase.Execute(request).Result);           
            
        }
    }
}
