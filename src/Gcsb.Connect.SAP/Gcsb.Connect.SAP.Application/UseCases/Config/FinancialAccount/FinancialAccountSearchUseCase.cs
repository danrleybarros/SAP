using Gcsb.Connect.SAP.Application.Repositories.Config;
using Gcsb.Connect.SAP.Domain.Config;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config
{
    public class FinancialAccountSearchUseCase : IFinancialAccountSearchUseCase
    {
        private readonly IFinancialAccountReadOnlyRepository FinancialAccountRepository;

        public FinancialAccountSearchUseCase(IFinancialAccountReadOnlyRepository FinancialAccountRepository)
        {
            this.FinancialAccountRepository = FinancialAccountRepository;
        }

        public List<FinancialAccountResult> Execute(FinancialAccountRequest filter)
            => new List<FinancialAccountResult>(FinancialAccountRepository.GetFinancialAccounts(filter.ServiceCode, filter.FinanceAccount, filter.StoreType).Select(s => new FinancialAccountResult(s))).ToList();
    }
}
