using Gcsb.Connect.SAP.Domain.GF.Nfe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.RegularExpressions;
using Gcsb.Connect.SAP.Domain;
using UseCaseRequest = Gcsb.Connect.SAP.Application.UseCases.Files.ReprocessingReturnNFe;
using System.Runtime.Serialization;
using Gcsb.Connect.SAP.Application.UseCases.Files.ReprocessingReturnNFe;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.ReprocessingReturnNFe
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IReprocessingReturnNFeUseCase useCase;

        public FileController(IReprocessingReturnNFeUseCase useCase)
        {
            this.useCase = useCase;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(FileResult), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [Route("ReprocessingReturnNFe")]
        public IActionResult ReprocessingReturnNFe([FromBody] ReprocessingReturnNFeRequest input)
        {
            var files = input.Files
                .Select(s => new NfeFiles(s.FileName, s.Store.GetAttributeOfType<EnumMemberAttribute>().Value.ToLower(), GetDate(s.FileName, 8)))
                .ToList();

            var useCaseRequest = new UseCaseRequest::ReprocessingReturnNFeRequest(input.BillFeedFileId, files);
            useCase.Execute(useCaseRequest);

            return Ok();
        }

        private string GetDate(string fileName, int positions)
            => new Regex("[0-9]{" + positions + "}").Match(fileName).Value;
    }
}
