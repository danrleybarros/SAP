using System.Linq;
using Gcsb.Connect.SAP.Application.Repositories.Lei1601;

namespace Gcsb.Connect.SAP.Application.UseCases.Lei1601.RequestHandlers
{
    public class GetDataHandler : Handler
    {
        private readonly ILei1601Repository repository;

        public GetDataHandler(ILei1601Repository repository)
        {
            this.repository = repository;
        }

        public override void ProcessRequest(Lei1601Request request)
        {
            request.AddProcessingLog("Getting data Lei 1601");

            var lines = repository.GetAll();

            if (!lines.Any())
                request.AddProcessingLog("No data found to generate file Lei1601");

            request.Lines.AddRange(lines);
            sucessor?.ProcessRequest(request);
        }
    }
}
