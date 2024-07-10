using Gcsb.Connect.SAP.Application.Repositories.GF;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.CISS.RequestHandlers
{
    public class ReturnNfsHandler : Handler
    {
        private readonly IReturnNFReadOnlyRepository returnNFReadOnlyRepository;

        public ReturnNfsHandler(IReturnNFReadOnlyRepository nfHandler)
        {
            this.returnNFReadOnlyRepository = nfHandler;
        }

        public override void ProcessRequest(CISSRequest request)
        {
            request.AddProcessingLog("Consulting NF's - CISS");
            if ((request?.Invoices?.Count ?? 0) == 0)
                throw new ArgumentException("NF information not found");

            List<Domain.GF.Nfe.ReturnNF> returnNFs = new List<Domain.GF.Nfe.ReturnNF>();

            returnNFs = returnNFReadOnlyRepository.GetReturnNF(request.Invoices.Select(s => s.InvoiceNumber).ToList());
                  
            request.ReturnNFs = returnNFs;

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}