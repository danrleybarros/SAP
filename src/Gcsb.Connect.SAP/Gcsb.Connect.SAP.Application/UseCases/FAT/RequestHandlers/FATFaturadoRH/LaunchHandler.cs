using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.FinancialAccount;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH
{
    public class LaunchHandler : Handler
    {
        private readonly IUniqueStoreFinancialAccount uniqueStoreFinancialAccount;

        public LaunchHandler(IUniqueStoreFinancialAccount uniqueStoreFinancialAccount)
        {
            this.uniqueStoreFinancialAccount = uniqueStoreFinancialAccount;
        }

        public override void ProcessRequest(FATRequest request)
        {
            var error = false;

            request.AddProcessingLog("Start processing FAT - LaunchHandler");            

            var serviceWithouAccount = request.ServicesWithoutFinancialAccounts();

            serviceWithouAccount.ForEach(f =>
            {
                error = true;
                request.AddExceptionLog($"Service code: {f.ServiceCode} não possui conta", $"Service code: {f.ServiceCode} não possui conta");
            });

            if (!error && DeferralAccountingEntry.IsValidFinancialAccount)
            {
                var getStores = request.Services.Select(s => s.StoreAcronym).Distinct().ToList();
                getStores.AddRange(request.Services.Select(s => s.ProviderCompanyAcronym).Distinct().ToList());

                var stores = getStores.Distinct().ToList();

                request.Services.ForEach(p => p.Invoice = p.Invoice.Customer == null ? request.Invoices.FirstOrDefault(i => i.InvoiceNumber == p.Invoice.InvoiceNumber) : p.Invoice);

                stores.ForEach(store =>
                {
                    var storeType = Domain.Util.ToEnum<StoreType>(store);
                    var lines = new List<ILaunch>();
                    var services = request.Services.Where(w => w.Invoice.StoreAcronym.Equals(store) || w.ProviderCompanyAcronym.Equals(store)).ToList();
                    
                    var faturamento = GetLines(
                        services, 
                        request.AccountingEntriesFaturamento, 
                        request.Cycle, 
                        false, 
                        storeType,
                        "Billed",
                        "Billed",
                        request.AccountDetailsByService);

                    var desconto = GetLines(
                        services, 
                        request.AccountingEntriesDesconto, 
                        request.Cycle, 
                        true, 
                        storeType,
                        "Billed",
                        "Discount",
                        request.AccountDetailsByService);

                    if (faturamento is not null && faturamento.Count() > 0)
                    	lines.AddRange(faturamento);

                    if (desconto is not null && desconto.Count() > 0)
                    	lines.AddRange(desconto);

                    request.AddLaunchs(storeType, lines);
                });
            }
            else
            {
                DeferralAccountingEntry.Logs.Clear();
                throw new ArgumentException("Not all services have financial account");
            }

            sucessor?.ProcessRequest(request);
        }

        private List<Domain.FAT.FATFaturado.LaunchFaturado> GetLines(
            List<ServiceFilter> services,
            List<AccountingEntry> accountingEntries,
            DateTime cycle,
            bool isDiscount,
            StoreType storeType,
            string interfaceType,
            string accountType,
            Domain.FinancialAccountsClient.FinancialAccount.AccountDetailsByServiceDto accountDetailsByServiceDto = null)
        {
            return services?
                .Join(accountingEntries, 
                    s => new { serviceCode = s.ServiceCode, storeAcromyn = Domain.Util.ToEnum<StoreType>(s.Invoice.StoreAcronym), storeProvider = Domain.Util.ToEnum<StoreType>(s.ProviderCompanyAcronym) },
                    a => new { serviceCode = a.ServiceCode, storeAcromyn = a.Store, storeProvider = a.Provider }, (s, a) => new { s, a })
                .GroupBy(g => new { g.a.Store, g.a.Provider, g.a.FinancialAccount, g.s.Invoice.Customer.BillingStateOrProvince, g.s.Invoice.PaymentMethod, g.s.ServiceType, g.a.AccountingEntryType, g.a.HaveIntercompany })
                .Where(w => (isDiscount ? w.Sum(sum => sum.s.TotalDiscount) : Convert.ToDecimal(w.Sum(sum => sum.s.GrandTotalRetailPrice)) + Convert.ToDecimal(w.Sum(sum => sum.s.TotalDiscount))) > 0M)
                .Select((s, index) => new Domain.FAT.FATFaturado.LaunchFaturado(
                    (index + 1),
                    cycle,
                    s.Key.FinancialAccount,
                    isDiscount ? Convert.ToDecimal(s.Sum(sum => sum.s.TotalDiscount)) : Convert.ToDecimal(s.Sum(sum => sum.s.GrandTotalRetailPrice)) + Convert.ToDecimal(s.Sum(sum => sum.s.TotalDiscount)),
                    s.Key.HaveIntercompany && storeType.Equals(StoreType.TLF2) ? string.Empty : Util.GetUF(s.Key.BillingStateOrProvince, storeType).InternalOrder,
                    Util.GetUFByState(s.Key.BillingStateOrProvince, storeType),
                    cycle,
                    s.Key.HaveIntercompany && storeType.Equals(StoreType.TLF2) ? string.Empty : s.Key.PaymentMethod.RemoveAccents(),
                    s.Key.AccountingEntryType,
                    uniqueStoreFinancialAccount.GetAccountFats(
                        s.FirstOrDefault()?.s, 
                        s.FirstOrDefault()?.a,
                        s.FirstOrDefault()?.a.AccountingEntryType,
                        accountDetailsByServiceDto,
                        interfaceType,
                        accountType,
                        storeType),
                    storeType,
                    isDiscount,
                    s.Key.HaveIntercompany))
                .ToList();
        }
    }
}