using Gcsb.Connect.SAP.Application.UseCases.Config.GetDetailServiceByInvoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetDetailServiceByInvoice
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly GetDetailServicePresenter presenter;
        private readonly IGetDetailServiceByInvoiceUseCase useCase;

        public FeedController(GetDetailServicePresenter presenter, 
            IGetDetailServiceByInvoiceUseCase useCase)
        {
            this.presenter = presenter;
            this.useCase = useCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetDetailServiceResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetDetailServiceAndCustomerByInvoice")]
        public IActionResult GetDetailServiceAndCustomerByInvoice([FromBody]GetDetailServiceRequest input)
        {
            useCase.Execute(new GetDetailServiceByInvoiceRequest(input.Invoices));
            return presenter.ViewModel;
        }
    }
}
