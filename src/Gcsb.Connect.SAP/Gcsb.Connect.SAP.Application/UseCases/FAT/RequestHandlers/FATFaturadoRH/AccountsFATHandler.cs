using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH
{
    public class AccountsFATHandler : AccountsHandler
    {
        protected override List<string> interfaceTypes => new List<string> { "Billed" };
        protected override List<string> accountTypes => new List<string> { "Billed", "Discount", "ContractualFine" };

        public AccountsFATHandler(IFinancialAccountsClient financialAccountsClient)
            : base(financialAccountsClient)
        { }
    }
}
