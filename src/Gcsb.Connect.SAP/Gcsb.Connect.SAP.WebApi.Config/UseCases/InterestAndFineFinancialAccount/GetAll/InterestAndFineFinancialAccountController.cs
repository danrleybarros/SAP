using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.GetAll;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount.GetAll
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestAndFineFinancialAccountController : ControllerBase
    {
        private readonly InterestAndFineFinancialAccountPresenter presenter;
        private IIdentityParser<UserInfo> identityParser;
        private readonly IUseCase<AccountGetAllRequest> useCase;

        public InterestAndFineFinancialAccountController(InterestAndFineFinancialAccountPresenter presenter, 
            IIdentityParser<UserInfo> identityParser, 
            IUseCase<AccountGetAllRequest> useCase)
        {
            this.presenter = presenter;
            this.identityParser = identityParser;
            this.useCase = useCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(InterestAndFineFinancialAccountGetAllResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var user = identityParser.Parse(HttpContext.User);

            useCase.Execute(new AccountGetAllRequest(user.TenantID));

            return presenter.ViewModel;
        }
    }
}
