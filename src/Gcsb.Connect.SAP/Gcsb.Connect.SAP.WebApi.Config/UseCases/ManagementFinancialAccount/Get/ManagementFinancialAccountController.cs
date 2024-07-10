using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Get;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount.Get
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementFinancialAccountController : ControllerBase
    {
        private readonly IIdentityParser<UserInfo> identityParser;
        private readonly IManagementFinancialAccountGetUseCase managementFinancialAccountGetUseCase;
        private readonly ManagementFinancialAccountPresenter presenter;

        public ManagementFinancialAccountController(IIdentityParser<UserInfo> identityParser, IManagementFinancialAccountGetUseCase managementFinancialAccountGetUseCase, ManagementFinancialAccountPresenter presenter)
        {
            this.identityParser = identityParser;
            this.managementFinancialAccountGetUseCase = managementFinancialAccountGetUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ManagementFinancialAccountGetResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("Get")]
        public IActionResult Get([FromBody] ManagementFinancialAccountGetInput input)
        {
            var user = identityParser.Parse(HttpContext.User);

            managementFinancialAccountGetUseCase.Execute(new ManagementFinancialAccountRequest(input.StoreType,user.TenantID));

            return presenter.ViewModel;
        }
    }
}