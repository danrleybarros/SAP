using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config
{
    public interface IFinancialAccountDeleteUseCase
    {
        int Execute(Guid FinancialAccountId, string UserId, string UserName);
    }
}
