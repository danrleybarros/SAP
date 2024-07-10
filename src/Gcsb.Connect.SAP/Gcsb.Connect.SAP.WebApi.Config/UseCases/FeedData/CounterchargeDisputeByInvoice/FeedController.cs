using Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDisputeByInvoices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CounterchargeDisputeByInvoice
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController
    {
        private readonly ICounterchargeDisputeByInvoicesUseCase counterchargeDisputeByInvoicesUseCase;
        private readonly CounterchargeDisputeByInvoicePresenter presenter;

        public FeedController(ICounterchargeDisputeByInvoicesUseCase counterchargeDisputeByInvoicesUseCase, CounterchargeDisputeByInvoicePresenter presenter)
        {
            this.counterchargeDisputeByInvoicesUseCase = counterchargeDisputeByInvoicesUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<CounterchargeDisputeByInvoiceResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetCounterchargeDisputeByInvoice")]
        public IActionResult GetCounterchargeDisputeByInvoice([FromBody] CounterchargeDisputeByInvoiceRequest input)
        {
            var request = new CounterchargeDisputeByInvoicesRequest(input.Invoices);
            counterchargeDisputeByInvoicesUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
