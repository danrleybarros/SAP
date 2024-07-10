using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Gcsb.Connect.SAP.Domain.Deferral;

namespace Gcsb.Connect.SAP.Application.Repositories.Deferral
{
    public interface IDeferralOfferReadOnlyRepository
    {
        DeferralOffer GetByOfferCode(string offerCode);
        List<DeferralOffer> GetAll();
        List<DeferralOffer> Get(Expression<Func<DeferralOffer, bool>> func);
    }
}
