using Gcsb.Connect.SAP.Domain.GF.Nfe;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Repositories.GF
{
    public interface IReturnNFConvertRepository
    {
        ICollection<ReturnNF> FromCsv(string base64String, Guid FileId, string storeAcronym);
    }
}
