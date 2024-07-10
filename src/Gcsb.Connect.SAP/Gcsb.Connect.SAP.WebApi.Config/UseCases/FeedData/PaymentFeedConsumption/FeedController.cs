using Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeedConsumption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.PaymentFeedConsumption
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IPaymentfeedConsumptionUseCase useCase;
        private readonly PaymentFeedPresenter presenter;

        public FeedController(IPaymentfeedConsumptionUseCase useCase, PaymentFeedPresenter presenter)
        {
            this.useCase = useCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<PaymentFeedResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetPaymentFeedByCustomer")]
        public IActionResult GetPaymentFeedByCustomer([FromBody]PaymentFeedRequest input)
        {
            useCase.Execute(new PaymentfeedConsumptionRequest(input.CustomerCode));
            return presenter.ViewModel;
        }
    }
}
