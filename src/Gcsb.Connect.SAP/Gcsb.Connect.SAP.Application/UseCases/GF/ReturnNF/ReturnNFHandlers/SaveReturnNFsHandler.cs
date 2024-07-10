using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.Messaging.Messages.Log;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.ReturnNF.ReturnNFHandlers
{
    public class SaveReturnNFsHandler : Handler
    {
        private readonly IReturnNFWriteOnlyRepository returnNFWriteOnlyRepository;

        public SaveReturnNFsHandler(IReturnNFWriteOnlyRepository returnNFWriteOnlyRepository)
        {
            this.returnNFWriteOnlyRepository = returnNFWriteOnlyRepository;
        }

        public override void ProcessRequest(ReturnNFRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, request.File.Id, "Saving Return NF"));
            request.TotalNFs = returnNFWriteOnlyRepository.Add(request.NFs);

            if (request.TotalNFs <= 0)
                throw new ApplicationException("SaveDocs");

            request.Logs.Add(Log.CreateProcessingLog(request.Service, request.File.Id, $"Saved: {request.TotalNFs} NF's in database"));

            sucessor?.ProcessRequest(request);
        }
    }
}