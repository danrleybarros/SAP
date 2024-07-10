using Domain = Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount
{
    public interface IInterestAndFineFinancialAccountWriteOnlyRepository
    {
        Guid Add(Domain::InterestAndFineFinancialAccount interestAndFineFinancialAccount);
        int Update(Domain::InterestAndFineFinancialAccount interestAndFineFinancialAccount);
        int Remove(Domain::InterestAndFineFinancialAccount interestAndFineFinancialAccount);
        void RemoveAll(List<Domain::InterestAndFineFinancialAccount> interestAndFineFinancialAccount);
    }
}
