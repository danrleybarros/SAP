using System;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.Deferral;

namespace Gcsb.Connect.SAP.Domain.FAT
{
    public class FATUseCaseParameters
    {
        public Guid BillfeedId { get; set; }
        public DateTime CycleDate { get; set; }
        public List<DeferralOffer> DeferralOffers { get; set; }

        public FATUseCaseParameters(Guid billfeedId, DateTime cycleDate, List<DeferralOffer> deferralOffers)
        {
            BillfeedId = billfeedId;
            CycleDate = cycleDate;
            DeferralOffers = deferralOffers;
        }
    }
}
