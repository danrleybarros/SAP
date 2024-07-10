using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class GetInterestAndFineFinancialAccountHandler : Handler
    {
        private readonly IFinancialAccountsClient financialAccountsClient;

        public GetInterestAndFineFinancialAccountHandler(IFinancialAccountsClient financialAccountsClient)
        {
            this.financialAccountsClient = financialAccountsClient;
        }

        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Get Interest And Fine Financial Account");

            request.InterestAndFineFinancialAccounts = financialAccountsClient.GetAllInterestAndFineFinancialAccount();

            if (request.InterestAndFineFinancialAccounts == null || !request.InterestAndFineFinancialAccounts.Any())
                throw new ArgumentException("The financial account for Interest and Fine wasn't recorded");

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
