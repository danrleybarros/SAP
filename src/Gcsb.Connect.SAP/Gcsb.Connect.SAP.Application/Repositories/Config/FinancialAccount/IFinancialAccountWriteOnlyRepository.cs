using System;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.Config;

namespace Gcsb.Connect.SAP.Application.Repositories.Config
{
    public interface IFinancialAccountWriteOnlyRepository
    {
        Guid Add(FinancialAccount financialAccount);

        Guid Update(FinancialAccount financialAccount);

        int Add(IEnumerable<FinancialAccount> financialAccount);

        int Delete(Guid financialAccountId);

        int Add(Domain.Config.FinancialAccountDate.FinancialAccount financialAccount);
    }
}
