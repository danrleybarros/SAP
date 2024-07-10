using Gcsb.Connect.SAP.Application.Boundaries.GetOpenInvoices;
using Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetOpenInvoices
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IGetOpenInvoicesUseCase useCase;
        private readonly OpenInvoicesPresenter presenter;

        public FeedController(IGetOpenInvoicesUseCase useCase, OpenInvoicesPresenter presenter)
        {
            this.useCase = useCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<InvoiceOutput>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetOpenInvoices")]
        public IActionResult GetOpenInvoices([FromBody] GetOpenInvoicesInput input)
        {
            var request = new GetOpenInvoicesRequest(input.SearchType, input.Value);
            useCase.AddPayFilterHandler().Execute(request);
            return presenter.ViewModel;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<InvoiceOutput>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetUnPaidInvoicesWithoutPayFilter")]
        public IActionResult GetUnPaidInvoicesWithoutPayFilter([FromBody] GetOpenInvoicesInput input)
        {
            var request = new GetOpenInvoicesRequest(input.SearchType, input.Value);
            useCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
