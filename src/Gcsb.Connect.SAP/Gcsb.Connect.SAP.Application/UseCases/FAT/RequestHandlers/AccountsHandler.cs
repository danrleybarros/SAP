using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public abstract class AccountsHandler : Handler
    {
        protected abstract List<string> interfaceTypes { get; }
        protected abstract List<string> accountTypes { get; }
        
        private readonly IFinancialAccountsClient financialAccountsClient;

        public AccountsHandler(IFinancialAccountsClient financialAccountsClient)
        {            
            this.financialAccountsClient = financialAccountsClient;
        }

        public override void ProcessRequest(FATRequest request)
        {
            var services = request.Services.Select(s => s.ServiceCode).ToList();

            var contractualFineServices = request.ContractualFineServices.Where(w => !services.Contains(w.ServiceCode)).Select(w => w.ServiceCode).Distinct().ToList();
            services.AddRange(contractualFineServices);

            request.AddProcessingLog("Consulting Financial Accounts - FAT");

            request.AccountDetailsByService = financialAccountsClient.GetAccountDetailsByService(services, interfaceTypes);

            var financialAccounts = request.AccountDetailsByService.Services
                .Select(s => new
                {
                    s.StoreAcronym, 
                    s.ServiceCode,
                    s.ProviderCompanyAcronym,
                    HaveIntercompany = s.StoreAcronym == s.ProviderCompanyAcronym ? false : true,
                    AccountDetail = s.StoreAcronym == s.ProviderCompanyAcronym 
                        ? s.AccountDetail.Store.Where(w => accountTypes.Contains(w.AccountType)).ToList()
                        : s.AccountDetail.Intercompany.Where(w => accountTypes.Contains(w.AccountType)).ToList()
                }).ToList();
                        
            financialAccounts.ForEach(sc =>
            {
                sc.AccountDetail.ForEach(fa =>
                    request.FinancialAccounts.Add(new FinancialAccount(
                        sc.StoreAcronym,
                        sc.ServiceCode,
                        sc.ProviderCompanyAcronym,
                        sc.HaveIntercompany,
                        fa.InterfaceType,
                        fa.AccountType,                        
                        fa.FinancialAccount,
                        fa.FinancialAccountDeb,
                        fa.FinancialAccountCred)));
            });

            sucessor?.ProcessRequest(request);
        }
    }
}
