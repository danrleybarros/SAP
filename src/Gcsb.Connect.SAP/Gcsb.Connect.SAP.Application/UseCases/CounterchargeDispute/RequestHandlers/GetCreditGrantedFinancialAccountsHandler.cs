using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class GetCreditGrantedFinancialAccountsHandler : Handler
    {
        private readonly IFinancialAccountsClient financialAccountsClient;

        public GetCreditGrantedFinancialAccountsHandler(IFinancialAccountsClient financialAccountsClient)
        {
            this.financialAccountsClient = financialAccountsClient;
        }

        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Start processing CounterchargeDispute - GetCreditGrantedFinancialAccountsHandler");

            request.CreditGrantedFinancialAccounts = financialAccountsClient.GetAllCreditGrantedFinancialAccount();

            if(request.CreditGrantedFinancialAccounts == null)
            {
                request.AddProcessingLog("No credit granted financial account found.");
                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
