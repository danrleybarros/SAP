using Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.GetByStore;
using Gcsb.Connect.SAP.WebApi.Config.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.CreditGrantedFinancialAccount.GetByStore
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditGrantedFinancialAccountController : ControllerBase
    {
        private readonly IGetByStoreUseCase useCase;
        private readonly GetByStorePresenter presenter;

        public CreditGrantedFinancialAccountController(IGetByStoreUseCase useCase,
            GetByStorePresenter presenter)
        {
            this.useCase = useCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [Authorize]
        [Permission(101111)]
        [ProducesResponseType(typeof(GetByStoreResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Route("GetByStore")]
        public IActionResult GetByStore([FromBody] GetByStoreInput input)
        {
            var request = new GetByStoreRequest(input.StoreAcronym);
            useCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
