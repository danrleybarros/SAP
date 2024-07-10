using Gcsb.Connect.SAP.Domain.GF.Nfe;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Repositories.GF
{
    public interface IReturnNFReadOnlyRepository
    {
        List<ReturnNF> GetReturnNF();
        ReturnNF GetReturnNF(string InvoiceId);
        List<ReturnNF> GetReturnNF(ReturnNF request);
        List<ReturnNF> GetReturnNF(Guid ReturnNFFile);
        List<ReturnNF> GetReturnNF(List<string> Invoices);
    }
}
