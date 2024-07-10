using Gcsb.Connect.SAP.Application.Repositories.GF;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook.RequestHandlers
{
    public class GetReturnNF : Handler
    {
        private readonly IReturnNFReadOnlyRepository returnNFReadOnlyRepository;

        public GetReturnNF(IReturnNFReadOnlyRepository returnNFReadOnlyRepository)
        {
            this.returnNFReadOnlyRepository = returnNFReadOnlyRepository;
        }

        public override void ProcessRequest(AxiliaryBookRequest request)
        {
            request.AddProcessingLog("Consulting table returnNf on database - Axiliary Book");

            request.ReturnNFs = returnNFReadOnlyRepository.GetReturnNF(request.IdFileReturnNF);

            if (!request.ReturnNFs.Any())
                throw new ArgumentException($"Not Found NF on database to id {request.IdFileReturnNF}");

            if (sucessor != null)
                sucessor.ProcessRequest(request);

        }
    }
}
