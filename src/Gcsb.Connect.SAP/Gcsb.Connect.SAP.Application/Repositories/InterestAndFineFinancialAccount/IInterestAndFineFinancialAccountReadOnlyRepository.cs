using Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount
{
    public interface IInterestAndFineFinancialAccountReadOnlyRepository
    {
        Domain.Config.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount GetByStore(StoreType store);
        Domain.Config.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount GetById(Guid id);
        List<Domain.Config.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount> GetAll();
    }
}
