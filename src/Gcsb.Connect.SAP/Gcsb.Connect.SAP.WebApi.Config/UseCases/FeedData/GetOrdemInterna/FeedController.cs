using Gcsb.Connect.SAP.Application.UseCases.Config.OrdemInterna;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetOrdemInterna
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IOrdemInternaUseCase ordemInternaUseCase;
        private readonly GetOrdemInternaPresenter presenter;

        public FeedController(IOrdemInternaUseCase ordemInternaUseCase, GetOrdemInternaPresenter presenter)
        {
            this.ordemInternaUseCase = ordemInternaUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<GetOrdemInternaResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetOrdemInterna")]
        public IActionResult GetOrdemInterna([FromBody] GetOrdemInternaRequest input)
        {
            ordemInternaUseCase.Execute(new OrdemInternaRequest(input.UFs, input.Store));
            return presenter.ViewModel;
        }
    }
}
