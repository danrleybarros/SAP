using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.Deferral;

namespace Gcsb.Connect.SAP.Application.Repositories.Deferral
{
    public interface IDeferralOfferWriteOnlyRepository
    {
        int Add(IEnumerable<DeferralOffer> deferralOffer);
        int Add(DeferralOffer deferralOffer);
        int UpdateRange(IEnumerable<DeferralOffer> deferralOffer);
    }
}
