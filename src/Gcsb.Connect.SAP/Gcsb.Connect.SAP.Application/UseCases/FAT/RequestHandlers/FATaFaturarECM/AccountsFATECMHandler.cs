using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarECM
{
    public class AccountsFATECMHandler : AccountsHandler
    {
        protected override List<string> interfaceTypes => new List<string> { "CycleEstimation" };
        protected override List<string> accountTypes => new List<string> { "Billed", "Discount", "ContractualFine" };

        public AccountsFATECMHandler(IFinancialAccountsClient financialAccountsClient)
            : base(financialAccountsClient)
        { }
    }
}
