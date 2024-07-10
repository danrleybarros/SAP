using Gcsb.Connect.SAP.Application.UseCases.Config.AvgOfferConsumption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.AvgOfferConsumption
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly AvgOfferConsumptionPresenter presenter;
        private readonly IAvgOfferConsumptionUseCase useCase;

        public FeedController(AvgOfferConsumptionPresenter presenter, IAvgOfferConsumptionUseCase useCase)
        {
            this.presenter = presenter;
            this.useCase = useCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AvgOfferConsumptionResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetAvgOfferConsumption")]
        public IActionResult GetAvgOfferConsumption([FromBody] AvgOfferConsumptionInput input)
        {
            useCase.Execute(new AvgOfferConsumptionRequest(input.StartConsumptioPeriod, input.EndConsumptionPeriod, input.OfferCode));
            return presenter.ViewModel;            
        }
    }
}
