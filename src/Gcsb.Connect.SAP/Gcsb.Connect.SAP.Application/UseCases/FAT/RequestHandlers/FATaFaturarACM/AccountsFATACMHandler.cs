using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarACM
{
    public class AccountsFATACMHandler : AccountsHandler
    {
        protected override List<string> interfaceTypes => new List<string> { "Billing" };
        protected override List<string> accountTypes => new List<string> { "Billed" };

        public AccountsFATACMHandler(IFinancialAccountsClient financialAccountsClient)
            : base(financialAccountsClient)
        { }
    }
}
