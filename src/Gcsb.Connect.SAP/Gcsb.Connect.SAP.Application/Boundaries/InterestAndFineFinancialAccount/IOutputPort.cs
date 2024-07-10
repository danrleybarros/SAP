using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Boundaries.InterestAndFineFinancialAccount
{
    public interface IOutputPort
    {
        void Standard(Guid id);

        void Standard(Domain.Config.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount interestAndFineFinancialAccount);

        void Standard(List<Domain.Config.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount> interestAndFineFinancialAccount);

        void Error(string message);

        void NotFound(string message);
    }
}
