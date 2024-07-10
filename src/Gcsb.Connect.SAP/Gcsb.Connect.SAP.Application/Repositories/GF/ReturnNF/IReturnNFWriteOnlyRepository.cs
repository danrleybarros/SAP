using Gcsb.Connect.SAP.Domain.GF.Nfe;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Repositories.GF
{
    public interface IReturnNFWriteOnlyRepository
    {
        Guid Add(ReturnNF NF);
        int Add(List<ReturnNF> NFs);
    }
}
