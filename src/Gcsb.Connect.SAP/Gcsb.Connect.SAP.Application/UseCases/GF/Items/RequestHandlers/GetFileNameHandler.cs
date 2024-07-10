using Gcsb.Connect.Messaging.Messages.Log;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers
{
    public class GetFileNameHandler : Handler
    {
        public override void ProcessRequest(ItemsRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Getting filename - Client GF"));
            request.FileName = Util.GetFileName("GW_ITENS_01_", request.Invoices.SelectMany(s => s.Services).ToList(), "txt");

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
