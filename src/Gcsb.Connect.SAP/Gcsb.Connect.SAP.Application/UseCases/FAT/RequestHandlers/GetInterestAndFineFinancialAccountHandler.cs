using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public class GetInterestAndFineFinancialAccountHandler : Handler
    {
        private readonly IFinancialAccountsClient financialAccountsClient;

        public GetInterestAndFineFinancialAccountHandler(IFinancialAccountsClient financialAccountsClient)
        {
            this.financialAccountsClient = financialAccountsClient;
        }

        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Get Interest And Fine Financial Account");

            request.InterestAndFineFinancialAccounts = financialAccountsClient.GetAllInterestAndFineFinancialAccount();

            if (AccountsValidation(request.InterestAndFineFinancialAccounts))
            {
                request.AddExceptionLog($"Interest and Fines doest not have all accounts registered", $"Interest and Fines doest not have all accounts registered");
                throw new ArgumentException("Interest and Fines doest not have all accounts registered");
            }

            request.InterestAccountingEntries = GetInterestFinancialAccounts(request.InterestAndFineFinancialAccounts, request.TypeRegister);
            request.FinesAccountingEntries = GetFinesFinancialAccounts(request.InterestAndFineFinancialAccounts, request.TypeRegister);

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }

        private List<AccountingEntry> GetInterestFinancialAccounts(List<InterestAndFineFinancialAccount> accounts, TypeRegister typeRegister)
        {
            List<AccountingEntry> accountingEntries = new List<AccountingEntry>();
            accounts.ForEach(account =>
            {

                if (typeRegister == TypeRegister.FATAFATURARECM)
                {
                    accountingEntries.AddRange(new List<AccountingEntry>
                    {
                        new AccountingEntry(account.Interest.FinancialAccount, "C", account.Interest.CycleEstimate.Credit, account.Store),
                        new AccountingEntry(account.Interest.FinancialAccount, "D", account.Interest.CycleEstimate.Debit, account.Store)
                    });
                }
                else
                {
                    accountingEntries.AddRange(new List<AccountingEntry>
                    {
                        new AccountingEntry(account.Interest.FinancialAccount, "C", account.Interest.InterestOrFine.Credit, account.Store),
                        new AccountingEntry(account.Interest.FinancialAccount, "D", account.Interest.InterestOrFine.Debit, account.Store)
                    });
                }
            });
            return accountingEntries;
        }

        private List<AccountingEntry> GetFinesFinancialAccounts(List<InterestAndFineFinancialAccount> accounts, TypeRegister typeRegister)
        {
            List<AccountingEntry> accountingEntries = new List<AccountingEntry>();
            accounts.ForEach(account =>
            {
                if (typeRegister == TypeRegister.FATAFATURARECM)
                {
                    accountingEntries.AddRange(new List<AccountingEntry>
                    {
                        new AccountingEntry(account.Fine.FinancialAccount, "C", account.Fine.CycleEstimate.Credit, account.Store),
                        new AccountingEntry(account.Fine.FinancialAccount, "D",account.Fine.CycleEstimate.Debit, account.Store)
                    });
                }
                else
                {
                    accountingEntries.AddRange(new List<AccountingEntry>
                    {
                        new AccountingEntry(account.Fine.FinancialAccount, "C", account.Fine.InterestOrFine.Credit, account.Store),
                        new AccountingEntry(account.Fine.FinancialAccount, "D",account.Fine.InterestOrFine.Debit, account.Store)
                    });
                }
            });
            return accountingEntries;
        }

        private bool AccountsValidation(List<InterestAndFineFinancialAccount> accounts)
        {
            bool error = false;

            accounts.ForEach(account =>
            {
                if (string.IsNullOrEmpty(account?.Fine?.FinancialAccount) || string.IsNullOrEmpty(account?.Fine?.InterestOrFine?.Credit) || string.IsNullOrEmpty(account?.Fine?.InterestOrFine?.Debit)
                    || string.IsNullOrEmpty(account?.Fine?.CycleEstimate?.Debit) || string.IsNullOrEmpty(account?.Fine?.CycleEstimate?.Credit))
                    error = true;

                if (string.IsNullOrEmpty(account?.Interest?.FinancialAccount) || string.IsNullOrEmpty(account?.Interest?.InterestOrFine?.Credit) || string.IsNullOrEmpty(account?.Interest?.InterestOrFine?.Debit)
                    || string.IsNullOrEmpty(account?.Interest?.CycleEstimate?.Debit) || string.IsNullOrEmpty(account?.Interest?.CycleEstimate?.Credit))
                    error = true;
            });
            return error;
        }
    }
}
