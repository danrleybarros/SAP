using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.Messaging.Messages.Log;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Master.RequestHandlers
{
    public class GetReturnNFHandler : Handler<MasterRequest>, IGetReturnNFHandler
    {
        private readonly IReturnNFReadOnlyRepository returnNFReadOnlyRepository;

        public GetReturnNFHandler(IReturnNFReadOnlyRepository returnNFReadOnlyRepository)
        {
            this.returnNFReadOnlyRepository = returnNFReadOnlyRepository;
        }

        public override void ProcessRequest(MasterRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Getting nf's by list of invoice number"));
            request.ReturnNFs = returnNFReadOnlyRepository.GetReturnNF(request.IdNFFile);

            if (request.ReturnNFs.Count == 0)
            {
                request.Logs.Add(Log.CreateProcessingLog(request.Service, "Not Found any invoice return - Master"));
                throw new ArgumentNullException("Not Found any invoice return - Master");
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
