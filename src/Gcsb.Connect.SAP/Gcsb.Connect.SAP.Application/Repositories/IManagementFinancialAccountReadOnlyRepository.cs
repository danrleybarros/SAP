using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IManagementFinancialAccountReadOnlyRepository
    {
        ManagementFinancialAccount GetbyFilter(Expression<Func<ManagementFinancialAccount, bool>> func);
        ManagementFinancialAccount Get();
        ManagementFinancialAccount GetById(Guid id);
        List<ManagementFinancialAccount> GetAll();
    }
}
