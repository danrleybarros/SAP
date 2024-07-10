using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class InterestAndFineFinancialAccountRepository : IInterestAndFineFinancialAccountReadOnlyRepository, IInterestAndFineFinancialAccountWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public InterestAndFineFinancialAccountRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Guid Add(InterestAndFineFinancialAccount interestAndFineFinancialAccount)
        {
            var model = mapper.Map<Entities.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount>(interestAndFineFinancialAccount);

            using (var context = new Context())
            {
                context.InterestAndFineFinancialAccount.Add(model);
                context.SaveChanges();
            }

            return interestAndFineFinancialAccount.Id;
        }

        public InterestAndFineFinancialAccount GetByStore(StoreType store)
        {
            using (var context = new Context())
            {
                var interestAndFineFinancialAccount = context.InterestAndFineFinancialAccount.FirstOrDefault(a => a.Store.Equals(store));

                return mapper.Map<InterestAndFineFinancialAccount>(interestAndFineFinancialAccount);
            }
        }

        public List<InterestAndFineFinancialAccount> GetAll()
        {
            using (var context = new Context())
            {
                var interestAndFineFinancialAccount = context.InterestAndFineFinancialAccount.ToList();

                return mapper.Map<List<InterestAndFineFinancialAccount>>(interestAndFineFinancialAccount);
            }
        }

        public InterestAndFineFinancialAccount GetById(Guid id)
        {
            using (var context = new Context())
            {
                var interestAndFineFinancialAccount = context.InterestAndFineFinancialAccount.Find(id);

                return mapper.Map<InterestAndFineFinancialAccount>(interestAndFineFinancialAccount);
            }
        }

        public int Remove(InterestAndFineFinancialAccount interestAndFineFinancialAccount)
        {
            var model = mapper.Map<Entities.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount>(interestAndFineFinancialAccount);
            var retorno = 0;

            using (var context = new Context())
            {
                context.InterestAndFineFinancialAccount.Remove(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public void RemoveAll(List<InterestAndFineFinancialAccount> interestAndFineFinancialAccount)
        {
            var models = mapper.Map<List<Entities.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount>>(interestAndFineFinancialAccount);

            using (var context = new Context())
            {
                context.RemoveRange(models);
                context.SaveChanges();
            }
        }

        public int Update(InterestAndFineFinancialAccount interestAndFineFinancialAccount)
        {
            var model = mapper.Map<Entities.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount>(interestAndFineFinancialAccount);

            using (var context = new Context())
            {
                context.InterestAndFineFinancialAccount.Update(model);
                return context.SaveChanges();
            }
        }
    }
}
