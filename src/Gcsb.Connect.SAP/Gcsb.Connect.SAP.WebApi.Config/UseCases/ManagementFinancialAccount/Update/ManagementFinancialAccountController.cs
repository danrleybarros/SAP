using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Update;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount.Update
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementFinancialAccountController : ControllerBase
    {
        private readonly IIdentityParser<UserInfo> identityParser;
        private readonly IManagementFinancialAccountUpdateUseCase managementFinancialAccountUpdateUseCase;
        private readonly ManagementFinancialAccountPresenter presenter;


        public ManagementFinancialAccountController(IIdentityParser<UserInfo> identityParser, IManagementFinancialAccountUpdateUseCase managementFinancialAccountUpdateUseCase, ManagementFinancialAccountPresenter presenter)
        {
            this.identityParser = identityParser;
            this.managementFinancialAccountUpdateUseCase = managementFinancialAccountUpdateUseCase;
            this.presenter = presenter;
        }


        [HttpPut]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("Update")]
        public IActionResult Update([FromBody] ManagementFinancialUpdateRequest request)
        {
            var user = identityParser.Parse(HttpContext.User);

            managementFinancialAccountUpdateUseCase.Execute(new ManagementFinancialAccountRequest(user.TenantID, request.Map()));

            return presenter.ViewModel;
        }
    }
}