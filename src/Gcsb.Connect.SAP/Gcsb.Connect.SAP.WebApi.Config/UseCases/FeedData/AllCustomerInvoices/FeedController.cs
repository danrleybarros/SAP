using Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomerInvoices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.AllCustomerInvoices
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IAllCustomerInvoicesUseCase AllCustomerInvoicesUseCase;
        private readonly AllCustomerInvoicesPresenter presenter;

        public FeedController(IAllCustomerInvoicesUseCase AllCustomerInvoicesUseCase, AllCustomerInvoicesPresenter presenter)
        {
            this.AllCustomerInvoicesUseCase = AllCustomerInvoicesUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<AllCustomerInvoicesResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetAllCustomerInvoices")]
        public IActionResult GetCustomerInvoices([FromBody] AllCustomerInvoicesRequest input)
        {
            AllCustomerInvoicesUseCase.Execute(new Application.UseCases.Config.AllCustomerInvoices.AllCustomerInvoicesRequest(input.DocumentType, input.DocumentNumber));
            return presenter.ViewModel;
        }
    }
}
