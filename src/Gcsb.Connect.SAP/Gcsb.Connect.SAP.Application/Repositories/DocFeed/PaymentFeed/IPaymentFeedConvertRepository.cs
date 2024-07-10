using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IPaymentFeedConvertRepository<T>
    {
        ICollection<T> FromTsv(string base64String, Guid idHeader,string fileName);
    }
}
