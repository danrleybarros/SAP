using Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDispute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CounterchargeDisputeData
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly ICounterchargeDisputeUseCase counterchargeDisputeUseCase;
        private readonly CounterchargeDisputePresenter presenter;

        public FeedController(ICounterchargeDisputeUseCase counterchargeDisputeUseCase, CounterchargeDisputePresenter presenter)
        {
            this.counterchargeDisputeUseCase = counterchargeDisputeUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<CounterchargeDisputeResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetCounterchargeDispute")]
        public IActionResult GetCounterchargeDispute([FromBody]CounterchargeDisputeRequest input)
        {
            var request = new Application.UseCases.JSDN.CounterchargeDispute.CounterchargeDisputeRequest(input.DateFrom.Date, input.DateTo.Date);
            counterchargeDisputeUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
