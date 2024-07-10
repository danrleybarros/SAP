using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.Repositories.DocFeed
{
    public interface IDocFeedConvertRepository
    {
        ICollection<Domain.JSDN.IDoc> FromCsv(string base64String, Guid IdFile);
    }
}
