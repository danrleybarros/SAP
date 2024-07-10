using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Remove;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount.Remove
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementFinancialAccountController : ControllerBase
    {
        private readonly IIdentityParser<UserInfo> identityParser;
        private readonly IManagementFinancialAccountRemoveUseCase managementFinancialAccountRemovetUseCase;
        private readonly ManagementFinancialAccountPresenter presenter;

        public ManagementFinancialAccountController(IIdentityParser<UserInfo> identityParser, IManagementFinancialAccountRemoveUseCase managementFinancialAccountRemovetUseCase, ManagementFinancialAccountPresenter presenter)
        {
            this.identityParser = identityParser;
            this.managementFinancialAccountRemovetUseCase = managementFinancialAccountRemovetUseCase;
            this.presenter = presenter;
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("Remove")]
        public IActionResult Remove(ManagementFinancialRemoveRequest request)
        {
            var user = identityParser.Parse(HttpContext.User);

            managementFinancialAccountRemovetUseCase.Execute(new ManagementFinancialAccountRequest(user.TenantID, request.Id));

            return presenter.ViewModel;

        }
    }
}