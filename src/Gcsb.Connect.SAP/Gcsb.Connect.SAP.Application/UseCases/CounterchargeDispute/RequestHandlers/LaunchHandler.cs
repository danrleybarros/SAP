using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain;
using Gcsb.Connect.SAP.Domain.AJU;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class LaunchHandler : Handler
    {
        private readonly IUniqueStoreFinancialAccount uniqueStoreFinancialAccount;

        public LaunchHandler(IUniqueStoreFinancialAccount uniqueStoreFinancialAccount)
        {
            this.uniqueStoreFinancialAccount = uniqueStoreFinancialAccount;
        }

        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Start processing CounterchargeDispute - LaunchHandler");

            var counterchargeDisputes = request.CounterchargeDisputesAdjustment.Union(request.CounterchargeDisputesBilling).ToList();

            var getStores = counterchargeDisputes.Select(s => s.StoreAcronym).Distinct().ToList();
            getStores.AddRange(counterchargeDisputes.Select(s => s.ProviderCompanyAcronym).Distinct().ToList());

            var stores = getStores.Distinct().ToList();

            var ignoreList = new List<string>() { "INTEREST", "FINES", "PAYMENT CREDIT", "CONTRACTUAL FINE", "COUNTERCHARGE CHARGEBACK" };

            var chargebackReceivables = new string[] { "SPIAASTBRAC", "SPSAASTBRAC", "SPMUCCTBRA", "SPIAASCLOUDCOC", "SPSAASCLOUDCOC", "SPMUCCCLOUDCO" };

            foreach (var store in stores)
            {
                var storeType = Domain.Util.ToEnum<StoreType>(store);

                if (storeType.Equals(StoreType.Others))
                    continue;

                var launches = new List<Launch>();

                var adjustment = GetLines(
                    request.CounterchargeDisputesAdjustment.Where(w => (w.StoreAcronym.Equals(store) || w.ProviderCompanyAcronym.Equals(store))
                        && !ignoreList.Contains(w.TipoAtividade.ToUpper()) && w.TipoDisputa.ToLower() != "rectified boleto").ToList(),
                    request.ServiceAccountingAccountAdjusment,
                    request.DateFrom,
                    request.DateTo,
                    storeType,
                    0,
                    request.AccountDetailsByService);

                var retifiedBoleto = GetLines(
                    request.CounterchargeDisputesAdjustment.Where(w => (w.StoreAcronym.Equals(store) || w.ProviderCompanyAcronym.Equals(store))
                        && !ignoreList.Contains(w.TipoAtividade.ToUpper()) && w.TipoDisputa.ToLower() == "rectified boleto").ToList(),
                    request.ServiceAccountingAccountBillings,
                    request.DateFrom,
                    request.DateTo,
                    storeType,
                    0,
                    request.AccountDetailsByService);

                var billingDisputes = request.CounterchargeDisputesBilling
                    .Where(w => (w.StoreAcronym.Equals(store) || w.ProviderCompanyAcronym.Equals(store))
                    && !ignoreList.Contains(w.TipoAtividade.ToUpper()) && (w.ValorContestado ?? 0) == 0).ToList();

                var counterchargeChargebackDisputes = request.CounterchargeDisputesBilling
                    .Where(w => (w.StoreAcronym.Equals(store) || w.ProviderCompanyAcronym.Equals(store))
                    && w.TipoAtividade.ToUpper().Equals("COUNTERCHARGE CHARGEBACK")
                    && w.TipoDisputa.ToUpper().Equals("FUTURE ACCOUNT")
                    && chargebackReceivables.Contains(w.AReceber.ToUpper())).ToList();

                billingDisputes.AddRange(counterchargeChargebackDisputes);

                var billingLines = GetLines(
                    billingDisputes,
                    request.ServiceAccountingAccountBillings,
                    request.DateFrom,
                    request.DateTo,
                    storeType,
                    adjustment.Count);

                launches.AddRange(adjustment);
                launches.AddRange(billingLines);
                launches.AddRange(retifiedBoleto);

                request.AddLaunchs(storeType, launches);
            };

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }

        private List<Launch> GetLines(
         List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute> counterchargeDisputes,
         List<ServiceAccountingAccountAJU> accountingEntries,
         DateTime launchDate,
         DateTime billingCycle,
         StoreType storeType,
         int qtdeLinhas = 0,
         Domain.FinancialAccountsClient.FinancialAccount.AccountDetailsByServiceDto accountDetailsByServiceDto = null)
        {
            return counterchargeDisputes
               .Where(f => f.ValorContestado.HasValue && f.ValorContestado != 0 && f.MetodoPagamento != null)
               .Join(accountingEntries,
                    c => new { serviceCode = c.CodigoServico, storeAcromyn = Domain.Util.ToEnum<StoreType>(c.StoreAcronym), storeProvider = Domain.Util.ToEnum<StoreType>(c.ProviderCompanyAcronym) },
                    a => new { serviceCode = a.ServiceCode, storeAcromyn = a.Store, storeProvider = a.Provider },
                    (c, a) => new { c, a })
               .GroupBy(g => new { g.a.Store, g.a.Provider, g.a.FinancialAccount, g.c.MetodoPagamento, g.c.TipoDisputa, g.c.UF, g.a.Type, g.a.HaveIntercompany })
               .Select((s) => new Launch(
                   ++qtdeLinhas,
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
