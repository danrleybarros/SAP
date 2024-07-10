using Gcsb.Connect.Messaging.Messages.Log;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Client.RequestHandlers
{
    public class GetFileNameHandler : Handler
    {
        public override void ProcessRequest(ClientChainRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Getting filename - Client GF"));
            if (request.Customers.Any())
                request.FileName = Util.GetFileName("GW_CLIENTES_01_", request.Customers.SelectMany(s => s.Invoice.Services).ToList(), "txt");
            else
                request.FileName = "No data for Customers";

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
