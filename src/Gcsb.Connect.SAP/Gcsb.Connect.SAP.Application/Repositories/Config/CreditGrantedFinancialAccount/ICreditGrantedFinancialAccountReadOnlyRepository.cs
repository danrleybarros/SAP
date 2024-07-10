using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Repositories.Config.CreditGrantedFinancialAccount
{
    public interface ICreditGrantedFinancialAccountReadOnlyRepository
    {
        Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount GetByStore(StoreType storeAcronym);
        List<Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount> GetAll();
    }
}
