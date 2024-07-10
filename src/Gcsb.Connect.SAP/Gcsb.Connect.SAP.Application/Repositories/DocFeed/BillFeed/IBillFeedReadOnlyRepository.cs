using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Gcsb.Connect.SAP.Application.Boundaries.Deferral;
using Gcsb.Connect.SAP.Domain.JSDN;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IBillFeedReadOnlyRepository
    {
        List<BillFeedDoc> GetBillFeed();

        List<BillFeedDoc> GetBillFeed(Expression<Func<BillFeedDoc, bool>> func);

        BillFeedCycleDate GetCycleByBillFeedId(Guid billFeedId);
    }
}
