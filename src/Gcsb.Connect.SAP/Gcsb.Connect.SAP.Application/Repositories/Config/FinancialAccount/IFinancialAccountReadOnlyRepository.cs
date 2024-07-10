using System;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.Config;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Application.Repositories.Config
{
    public interface IFinancialAccountReadOnlyRepository
    {
        List<FinancialAccount> GetFinancialAccounts();

        List<FinancialAccount> GetFinancialAccounts(List<string> listServiceCode);

        List<FinancialAccount> GetFinancialAccounts(string ServiceCode, string FinancialAccount, StoreType store);

        FinancialAccount GetFinancialAccount(string serviceCode, StoreType storeType);

        List<Domain.Config.FinancialAccountDate.FinancialAccount> GetFinancialAccounts(DateTime date);

        FinancialAccount GetFinancialAccount(Guid id);
    }
}