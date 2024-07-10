using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH
{
    public class LaunchInterestAndFinesHandler : Handler
    {
        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Start processing FAT - LaunchInterestAndFinesHandler");

            var stores = request.Invoices.Select(s => s.StoreAcronym).Distinct().ToList();

            stores.ForEach(store =>
            {
                var storeType = Domain.Util.ToEnum<StoreType>(store.ToLower());
                var lines = new List<ILaunch>();
                var interestServices = request.InterestServices?.Where(w => w.Invoice.StoreAcronym.Equals(store)).ToList();
                var finesServices = request.FineServices?.Where(w => w.Invoice.StoreAcronym.Equals(store)).ToList();

                var interestAccountingEntries = request.InterestAccountingEntries.Where(e => e.Store.Equals(storeType)).ToList();
                var finesAccountingEntries = request.FinesAccountingEntries.Where(e => e.Store.Equals(storeType)).ToList();

                lines.AddRange(GetLines(interestServices, interestAccountingEntries, request.Cycle, storeType));
                lines.AddRange(GetLines(finesServices, finesAccountingEntries, request.Cycle, storeType));             
                request.AddLaunchs(storeType, lines);
            });

            sucessor?.ProcessRequest(request);
        }        

        private List<Domain.FAT.FATFaturado.LaunchFaturado> GetLines(
            List<ServiceFilter> services,
            List<AccountingEntry> accountingEntries,            
            DateTime cycle,                        
            StoreType storeType)
        {
            return services
                .SelectMany(m => accountingEntries, (service, account) => new { service, account })
                .GroupBy(g => new { g.account.FinancialAccount, g.service.Invoice.Customer.BillingStateOrProvince, g.service.Invoice.PaymentMethod, g.service.ServiceType, g.account.AccountingEntryType, g.account.AccountingAccount })                
                .Where(w => w.Sum(sum => Convert.ToDecimal(sum.service.GrandTotalRetailPrice.Value)) > 0)
                .Select((s, index) => new Domain.FAT.FATFaturado.LaunchFaturado(
                    (index + 1),
                    cycle,
                    s.Key.FinancialAccount,
                    s.Sum(sum => Convert.ToDecimal(sum.service.GrandTotalRetailPrice.Value)),
                    Util.GetUF(s.Key.BillingStateOrProvince, storeType).InternalOrder,
                    Util.GetUFByState(s.Key.BillingStateOrProvince, storeType),
                    cycle,
                    s.Key.PaymentMethod.RemoveAccents(),
                    s.Key.AccountingEntryType,
                    s.Key.AccountingAccount,
                    storeType,
                    false))
                .ToList();
        }        
    }
}
