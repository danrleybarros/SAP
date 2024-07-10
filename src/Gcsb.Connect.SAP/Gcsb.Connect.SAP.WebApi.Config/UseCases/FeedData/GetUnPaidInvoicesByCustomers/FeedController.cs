using Gcsb.Connect.SAP.Application.UseCases.Config.GetUnPaidInvoicesByCustomers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetUnPaidInvoicesByCustomers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IGetUnPaidInvoicesByCustomersUseCase useCase;
        private readonly GetUnPaidInvoicesByCustomersPresenter presenter;

        public FeedController(IGetUnPaidInvoicesByCustomersUseCase useCase, GetUnPaidInvoicesByCustomersPresenter presenter)
        {
            this.useCase = useCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<GetUnPaidInvoicesByCustomersInput>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize]
        [Route("GetUnPaidInvoicesWithoutPayFilterByDocuments")]
        public IActionResult GetUnPaidInvoicesWithoutPayFilterByDocuments([FromBody] GetUnPaidInvoicesByCustomersInput input)
        {
            var documents = input.Documents.Select(s => new DataDocumentRequest(s.Value, s.SearchType)).ToList();
            var request = new GetUnPaidInvoicesByCustomersRequest(documents);

            useCase.Execute(request);

            return presenter.ViewModel;
        }
    }
}
