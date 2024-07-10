using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Deferral;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Entities;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.FinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Launch;
using Gcsb.Connect.SAP.Domain;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public class LaunchDeferralHandler : Handler
    {
        private readonly IDeferralStrategy strategy;
        private ILauncher launcher;
        private List<string> validStores = new List<string> { "telerese", "CloudCo" };

        public LaunchDeferralHandler(IDeferralStrategy strategy, ILauncher launcher)
        {
            this.strategy = strategy;
            this.launcher = launcher;
        }

        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog($"Launching Deferral Offers in interface {nameof(request.TypeRegister)}");

            var launchDeferralOffers = strategy.DeferOffer(request.DeferralOffers, request.DeferralFinancialAccounts, request.AccountingAccounts);

            if (launchDeferralOffers.Any())
            {
                validStores.ForEach(store =>
                {
                    var deferral = launchDeferralOffers.Where(w => w.StoreAcronym.ToLower() == store.ToLower()).ToList();
                    var storeType = store.ToStoreType();
                    var lineCount = request.Lines.ContainsKey(storeType) ? request.Lines[storeType].Count : 0;

                    var deferrals = launcher.GetLaunchFAT(
                           deferral,
                           store,
                           request.Cycle,
                           lineCount,
                           request.TypeRegister);

                    lineCount += deferrals.Count;
                    if (deferral.Any())
                    {
                        request.AddLaunchs(storeType, deferrals);
                        request.HasDeferral = true;
                    }
                        
                });
             
            }
            else
                request.Logs.AddRange(DeferralAccountingEntry.Logs);

            sucessor?.ProcessRequest(request);
        }
    }
}
