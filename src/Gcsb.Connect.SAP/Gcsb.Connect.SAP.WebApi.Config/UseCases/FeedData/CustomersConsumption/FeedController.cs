using Gcsb.Connect.SAP.Application.UseCases.Config.CustomersConsumption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomersConsumption
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly ICustomersConsumptionUseCase customerConsumptionUseCase;
        private readonly CustomersPresenter presenter;

        public FeedController(ICustomersConsumptionUseCase customerConsumptionUseCase, CustomersPresenter presenter)
        {
            this.customerConsumptionUseCase = customerConsumptionUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<CustomersResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetCustomersByInvoices")]
        public IActionResult GetCustomersByInvoices([FromBody]CustomersRequest input)
        {
            customerConsumptionUseCase.Execute(new CustomersConsumptionRequest(input.InvoicesNumbers));
            return presenter.ViewModel;
        }
    }
}