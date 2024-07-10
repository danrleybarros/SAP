using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Add;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestAndFineFinancialAccountController : ControllerBase
    {
        private readonly InterestAndFineFinancialAccountPresenter presenter;
        private IIdentityParser<UserInfo> identityParser;
        private readonly IUseCase<AccountAddRequest> useCase;

        public InterestAndFineFinancialAccountController(InterestAndFineFinancialAccountPresenter presenter, 
            IIdentityParser<UserInfo> identityParser, 
            IUseCase<AccountAddRequest> useCase)
        {
            this.presenter = presenter;
            this.identityParser = identityParser;
            this.useCase = useCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("Add")]
        public IActionResult Add([FromBody] InterestAndFineFinancialAccountAddRequest request)
        {
            var user = identityParser.Parse(HttpContext.User);

            useCase.Execute(new AccountAddRequest(user.TenantID, request.Map()));

            return presenter.ViewModel;
        }
    }
}
