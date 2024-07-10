
namespace Gcsb.Connect.SAP.Application.Boundaries.Deferral
{
    public class ConfigDeferralOffer
    {
        public string OfferName { get; private set; }
        public string OfferCode { get; private set; }
        public string OfferDeferral { get; private set; }
        public int NumberOfInstallments { get; private set; }
        public string SubscriptionCycle { get; private set; }
        public string ContractPeriod { get; private set; }

        public ConfigDeferralOffer(string offerName, string offerCode, string offerDeferral, int numberOfInstallments, string subscriptionCycle, string contractPeriod)
        {
            OfferName = offerName;
            OfferCode = offerCode;
            OfferDeferral = offerDeferral;
            NumberOfInstallments = numberOfInstallments;
            SubscriptionCycle = subscriptionCycle;
            ContractPeriod = contractPeriod;
        }
    }
}

