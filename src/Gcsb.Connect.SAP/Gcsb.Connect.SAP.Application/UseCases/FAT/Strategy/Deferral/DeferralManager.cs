using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Features.Indexed;
using Gcsb.Connect.SAP.Application.Repositories.Deferral;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Entities;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.FinancialAccount;
using Gcsb.Connect.SAP.Domain.Deferral;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Deferral
{
    public class DeferralManager : IDeferralStrategy
    {
        private IIndex<DeferralType, IDeferralStrategy> strategy;
        private readonly IDeferralOfferWriteOnlyRepository deferralFinancialWriteOnlyRepository;
        public Func<DeferralOffer, bool> Condition { get; }
        private List<LaunchDeferralOffer> launchDeferralOffers = new List<LaunchDeferralOffer>();

        public DeferralManager(IIndex<DeferralType, IDeferralStrategy> strategy, IDeferralOfferWriteOnlyRepository deferralFinancialWriteOnlyRepository)
        {
            this.strategy = strategy;
            this.deferralFinancialWriteOnlyRepository = deferralFinancialWriteOnlyRepository;
        }

        public List<LaunchDeferralOffer> DeferOffer(List<DeferralOffer> offers, List<DeferralFinancialAccount> deferralFinancialAccounts, AccountDetailsByServiceDto accountingAccounts)
        {
            Enum.GetNames<DeferralType>().Where(type => type != DeferralType.NewDeferral.ToString()).ToList().ForEach(type =>
            {
                var deferralType = Enum.Parse<DeferralType>(type);
                var deferralStrategy = strategy[deferralType];

                var deferralOffers = offers.Where(deferralStrategy.Condition).ToList();
                if (deferralOffers.Any())
                {
                    var deferralLaunchers = deferralStrategy.DeferOffer(deferralOffers, deferralFinancialAccounts, accountingAccounts);
                    launchDeferralOffers.AddRange(deferralLaunchers);
                }
            });

            if (DeferralAccountingEntry.IsValidFinancialAccount)            
                deferralFinancialWriteOnlyRepository.UpdateRange(offers);                
            else
                launchDeferralOffers.Clear();

            return launchDeferralOffers;
        }

    }
}
