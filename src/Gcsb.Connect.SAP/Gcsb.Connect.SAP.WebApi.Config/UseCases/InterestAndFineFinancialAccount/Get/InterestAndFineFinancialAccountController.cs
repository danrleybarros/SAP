using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Get;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount.Get
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestAndFineFinancialAccountController : ControllerBase
    {
        private readonly InterestAndFineFinancialAccountPresenter presenter;
        private IIdentityParser<UserInfo> identityParser;
        private readonly IUseCase<AccountGetRequest> useCase;

        public InterestAndFineFinancialAccountController(InterestAndFineFinancialAccountPresenter presenter, 
            IIdentityParser<UserInfo> identityParser, 
            IUseCase<AccountGetRequest> useCase)
        {
            this.presenter = presenter;
            this.identityParser = identityParser;
            this.useCase = useCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(InterestAndFineFinancialAccountGetResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("Get")]
        public IActionResult Get([FromBody] GetInput input)
        {
            var user = identityParser.Parse(HttpContext.User);

            useCase.Execute(new AccountGetRequest(user.TenantID, input.StoreAcronym));

            return presenter.ViewModel;
        }
    }
}
