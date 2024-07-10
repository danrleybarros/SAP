using Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.Save;
using Gcsb.Connect.SAP.WebApi.Config.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.CreditGrantedFinancialAccount.Save
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditGrantedFinancialAccountController : ControllerBase
    {
        private readonly ISaveUseCase useCase;
        private readonly SavePresenter presenter;

        public CreditGrantedFinancialAccountController(ISaveUseCase useCase,
            SavePresenter presenter)
        {
            this.useCase = useCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [Authorize]
        //[Permission(101112)]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Route("Save")]
        public IActionResult Save([FromBody] SaveInput input)
        {
            var account = new Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount(input.Id, input.StoreAcronym, input.CreditGrantedAJU, input.AccountingAccountDeb, input.AccountingAccountCred);
            var request = new SaveRequest(account);
            useCase.Execute(request);

            return presenter.ViewModel;
        }
    }
}
