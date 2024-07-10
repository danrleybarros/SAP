
using System;

namespace Gcsb.Connect.SAP.Application.Boundaries.ManangementFinancialAccount
{
   public interface IOutputPort
    {
        void Standard(Guid id);

        void Standard(Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount managementFinancialAccount);

        void Error(string message);

        void NotFound(string message);
    }
}
