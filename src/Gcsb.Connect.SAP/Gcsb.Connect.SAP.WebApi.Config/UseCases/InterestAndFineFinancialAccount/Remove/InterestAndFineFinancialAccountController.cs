using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Remove;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount.Remove
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestAndFineFinancialAccountController : ControllerBase
    {
        private readonly InterestAndFineFinancialAccountPresenter presenter;
        private IIdentityParser<UserInfo> identityParser;
        private readonly IUseCase<AccountRemoveRequest> useCase;

        public InterestAndFineFinancialAccountController(InterestAndFineFinancialAccountPresenter presenter, 
            IIdentityParser<UserInfo> identityParser, 
            IUseCase<AccountRemoveRequest> useCase)
        {
            this.presenter = presenter;
            this.identityParser = identityParser;
            this.useCase = useCase;
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("Remove")]
        public IActionResult Remove(InterestAndFineFinancialAccountRemoveRequest request)
        {
            var user = identityParser.Parse(HttpContext.User);

            useCase.Execute(new AccountRemoveRequest(request.Id, user.TenantID));

            return presenter.ViewModel;
        }
    }
}
