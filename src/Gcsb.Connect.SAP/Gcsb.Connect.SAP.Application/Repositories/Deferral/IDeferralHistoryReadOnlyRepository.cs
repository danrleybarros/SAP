using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Gcsb.Connect.SAP.Domain.Deferral;

namespace Gcsb.Connect.SAP.Application.Repositories.Deferral
{
    public interface IDeferralHistoryRepository
    {
        List<DeferralHistory> GetAll();
        List<DeferralHistory> Get(Expression<Func<DeferralHistory, bool>> func);
        int Add(IEnumerable<DeferralHistory> deferralHistories);
        int Add(DeferralHistory deferralHistory);
        int Update(DeferralHistory deferralHistory);
    }
}
