using Gcsb.Connect.Messaging.Messages.Log;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.CISS.RequestHandlers
{
    public class GetFileNameHandler : Handler
    {
        public override void ProcessRequest(CISSRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Getting Report FileName"));

            if (request.Invoices.Any())
                request.CISSFileName = Util.GetFileName("GW_CISS_01_", request.Invoices.SelectMany(s => s.Services).ToList(), "txt");
            else
                request.CISSFileName = "No Invoice data found";

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
