using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories.Deferral;
using Gcsb.Connect.SAP.Domain.Deferral;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class DeferralFinancialRepository : IDeferralOfferReadOnlyRepository, IDeferralOfferWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public DeferralFinancialRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(IEnumerable<DeferralOffer> deferralOffer)
        {
            var model = mapper.Map<List<Entities.Deferral.DeferralOffer>>(deferralOffer.ToList());
            var retorno = 0;

            using (var context = new Context())
            {
                context.DeferralFinancial.AddRange(model);
                retorno = context.SaveChanges();
            }
            return retorno;
        }

        public int Add(DeferralOffer deferralOffer)
        {
            var model = mapper.Map<Entities.Deferral.DeferralOffer>(deferralOffer);
            var retorno = 0;

            using (var context = new Context())
            {
                context.DeferralFinancial.Add(model);
                retorno = context.SaveChanges();
            }
            return retorno;
        }

        public DeferralOffer GetByOfferCode(string offerCode)
        {
            using var context = new Context();
            var map = mapper.Map<DeferralOffer>(context.DeferralFinancial.Where(c => c.OfferCode.Equals(offerCode)).FirstOrDefault());
            return map;
        }

        public int UpdateRange(IEnumerable<DeferralOffer> deferralOffer)
        {
            var model = mapper.Map<List<Entities.Deferral.DeferralOffer>>(deferralOffer.ToList());
            using (Context context = new Context())
            {
                context.DeferralFinancial.UpdateRange(model);
                return context.SaveChanges();
            }
        }

        public List<DeferralOffer> GetAll()
        {
            var list = new List<DeferralOffer>();
            using (var context = new Context())
            {
                list = mapper.Map<List<DeferralOffer>>(context.DeferralFinancial.ToList());
            }
            return list;
        }

        public List<DeferralOffer> Get(Expression<Func<DeferralOffer, bool>> func)
        {
            var deferralOffers = new List<DeferralOffer>();

            using (var context = new Context())
            {
                deferralOffers = mapper.Map<List<DeferralOffer>>(context.DeferralFinancial.Where(mapper.Map<Expression<Func<Entities.Deferral.DeferralOffer, bool>>>(func)).ToList());
            }
            return deferralOffers;
        }
    }
}
