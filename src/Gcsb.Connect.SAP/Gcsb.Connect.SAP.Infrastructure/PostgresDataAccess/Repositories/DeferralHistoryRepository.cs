using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories.Deferral;
using Gcsb.Connect.SAP.Domain.Deferral;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class DeferralHistoryRepository : IDeferralHistoryRepository
    {
        private readonly IMapper mapper;

        public DeferralHistoryRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(DeferralHistory deferralHistory)
        {
            var model = mapper.Map<Entities.Deferral.DeferralHistory>(deferralHistory);

            using (var context = new Context())
            {
                context.DeferralHistory.Add(model);
                return context.SaveChanges();
            }
        }

        public int Add(IEnumerable<DeferralHistory> deferralHistory)
        {
            var model = mapper.Map<List<Entities.Deferral.DeferralHistory>>(deferralHistory);

            using (var context = new Context())
            {
                context.DeferralHistory.AddRange(model);
                return context.SaveChanges();
            }
        }

        public List<DeferralHistory> Get(Expression<Func<DeferralHistory, bool>> expression)
        {
            using var context = new Context();
            var deferralHistories = context.DeferralHistory.Where(mapper.Map<Expression<Func<Entities.Deferral.DeferralHistory, bool>>>(expression)).ToList();

            return mapper.Map<List<DeferralHistory>>(deferralHistories);
        }

        public List<DeferralHistory> GetAll()
        {
            var list = new List<DeferralHistory>();
            using (var context = new Context())
            {
                list = mapper.Map<List<DeferralHistory>>(context.DeferralHistory.ToList());
            }
            return list;
        }

        public int Update(DeferralHistory deferralHistory)
        {
            var model = mapper.Map<Entities.Deferral.DeferralHistory>(deferralHistory);

            using (var context = new Context())
            {
                context.DeferralHistory.Update(model);
                return context.SaveChanges();
            }
        }
    }
}
