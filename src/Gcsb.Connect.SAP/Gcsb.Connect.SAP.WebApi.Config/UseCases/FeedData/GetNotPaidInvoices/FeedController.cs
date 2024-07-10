using Gcsb.Connect.SAP.Application.UseCases.Config.NewPendingInvoices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetNotPaidInvoices
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly INewPendingInvoicesUseCase newPendingInvoicesUseCase;
        private readonly GetNotPaidInvoicesPresenter presenter;

        public FeedController(INewPendingInvoicesUseCase newPendingInvoicesUseCase, GetNotPaidInvoicesPresenter presenter)
        {
            this.newPendingInvoicesUseCase = newPendingInvoicesUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<GetNotPaidInvoicesResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetNotPaidInvoices")]
        public IActionResult GetNotPaidInvoices([FromBody]GetNotPaidInvoicesRequest input)
        {
            newPendingInvoicesUseCase.Execute(new NewPendingInvoicesRequest(input.InvoicesNumbers));
            return presenter.ViewModel;
        }
    }
}
