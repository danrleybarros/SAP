using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.Messaging.Messages.Log;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers
{
    public class GetNFsHandler : Handler
    {
        private readonly IReturnNFReadOnlyRepository returnNFReadOnlyRepository;

        public GetNFsHandler(IReturnNFReadOnlyRepository returnNFReadOnlyRepository)
        {
            this.returnNFReadOnlyRepository = returnNFReadOnlyRepository;
        }

        public override void ProcessRequest(ItemsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Object request is null");
                     
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Getting nf's by id file"));
            request.ReturnNFs = returnNFReadOnlyRepository.GetReturnNF(request.IdNFFile);
           

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
