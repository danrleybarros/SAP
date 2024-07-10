using Gcsb.Connect.SAP.Domain.AJU;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class GetContractualFineAccountingEntryHandler : Handler
    {
        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Transfer - Get Contractial Fine Accounting Account of Financial Account");
            
            var accountTypes = new List<string> { "ContractualFinePaid", "ContractualFineUnpaid" };

            var accounts = request.FinancialAccountsNew.Where(w => w.InterfaceType == "Countercharge" && accountTypes.Contains(w.AccountType)).ToList();

            if (AccountsValidation(accounts))
            {
                request.AddExceptionLog("GetContractualFineAccountingEntryHandler", "Transfer - Not all Contractual Fine Accounting Entry have been configured");
                return;
            }

            request.FinancialAccountsNew
            .ToList()
            .ForEach(f =>
            {
                if (f.InterfaceType == "Countercharge" && f.AccountType == "ContractualFinePaid") 
                {
                    request.ServiceAccountingAccountBillings.Add(new ServiceAccountingAccountAJU(f.FinancialAccountValue, f.ServiceCode, f.HaveIntercompany, f.Store, f.Provider, TypeAccounting.Credito, f.FinancialAccountCred));
                    request.ServiceAccountingAccountBillings.Add(new ServiceAccountingAccountAJU(f.FinancialAccountValue, f.ServiceCode, f.HaveIntercompany, f.Store, f.Provider, TypeAccounting.Debito, f.FinancialAccountDeb));
                }

                if (f.InterfaceType == "Countercharge" && f.AccountType == "ContractualFineUnpaid") 
                {
                    request.ServiceAccountingAccountAdjusment.Add(new ServiceAccountingAccountAJU(f.FinancialAccountValue, f.ServiceCode, f.HaveIntercompany, f.Store, f.Provider, TypeAccounting.Credito, f.FinancialAccountCred));
                    request.ServiceAccountingAccountAdjusment.Add(new ServiceAccountingAccountAJU(f.FinancialAccountValue, f.ServiceCode, f.HaveIntercompany, f.Store, f.Provider, TypeAccounting.Debito, f.FinancialAccountDeb));
                }
            });

            sucessor?.ProcessRequest(request);
        }

        private bool AccountsValidation(List<Domain.FinancialAccountsClient.FinancialAccount.FinancialAccount> accounts)
        {
            return accounts.Any(acc => string.IsNullOrEmpty(acc.FinancialAccountValue)
            || string.IsNullOrEmpty(acc.FinancialAccountCred)
            || string.IsNullOrEmpty(acc.FinancialAccountDeb));
        }
    }
}
