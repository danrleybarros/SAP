using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public class GetAccountingAccountHandler : Handler
    {
        
        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Get Accounting Account of Financial Account");
            
            var accountingEntries = request.FinancialAccounts                
                .Select(s => new
                {
                    s.InterfaceType,
                    s.AccountType,
                    s.ServiceCode,
                    s.Store,
                    s.Provider,
                    s.HaveIntercompany,
                    s.FinancialAccountValue,
                    ContaContabil = new Dictionary<string, string> { { "C", s.FinancialAccountCred }, { "D", s.FinancialAccountDeb } }
                }).ToList();

            string interfaceType;

            if (request.TypeRegister == TypeRegister.FATAFATURARACM)
                interfaceType = "Billing";
            else if (request.TypeRegister == TypeRegister.FATAFATURARECM)
                interfaceType = "CycleEstimation";
            else
                interfaceType = "Billed";

            accountingEntries.Where(w => w.InterfaceType == interfaceType && w.AccountType == "Billed").ToList()
                .ForEach(f =>
                {
                    request.AccountingEntriesFaturamento.AddRange(f.ContaContabil.
                        Select(c => new AccountingEntry(f.FinancialAccountValue, c.Key, c.Value, f.Store, f.ServiceCode, f.Provider, f.HaveIntercompany)).ToList());
                });

            accountingEntries.Where(w => w.InterfaceType == interfaceType && w.AccountType == "Discount").ToList()
                .ForEach(f =>
                {
                    request.AccountingEntriesDesconto.AddRange(f.ContaContabil.
                        Select(c => new AccountingEntry(f.FinancialAccountValue, c.Key, c.Value, f.Store, f.ServiceCode, f.Provider, f.HaveIntercompany)).ToList());
                });

            if (request.AccountingEntriesFaturamento.Count == 0)
                throw new ArgumentException("Not all services have Accounting Entry");

            if (interfaceType!= "Billing" && request.AccountingEntriesDesconto.Count == 0)
                throw new ArgumentException("Not all services have Accounting Entry");

            sucessor?.ProcessRequest(request);
        }
    }
}
