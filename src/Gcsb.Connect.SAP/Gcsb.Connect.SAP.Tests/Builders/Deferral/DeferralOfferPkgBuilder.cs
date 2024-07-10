using System;
using Gcsb.Connect.Pkg.Datamart.Domain.Deferral;
using Gcsb.Connect.SAP.Application.Boundaries.Deferral;

namespace Gcsb.Connect.SAP.Tests.Builders.Deferral
{
    public class DeferralOfferPkgBuilder
    {
        public string OfferName;
        public string OfferCode;
        public string OfferDeferral;
        public int NumberOfInstallments;
        public string SubscriptionCycle;
        public string ContractPeriod;
        
        public static DeferralOfferPkgBuilder New()
        {
            return new DeferralOfferPkgBuilder
            {
                OfferName = "Office 365",
                OfferCode = "office356_offer",
                OfferDeferral = "Teste123",
                NumberOfInstallments = 12,
                SubscriptionCycle = "Cobrança única",
                ContractPeriod = "12 Mês(es)"
            };
        }

        public DeferralOfferPkgBuilder WithOfferName(string offerName)
        {
            OfferName = offerName;
            return this;
        }

        public DeferralOfferPkgBuilder WithOfferCode(string offerCode)
        {
            OfferCode = offerCode;
            return this;
        }

        public DeferralOfferPkgBuilder WithOfferDeferral(string offerDeferral)
        {
            OfferDeferral = offerDeferral;
            return this;
        }

        public DeferralOfferPkgBuilder WithNumberOfInstallments(int numberOfInstallments)
        {
            NumberOfInstallments = numberOfInstallments;
            return this;
        }

        public DeferralOfferPkgBuilder WithSubscriptionCycle(string subscriptionCycle)
        {
            SubscriptionCycle = subscriptionCycle;
            return this;
        }

        public DeferralOfferPkgBuilder WithContractPeriod(string contractPeriod)
        {
            ContractPeriod = contractPeriod;
            return this;
        }

        public ConfigDeferralOffer Build()
        {
            return new ConfigDeferralOffer(OfferName, OfferCode, OfferDeferral, NumberOfInstallments, SubscriptionCycle, ContractPeriod);
        }
    }
}

