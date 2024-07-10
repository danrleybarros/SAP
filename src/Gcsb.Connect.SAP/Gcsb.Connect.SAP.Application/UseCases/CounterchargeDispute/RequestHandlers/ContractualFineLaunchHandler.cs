using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain;
using Gcsb.Connect.SAP.Domain.AJU;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class ContractualFineLaunchHandler : Handler
    {
        private readonly IUniqueStoreFinancialAccount uniqueStoreFinancialAccount;

        public ContractualFineLaunchHandler(IUniqueStoreFinancialAccount uniqueStoreFinancialAccount)
        {
            this.uniqueStoreFinancialAccount = uniqueStoreFinancialAccount;
        }

        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Start processing CounterchargeDispute - ContractualFineLaunchHandler");

            var counterchargeDisputes = request.CounterchargeDisputesAdjustment.Union(request.CounterchargeDisputesBilling).ToList();

            var getStores = counterchargeDisputes.Select(s => s.StoreAcronym).Distinct().ToList();
            getStores.AddRange(counterchargeDisputes.Select(s => s.ProviderCompanyAcronym).Distinct().ToList());

            var stores = getStores.Distinct().ToList();

            foreach (var store in stores)
            {
                var storeType = Domain.Util.ToEnum<StoreType>(store);

                if (storeType.Equals(StoreType.Others))
                    continue;

                var billingDisputes = request.CounterchargeDisputesBilling
                    .Where(c => (c.StoreAcronym.Equals(store) || c.ProviderCompanyAcronym.Equals(store)) 
                    && c.TipoDisputa.Equals("Future Account") 
                    && c.TipoAtividade.Equals("Contractual Fine")).ToList();
                
                var adjustmentDisputes = request.CounterchargeDisputesAdjustment
                    .Where(c => (c.StoreAcronym.Equals(store) || c.ProviderCompanyAcronym.Equals(store)) 
                    && c.TipoAtividade.Equals("Contractual Fine")).ToList();
                
                var lineCount = request.Lines.FirstOrDefault(l => l.Key.Equals(storeType)).Value?.Count ?? 0;
                
                var adjustment = GetLines(
                    adjustmentDisputes, 
                    request.ServiceAccountingAccountAdjusment, 
                    request.DateFrom, 
                    request.DateTo, 
                    storeType,                    
                    lineCount);
                
                lineCount = request.Lines.FirstOrDefault(l => l.Key.Equals(storeType)).Value?.Count ?? 0;
                
                var billing = GetLines(
                    billingDisputes, 
                    request.ServiceAccountingAccountBillings,
                    request.DateFrom, 
                    request.DateTo, 
                    storeType,                    
                    lineCount);

                request.AddLaunchs(storeType, adjustment);
                request.AddLaunchs(storeType, billing);
            };

            sucessor?.ProcessRequest(request);
        }

        private List<Launch> GetLines(
             List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute> counterchargeDisputes,
             List<ServiceAccountingAccountAJU> accountingEntries,                          
             DateTime launchDate,
             DateTime billingCycle,
             StoreType storeType,             
             int lineCount = 0,
             AccountDetailsByServiceDto accountDetailsByServiceDto = null)
        {
            return counterchargeDisputes
                .Where(f => f.ValorContestado.HasValue && f.ValorContestado != 0 && f.MetodoPagamento != null)                 
                .Join(accountingEntries,
                    c => new { serviceCode = c.CodigoServico, storeAcromyn = Domain.Util.ToEnum<StoreType>(c.StoreAcronym), storeProvider = Domain.Util.ToEnum<StoreType>(c.ProviderCompanyAcronym) },
                    a => new { serviceCode = a.ServiceCode, storeAcromyn = a.Store, storeProvider = a.Provider },
                    (c, a) => new { c, a })
               .GroupBy(g => new { g.a.Store, g.a.Provider, g.a.FinancialAccount, g.c.MetodoPagamento, g.c.TipoDisputa, g.c.UF, g.a.Type, g.a.HaveIntercompany })
               .Select((s) => new Launch(
                   ++lineCount,
                   launchDate,
                   s.Key.FinancialAccount,
                   s.Sum(m => Math.Abs(m.c.ValorContestado.Value)),
                   s.Key.HaveIntercompany && storeType.Equals(StoreType.TLF2) ? string.Empty : Util.GetUF(s.Key.UF, storeType).InternalOrder,
                   billingCycle,
                   s.Key.UF,
                   s.Key.HaveIntercompany && storeType.Equals(StoreType.TLF2) ? string.Empty : s.FirstOrDefault().c.MetodoPagamento.RemoveAccents(),
                   s.Key.Type.GetAttributeOfType<EnumMemberAttribute>().Value,
                   uniqueStoreFinancialAccount.GetAccount(s.FirstOrDefault()?.c, s.FirstOrDefault()?.a, s.Key.Type, accountDetailsByServiceDto, storeType),             
                   storeType,
                   s.Key.HaveIntercompany))
               .ToList();
        }
    }
}
