using Gcsb.Connect.SAP.Domain.AJU;
using Gcsb.Connect.SAP.Domain.Config;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class GetAccountingEntryHandler : Handler
    {
        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Transfer - Get Accounting Account of Financial Account");

            var accountTypes = new List<string> { "CounterchargePaid", "CounterchargeUnpaid" };

            var accounts = request.FinancialAccountsNew.Where(w => w.InterfaceType == "Countercharge" && accountTypes.Contains(w.AccountType)).ToList();

            if (AccountsValidation(accounts))
            {
                request.AddExceptionLog("GetAccountingEntryHandler", "Transfer - Not all Accounting Entry have been configured");
                return;
            };

            AddAccountingAccount(request);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }

        private void AddAccountingAccount(CounterchargeDisputeRequest request)
        {
            request.FinancialAccountsNew
                .ToList()
                .ForEach(f =>
                {
                    // Retified Boleto
                    if (f.InterfaceType == "Countercharge" && f.AccountType == "CounterchargeUnpaid")
                    {
                        request.ServiceAccountingAccountBillings.Add(MountServiceAccount(f, TypeAccounting.Credito));
                        request.ServiceAccountingAccountBillings.Add(MountServiceAccount(f, TypeAccounting.Debito));
                    }

                    // Future Account
                    if (f.InterfaceType == "Countercharge" && f.AccountType == "CounterchargePaid")
                    {
                        request.ServiceAccountingAccountAdjusment.Add(MountServiceAccount(f, TypeAccounting.Credito));
                        request.ServiceAccountingAccountAdjusment.Add(MountServiceAccount(f, TypeAccounting.Debito));
                    }
                });
        }

        private bool AccountsValidation(List<Domain.FinancialAccountsClient.FinancialAccount.FinancialAccount> accounts)
        {
            return accounts.Any(acc => string.IsNullOrEmpty(acc.FinancialAccountValue)
            || string.IsNullOrEmpty(acc.FinancialAccountCred)
            || string.IsNullOrEmpty(acc.FinancialAccountDeb));
        }

        private ServiceAccountingAccountAJU MountServiceAccount(Domain.FinancialAccountsClient.FinancialAccount.FinancialAccount financialAccount, TypeAccounting typeAccounting)
        {
            return new ServiceAccountingAccountAJU(financialAccount.FinancialAccountValue,
                financialAccount.ServiceCode,
                financialAccount.HaveIntercompany,
                financialAccount.Store,
                financialAccount.Provider,
                typeAccounting,
                typeAccounting == TypeAccounting.Credito ? financialAccount.FinancialAccountCred : financialAccount.FinancialAccountDeb);
        }
    }
}
