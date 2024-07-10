using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomerConsumption
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly ICustomerConsumptionUseCase customerConsumptionUseCase;
        private readonly CustomerPresenter presenter;

        public FeedController(ICustomerConsumptionUseCase customerConsumptionUseCase, CustomerPresenter presenter)
        {
            this.customerConsumptionUseCase = customerConsumptionUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<CustomerResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetCustomerInvoices")]
        public IActionResult GetCustomerInvoices([FromBody]CustomerRequest input)
        {
            customerConsumptionUseCase.Execute(new CustomerConsumptionRequest(input.DocumentType, input.DocumentNumber));
            return presenter.ViewModel;
        }
    }
}