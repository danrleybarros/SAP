using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IManagementFinancialAccountWriteOnlyRepository
    {
        Guid Add(ManagementFinancialAccount managementFinancialAccount);
        int Update(ManagementFinancialAccount managementFinancialAccount);
        int Remove(ManagementFinancialAccount managementFinancialAccount);
        void RemoveAll(List<ManagementFinancialAccount> managementFinancialAccounts);
    }
}
