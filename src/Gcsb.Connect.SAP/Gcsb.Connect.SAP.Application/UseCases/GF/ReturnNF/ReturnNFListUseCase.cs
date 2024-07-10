using Gcsb.Connect.SAP.Application.Repositories.GF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.ReturnNF
{
    public class ReturnNFListUseCase : IReturnNFListUseCase
    {
        IReturnNFReadOnlyRepository returnNfRepository;
        public ReturnNFListUseCase(IReturnNFReadOnlyRepository returnNfRepository)
        {
            this.returnNfRepository = returnNfRepository;
        }

        public List<Domain.GF.Nfe.ReturnNF> Execute(List<string> invoices)
        {
            var list = returnNfRepository.GetReturnNF(invoices);
            return list;
        }
    }
}
