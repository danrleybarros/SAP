using Gcsb.Connect.SAP.Domain.Critical;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Critical.RequestHandlers
{
    public class GetAccountingEntryHandler : Handler
    {
        public override void ProcessRequest(CriticaRequest request)
        {
            request.AddProcessingLog("Critica - Get Accounting Account of Financial Account");

            var listAccountingEntry = new List<AccountingEntry>();

            if (request.Accounts.Critic.FinancialAccount == null &&
                request.Accounts.Critic.AccountingAccount.Credit == null &&
                request.Accounts.Critic.AccountingAccount.Debit == null)
                throw new ArgumentException("Critica - Not all Accounting Entry have been configured");

            listAccountingEntry.Add(
                new AccountingEntry(request.Accounts.Critic.FinancialAccount,
                                    "C",
                                    request.Accounts.Critic.AccountingAccount.Credit));

            listAccountingEntry.Add(
                new AccountingEntry(request.Accounts.Critic.FinancialAccount,
                                    "D",
                                    request.Accounts.Critic.AccountingAccount.Debit));

            request.AccountingEntriesCritica = listAccountingEntry;

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
