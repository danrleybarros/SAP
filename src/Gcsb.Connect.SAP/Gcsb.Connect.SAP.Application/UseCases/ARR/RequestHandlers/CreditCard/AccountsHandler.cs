using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCard
{
    public class AccountsHandler : Handler<ARRCreditCard>, IAccountsHandler<ARRCreditCard>
    {
        private readonly IFinancialAccountsClient financialAccountsClient;
        
        public AccountsHandler(IFinancialAccountsClient financialAccountsClient)
        {
            this.financialAccountsClient = financialAccountsClient;            
        }

        public override void ProcessRequest(IARRRequest<ARRCreditCard> request)
        {
            request.AddProcessingLog("Consulting Financial Accounts - ARR CreditCard");

            var accounts = financialAccountsClient.GetAllManagementFinancialAccount();

            request.AccountsDto = accounts.Where(w => w.IsProvider == false).ToList();

            sucessor?.ProcessRequest(request);
        }
    }
}
