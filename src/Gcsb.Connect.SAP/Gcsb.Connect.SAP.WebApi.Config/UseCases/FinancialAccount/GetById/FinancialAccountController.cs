using Gcsb.Connect.SAP.Application.UseCases.Config.FinancialAccount.GetById;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccount.GetById
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialAccountController : ControllerBase
    {
        private readonly IFinancialAccountGetByIdUseCase financialAccountGetByIdUseCase;
        private readonly IIdentityParser<UserInfo> identityParser;
        private readonly FinancialAccountGetbyIdPresenter presenter;

        public FinancialAccountController(IIdentityParser<UserInfo> identityParser, FinancialAccountGetbyIdPresenter presenter, IFinancialAccountGetByIdUseCase financialAccountGetByIdUseCase)
        {
            this.identityParser = identityParser;
            this.presenter = presenter;
            this.financialAccountGetByIdUseCase = financialAccountGetByIdUseCase;
    }

        [HttpPost]
        [ProducesResponseType(typeof(FinancialAccountGebyIdResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetById")]
        public IActionResult GetById([FromBody]FinancialAccountGetbyIdRequest request)
        {
            var user = identityParser.Parse(HttpContext.User);

            financialAccountGetByIdUseCase.Execute(new FinancialAccountRequest(user.TenantID, request.Id));

            return presenter.ViewModel;
        }
    }
}
