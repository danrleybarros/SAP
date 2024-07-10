using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarECM
{
    public class LaunchContractualFineHandler : Handler
    {
        private readonly IUniqueStoreFinancialAccount uniqueStoreFinancialAccount;

        public LaunchContractualFineHandler(IUniqueStoreFinancialAccount uniqueStoreFinancialAccount)
        {
            this.uniqueStoreFinancialAccount = uniqueStoreFinancialAccount;
        }

        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Start processing FAT - LaunchContractualFineHandler");

            var getStores = request.Services.Select(s => s.StoreAcronym).Distinct().ToList();
            getStores.AddRange(request.Services.Select(s => s.ProviderCompanyAcronym).Distinct().ToList());

            var stores = getStores.Distinct().ToList();

            request.ContractualFineServices.ForEach(p => p.Invoice = p.Invoice.Customer == null ? request.Invoices.FirstOrDefault(i => i.InvoiceNumber == p.Invoice.InvoiceNumber) : p.Invoice);

            stores.ForEach(store =>
            {
                var storeType = Domain.Util.ToEnum<StoreType>(store);
                var lines = new List<ILaunch>();

                var contractualFineServices = request.ContractualFineServices?.Where(w => w.Invoice.StoreAcronym.Equals(store) || w.ProviderCompanyAcronym.Equals(store)).ToList();
                var contractualFineAccountingEntries = request.ContractualFineAccountingEntries.Where(e => e.Store.Equals(storeType) || e.Provider.Equals(storeType)).ToList();

                lines.AddRange(GetLines(
                    contractualFineServices, 
                    contractualFineAccountingEntries, 
                    request.Cycle.AddMonths(1), 
                    storeType,
                    "CycleEstimation",
                    "ContractualFine",
                    request.AccountDetailsByService));
                
                request.AddLaunchs(storeType, lines);
            });

            sucessor?.ProcessRequest(request);
        }

        private List<Domain.FAT.FATaFaturarECM.LaunchECM> GetLines(
            List<ServiceFilter> services,
            List<AccountingEntry> accountingEntries,
            DateTime cycle,
            StoreType storeType,
            string interfaceType,
            string accountType,
            Domain.FinancialAccountsClient.FinancialAccount.AccountDetailsByServiceDto accountDetailsByServiceDto = null)
        {
            return services
                .Join(accountingEntries,
                    s => new { serviceCode = s.ServiceCode, storeAcromyn = Domain.Util.ToEnum<StoreType>(s.Invoice.StoreAcronym), storeProvider = Domain.Util.ToEnum<StoreType>(s.ProviderCompanyAcronym) },
                    a => new { serviceCode = a.ServiceCode, storeAcromyn = a.Store, storeProvider = a.Provider }, (s, a) => new { s, a })
                .GroupBy(g => new { g.a.FinancialAccount, g.s.Invoice.Customer.BillingStateOrProvince, g.s.Invoice.PaymentMethod, g.s.ServiceType, g.a.AccountingEntryType, g.a.AccountingAccount, g.a.HaveIntercompany })                
                .Where(w => w.Sum(sum => Convert.ToDecimal(sum.s.GrandTotalRetailPrice.Value)) > 0)
                .Select((s, index) => new Domain.FAT.FATaFaturarECM.LaunchECM(
                    (index + 1),
                    cycle,
                    s.Key.FinancialAccount,
                    s.Sum(sum => Convert.ToDecimal(sum.s.GrandTotalRetailPrice.Value)),
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
                    false,
                    s.Key.HaveIntercompany))
                .ToList();
        }
    }
}
