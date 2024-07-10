using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config
{
    public interface IFinancialAccountSearchUseCase
    {
        List<FinancialAccountResult> Execute(FinancialAccountRequest filter);
    }
}
