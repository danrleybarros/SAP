using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.LEI1601;

namespace Gcsb.Connect.SAP.Application.Repositories.Lei1601
{
    public interface ILei1601Repository
    {
        IEnumerable<Launch> GetAll();
    }
}
