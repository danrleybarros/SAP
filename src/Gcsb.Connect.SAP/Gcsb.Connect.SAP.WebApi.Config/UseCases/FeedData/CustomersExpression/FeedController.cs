using Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomersExpression
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IAllCustomersUseCase allCustomersUseCase;
        private readonly CustomersExprPresenter presenter;

        public FeedController(IAllCustomersUseCase allCustomersUseCase, CustomersExprPresenter presenter)
        {
            this.allCustomersUseCase = allCustomersUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<CustomersExprResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetAllCustomers")]
        public IActionResult GetCustomersByExpression([FromBody]CustomersExprRequest input)
        {
            allCustomersUseCase.Execute(new AllCustomersRequest(input.TypeSearch, input.Value));
            return presenter.ViewModel;
        }
    }
}
