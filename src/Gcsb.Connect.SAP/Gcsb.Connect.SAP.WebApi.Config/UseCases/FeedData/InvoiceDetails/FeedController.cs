using Gcsb.Connect.SAP.Application.UseCases.Config.InvoiceDetails;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomerConsumption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.InvoiceDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IInvoiceDetailUseCase useCase;
        private readonly InvoiceDetailsPresenter presenter;

        public FeedController(IInvoiceDetailUseCase useCase, InvoiceDetailsPresenter presenter)
        {
            this.useCase = useCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [Authorize]
        [Route("GetInvoicesDetails")]
        [ProducesResponseType(typeof(List<CustomerResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetInvoicesDetails([FromBody] InvoiceDetailsRequest input)
        {
            useCase.Execute(new Application.UseCases.Config.InvoiceDetails.InvoiceDetailsRequest(input.InvoiceNumbers));
            return presenter.ViewModel;
        }
    }
}