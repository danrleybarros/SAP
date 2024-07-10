using System.Linq;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCardIntercompany
{
    public class AccountsHandler : Handler<ARRCreditCardInter>, IAccountsHandler<ARRCreditCardInter>
    {
        private readonly IFinancialAccountsClient financialAccountsClient;

        public AccountsHandler(IFinancialAccountsClient financialAccountsClient)
        {
            this.financialAccountsClient = financialAccountsClient;
        }

        public override void ProcessRequest(IARRRequest<ARRCreditCardInter> request)
        {
            request.AddProcessingLog("Consulting Financial Accounts - ARR Intercompany");

            var accounts = financialAccountsClient.GetAllManagementFinancialAccount();

            request.AccountsDto = accounts.Where(w => w.IsProvider == true).ToList();

            sucessor?.ProcessRequest(request);
        }
    }
}
