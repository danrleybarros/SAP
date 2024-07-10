using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.UseCases.Config.HistoryConsumption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.HistoryConsumption
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IHistoryConsumptionUseCase historyConsumptionUseCase;
        private readonly HistoryConsumptionPresenter presenter;

        public FeedController(IHistoryConsumptionUseCase historyConsumptionUseCase, HistoryConsumptionPresenter presenter)
        {
            this.historyConsumptionUseCase = historyConsumptionUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<OutputHistoryResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetHistoryConsumption")]
        public IActionResult GetHistoryConsumption([FromBody] InputHistoryRequest input)
        {
            historyConsumptionUseCase.Execute(new HistoryRequest(input.CustomerCode));
            return presenter.ViewModel;
        }
    }
}