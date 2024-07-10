using Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.CreditGrantedFinancialAccount.GetAll
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditGrantedFinancialAccountController : ControllerBase
    {
        private readonly IGetAllUseCase getAllUseCase;
        private readonly GetAllPresenter presenter;

        public CreditGrantedFinancialAccountController(IGetAllUseCase getAllUseCase,
            GetAllPresenter presenter)
        {
            this.getAllUseCase = getAllUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [Authorize]
        //[Permission(101111)]
        [ProducesResponseType(typeof(List<GetAllResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var request = new GetAllRequest();
            getAllUseCase.Execute(request);

            return presenter.ViewModel;
        }
    }
}
