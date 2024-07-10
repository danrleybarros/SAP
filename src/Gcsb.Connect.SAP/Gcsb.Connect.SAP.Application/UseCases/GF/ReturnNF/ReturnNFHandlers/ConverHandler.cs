using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.Messaging.Messages.Log;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.ReturnNF.ReturnNFHandlers
{
    public class ConvertHandler : Handler
    {
        private readonly IReturnNFConvertRepository ReturnNFConvert;

        public ConvertHandler(IReturnNFConvertRepository returnNFConvert)
        {
            this.ReturnNFConvert = returnNFConvert;
        }

        public override void ProcessRequest(ReturnNFRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Converting csv file - Return NF"));
            request.NfeFiles.ToList().ForEach(file => request.NFs.AddRange(ReturnNFConvert.FromCsv(file.Value, request.File.Id, file.Key).ToList()));

            sucessor?.ProcessRequest(request);
        }
    }
}
