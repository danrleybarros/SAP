using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.FinancialAccountDate
{
    public interface IFinancialAccountGetUseCase
    {
        List<Domain.Config.FinancialAccountDate.FinancialAccount> Execute(DateTime date, string idUser);
    }
}
