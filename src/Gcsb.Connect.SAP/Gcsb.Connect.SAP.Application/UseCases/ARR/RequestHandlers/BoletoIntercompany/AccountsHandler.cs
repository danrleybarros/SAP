using System.Linq;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.ARRBoletoIntercompany;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.BoletoIntercompany
{
    public class AccountsHandler : Handler<ARRBoletoInter>, IAccountsHandler<ARRBoletoInter>
    {
        private readonly IFinancialAccountsClient financialAccountsClient;

        public AccountsHandler(IFinancialAccountsClient financialAccountsClient)
        {
            this.financialAccountsClient = financialAccountsClient;
        }

        public override void ProcessRequest(IARRRequest<ARRBoletoInter> request)
        {
            request.AddProcessingLog("Consulting Financial Accounts - ARR Boleto Intercompany");

            var accounts = financialAccountsClient.GetAllManagementFinancialAccount();

            request.AccountsDto = accounts.Where(w => w.IsProvider == true).ToList();
     
            sucessor?.ProcessRequest(request);
        }
    }
}
