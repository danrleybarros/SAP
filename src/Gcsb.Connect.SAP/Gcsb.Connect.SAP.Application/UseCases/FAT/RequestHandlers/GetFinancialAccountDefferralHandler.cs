using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public class GetFinancialAccountDefferralHandler : Handler
    {
        public readonly IFinancialAccountsClient financialAccountRepository;

        public GetFinancialAccountDefferralHandler(IFinancialAccountsClient financialAccountRepository)
        {
            this.financialAccountRepository = financialAccountRepository;
        }

        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Getting Deferral Financial Accounts on GW api and database");           

            if (request.DeferralOffers.Any())
            {
                var interfaces = new List<string> { "Billed", "Countercharge", "CycleEstimation", "Billing" };
                var serviceCodes = request.DeferralOffers.Select(o => o.ServiceCode).Distinct().ToList();
                request.AccountingAccounts = financialAccountRepository.GetAccountDetailsByService(serviceCodes, interfaces);
                request.DeferralFinancialAccounts = financialAccountRepository.GetAllDeferralFinancialAccount();               
            }

            sucessor?.ProcessRequest(request);

        }

  
    }
}
