using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Repositories.DocFeed
{
    public interface IBillFeedConvertRepository
    {
        ICollection<Domain.JSDN.BillFeedDoc> FromCsv(string base64String, Guid IdFile);
    }
}
