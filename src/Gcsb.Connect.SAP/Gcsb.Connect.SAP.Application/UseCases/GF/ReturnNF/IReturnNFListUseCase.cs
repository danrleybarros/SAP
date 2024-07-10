using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.ReturnNF
{
    public interface IReturnNFListUseCase
    {
        List<Domain.GF.Nfe.ReturnNF> Execute(List<string> invoices);
    }
}
