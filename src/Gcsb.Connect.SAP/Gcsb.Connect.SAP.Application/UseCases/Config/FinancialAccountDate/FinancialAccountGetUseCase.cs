using System;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.Repositories.Config;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.FinancialAccountDate
{
    public class FinancialAccountGetUseCase : IFinancialAccountGetUseCase
    {
        private readonly IFinancialAccountReadOnlyRepository financialAccountReadOnlyRepository;

        public FinancialAccountGetUseCase(IFinancialAccountReadOnlyRepository financialAccountReadOnlyRepository)
        {
            this.financialAccountReadOnlyRepository = financialAccountReadOnlyRepository;
        }

        public List<Domain.Config.FinancialAccountDate.FinancialAccount> Execute(DateTime date, string idUser)
            => financialAccountReadOnlyRepository.GetFinancialAccounts(date);
    }
}
