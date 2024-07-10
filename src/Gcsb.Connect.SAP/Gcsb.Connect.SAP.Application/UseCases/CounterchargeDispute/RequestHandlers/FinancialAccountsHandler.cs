using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class FinancialAccountsHandler : Handler
    {

        private readonly IFinancialAccountsClient financialAccountsClient;

        public FinancialAccountsHandler(IFinancialAccountsClient financialAccountsClient)
        {
            this.financialAccountsClient = financialAccountsClient;
        }

        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Consulting Financial Accounts - Transfer");

            if (request.CounterchargeDisputesAdjustment.Count == 0
                && request.CounterchargeDisputesBilling.Count == 0)
            {
                request.AddProcessingLog("Don't have any value for Countercharge_Dispute");
                return;
            }

            var servicesCode = request.CounterchargeDisputesAdjustment
                .Union(request.CounterchargeDisputesBilling).Select(s => s.CodigoServico).Distinct().ToList();

            var interfaceTypes = new List<string> { "Countercharge" };
            var accountTypes = new List<string> { "CounterchargePaid", "CounterchargeUnpaid", "ContractualFinePaid", "ContractualFineUnpaid" };

            request.AccountDetailsByService = financialAccountsClient.GetAccountDetailsByService(servicesCode, interfaceTypes);

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
                    request.FinancialAccountsNew.Add(new FinancialAccount(
                        sc.StoreAcronym,
                        sc.ServiceCode,
                        sc.ProviderCompanyAcronym,
                        sc.HaveIntercompany,
                        fa.InterfaceType,
                        fa.AccountType,
                        fa.FinancialAccount,
                        fa.FinancialAccountDeb,
                        fa.FinancialAccountCred
                    ))
                );
            });

            request.CounterchargeDisputesAdjustment.ForEach(f => f.FinancialAccountNew = request.FinancialAccountsNew.Find(w => w.ServiceCode.Equals(f.CodigoServico) && w.StoreAcronym.Equals(f.StoreAcronym) && w.ProviderCompanyAcronym.Equals(f.ProviderCompanyAcronym)));
            request.CounterchargeDisputesBilling.ForEach(f => f.FinancialAccountNew = request.FinancialAccountsNew.Find(w => w.ServiceCode.Equals(f.CodigoServico) && w.StoreAcronym.Equals(f.StoreAcronym) && w.ProviderCompanyAcronym.Equals(f.ProviderCompanyAcronym)));

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
