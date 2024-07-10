using Gcsb.Connect.SAP.Application.UseCases.Config.Services;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.Services.ServiceResponse;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.Services.ServicesRequest;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IIdentityParser<UserInfo> identityParser;
        private readonly IServicesUseCase servicesUseCase;
        private readonly ServicesPresenter presenter;

        public FeedController(IIdentityParser<UserInfo> identityParser, IServicesUseCase servicesUseCase, ServicesPresenter presenter)
        {
            this.identityParser = identityParser;
            this.servicesUseCase = servicesUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<ServiceOutput>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetServicesByInvoice")]
        public IActionResult Services([FromBody]ServiceInput input)
        {
            servicesUseCase.Execute(input.InvoicesNumber);
            return presenter.ViewModel;
        }
    }
}