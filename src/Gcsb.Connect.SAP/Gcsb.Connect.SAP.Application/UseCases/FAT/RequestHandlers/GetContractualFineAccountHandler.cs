using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public class GetContractualFineAccountHandler : Handler
    {
        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Get Contract Fines Account of Financial Account");

            var accounts = new List<FinancialAccount>();

            if (request.TypeRegister == TypeRegister.FATAFATURARECM)
                accounts = request.FinancialAccounts.Where(w => w.InterfaceType == "CycleEstimation" && w.AccountType == "ContractualFine").ToList();
            else
                accounts = request.FinancialAccounts.Where(w => w.InterfaceType == "Billed" && w.AccountType == "ContractualFine").ToList();

            if (AccountsValidation(accounts))
            {
                request.AddExceptionLog($"Contract Fines doesn't not have all accounts registered", $"Contract Fines doesn't not have all accounts registered");
                throw new ArgumentException("Contract Fines doesn't not have all accounts registered");
            }

            request.ContractualFineAccountingEntries = GetContractualFinesFinancialAccounts(accounts);

            sucessor?.ProcessRequest(request);
        }

        private List<AccountingEntry> GetContractualFinesFinancialAccounts(List<FinancialAccount> accounts)
        {
            List<AccountingEntry> accountingEntries = new List<AccountingEntry>();

            accounts.ForEach(account =>
            {
                accountingEntries.AddRange(new List<AccountingEntry>
                {
                    new AccountingEntry(account.FinancialAccountValue, "C", account.FinancialAccountCred, account.Store, account.ServiceCode, account.Provider, account.HaveIntercompany),
                    new AccountingEntry(account.FinancialAccountValue, "D", account.FinancialAccountDeb, account.Store, account.ServiceCode, account.Provider, account.HaveIntercompany)
                });
            });
            return accountingEntries;
        }
        
        private bool AccountsValidation(List<FinancialAccount> accounts)
        {
            return accounts.Any(acc => string.IsNullOrEmpty(acc.FinancialAccountValue)
            || string.IsNullOrEmpty(acc.FinancialAccountCred)
            || string.IsNullOrEmpty(acc.FinancialAccountDeb));
        }
    }
}
