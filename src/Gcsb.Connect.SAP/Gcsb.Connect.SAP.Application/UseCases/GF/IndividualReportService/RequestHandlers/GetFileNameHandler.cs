using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.Messaging.Messages.Log;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService.RequestHandlers
{
    public class GetFileNameHandler : Handler
    {
        public override void ProcessRequest(ISIChainRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Getting Report FileName"));

            if (request.Lines.Any())
                request.ISIFileName = Util.GetFileName("GW_SERVICOS_01_", request.Invoices.SelectMany(s => s.Services).ToList(), "txt");

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
