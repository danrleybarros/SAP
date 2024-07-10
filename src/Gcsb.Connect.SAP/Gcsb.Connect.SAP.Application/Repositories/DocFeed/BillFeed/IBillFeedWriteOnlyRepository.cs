using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IBillFeedWriteOnlyRepository
    {
        int Add(Domain.JSDN.BillFeedDoc billFeedDoc);
        int Add(IEnumerable<Domain.JSDN.BillFeedDoc> billFeedDocs);
        int Delete(Domain.JSDN.BillFeedDoc billFeedDoc);        
        int Delete(Expression<Func<BillFeedDoc, bool>> func);

    }
}
