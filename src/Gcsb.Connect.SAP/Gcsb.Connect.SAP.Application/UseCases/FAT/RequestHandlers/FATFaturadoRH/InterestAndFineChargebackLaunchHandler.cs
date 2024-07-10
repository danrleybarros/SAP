using Autofac.Features.Indexed;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Helper;
using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH
{
    public class InterestAndFineChargebackLaunchHandler : Handler
    {
        private readonly IIndex<ChargeBackType, IChargeBackStrategy> chargeBackStrategy;
        private readonly ILauncher launcher;
        private string[] interestReceivables = new string[] { "SPJURTBRAC", "SPJURCLOUDCOC", };
        private string[] fineReceivables = new string[] { "SPMULTBRAC", "SPMULCLOUDCOC" };

        public InterestAndFineChargebackLaunchHandler(IIndex<ChargeBackType, IChargeBackStrategy> chargeBackStrategy, ILauncher launcher)
        {
            this.chargeBackStrategy = chargeBackStrategy;
            this.launcher = launcher;
        }

        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Processing interest and fine chargeBack lines");

            var stores = request.CounterchargeDisputes.Where(w => w.TipoAtividade.Equals("Countercharge Chargeback") && (interestReceivables.Contains(w.AReceber) || fineReceivables.Contains(w.AReceber))).Select(w => w.StoreAcronym).Distinct().ToList();

            stores.ForEach(store =>
            {
                var launches = new List<ILaunch>();
                var storeType = Domain.Util.ToEnum<StoreType>(store);
                var lineCount = request.Lines.ContainsKey(storeType) ? request.Lines[storeType].Count : 0;
                var interestAndFineFinancialAccount = request.InterestAndFineFinancialAccounts.FirstOrDefault(a => a.Store.Equals(storeType));

                chargeBackStrategy[ChargeBackType.TotalNotUsed].Add(request);
                chargeBackStrategy[ChargeBackType.TotalUsed].Add(request);
                chargeBackStrategy[ChargeBackType.DebtGranted].Add(request);
                chargeBackStrategy[ChargeBackType.RetifiedBoleto].Add(request);

                request.InterestAndFineCounterchargeChargebackServices.ToList().ForEach(f =>
                {
                    var interestServices = f.Value.Where(f => interestReceivables.Contains(f.Receivable)).ToList();

                    var chargebacksInterest = launcher.GetLaunches(
                        f.Key,
                        interestServices,
                        interestAndFineFinancialAccount.Interest,
                        store,
                        request.Cycle,
                        lineCount
                        );

                    lineCount += chargebacksInterest.Count;

                    var fineServices = f.Value.Where(f => fineReceivables.Contains(f.Receivable)).ToList();

                    var chargebacksFine = launcher.GetLaunches(
                        f.Key,
                        fineServices,
                        interestAndFineFinancialAccount.Fine,
                        store,
                        request.Cycle,
                        lineCount
                        );

                    lineCount += chargebacksFine.Count;

                    launches.AddRange(chargebacksInterest);
                    launches.AddRange(chargebacksFine);
                });

                request.AddLaunchs(storeType, launches);
            });

            sucessor?.ProcessRequest(request);
        }
    }
}
