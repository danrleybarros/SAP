using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Add;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementFinancialAccountController : ControllerBase
    {
        private IIdentityParser<UserInfo> IdentityParser;
        private readonly IManagementFinancialAccountAddUseCase managementFinancialAccountAddUseCase;
        private readonly ManagementFinancialAccountPresenter presenter;

        public ManagementFinancialAccountController(IIdentityParser<UserInfo> identityParser,IManagementFinancialAccountAddUseCase managementFinancialAccountAddUseCase, ManagementFinancialAccountPresenter presenter)
        {
            this.IdentityParser = identityParser;
            this.managementFinancialAccountAddUseCase = managementFinancialAccountAddUseCase;
            this.presenter = presenter;
        }


        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("Add")]
        public IActionResult Add([FromBody]ManagementFinancialAccountAddRequest request)
        {
            var user = IdentityParser.Parse(HttpContext.User);

            managementFinancialAccountAddUseCase.Execute(new ManagementFinancialAccountRequest(user.TenantID, request.Map()));

            return presenter.ViewModel;
        }
    }
}