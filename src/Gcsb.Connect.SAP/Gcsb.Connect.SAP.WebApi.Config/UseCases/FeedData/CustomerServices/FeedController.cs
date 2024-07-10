using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomerServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IIdentityParser<UserInfo> identityParser;
        private readonly ICustomerServicesUseCase customerServicesUseCase;
        private readonly CustomerServicesPresenter presenter;

        public FeedController(ICustomerServicesUseCase customerServicesUseCase,
            CustomerServicesPresenter presenter,
             IIdentityParser<UserInfo> identityParser)
        {
            this.customerServicesUseCase = customerServicesUseCase;
            this.presenter = presenter;
            this.identityParser = identityParser;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<CustomerServicesResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetCustomerAndServicesByInvoiceNumber")]
        public IActionResult CustomerServices([FromBody] CustomerServicesRequest input)
        {
            var request = new Application.UseCases.Config.CustomerServices.CustomerServicesRequest(input.InvoiceNumbers);
            customerServicesUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
