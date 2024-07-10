using System.Linq;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.Boleto;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.Boleto
{
    public class AccountsHandler : Handler<ARRBoleto>, IAccountsHandler<ARRBoleto>
    {
        private readonly IFinancialAccountsClient financialAccountsClient;        

        public AccountsHandler(IFinancialAccountsClient financialAccountsClient)
        {
            this.financialAccountsClient = financialAccountsClient;            
        }

        public override void ProcessRequest(IARRRequest<ARRBoleto> request)
        {
            request.AddProcessingLog("Consulting Financial Accounts - ARR Boleto");

            var accounts = financialAccountsClient.GetAllManagementFinancialAccount();

            request.AccountsDto = accounts.Where(w => w.IsProvider == false).ToList();
       
            sucessor?.ProcessRequest(request);
        }
    }
}
