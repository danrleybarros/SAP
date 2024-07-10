using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class ManagementFinancialAccountRepository : IManagementFinancialAccountReadOnlyRepository, IManagementFinancialAccountWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public ManagementFinancialAccountRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Guid Add(ManagementFinancialAccount managementFinancialAccount)
        {
            var model = mapper.Map<Entities.ManagementFinancialAccount.ManagementFinancialAccount>(managementFinancialAccount);

            using (var context = new Context())
            {
                context.ManagementFinancialAccount.Add(model);
                context.SaveChanges();
            }

            return managementFinancialAccount.Id;
        }

        public ManagementFinancialAccount Get()
        {
            using (var context = new Context())
            {
                var managementFinancialAccount = context.ManagementFinancialAccount
                    .FirstOrDefault();

                return mapper.Map<ManagementFinancialAccount>(managementFinancialAccount);
            }
        }

        public ManagementFinancialAccount GetById(Guid id)
        {
            using (var context = new Context())
            {
                var managementFinancialAccount = context.ManagementFinancialAccount.Find(id);

                return mapper.Map<ManagementFinancialAccount>(managementFinancialAccount);
            }
        }

        public int Remove(ManagementFinancialAccount managementFinancialAccount)
        {
            var model = mapper.Map<Entities.ManagementFinancialAccount.ManagementFinancialAccount>(managementFinancialAccount);
            var retorno = 0;

            using (var context = new Context())
            {
                context.ManagementFinancialAccount.Remove(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Update(ManagementFinancialAccount managementFinancialAccount)
        {
            var model = mapper.Map<Entities.ManagementFinancialAccount.ManagementFinancialAccount>(managementFinancialAccount);
            using (Context context = new Context())
            {
                context.ManagementFinancialAccount.Update(model);
                return context.SaveChanges();
            }
        }

        public void RemoveAll(List<ManagementFinancialAccount> managementFinancialAccounts)
        {
            var model = mapper.Map<List<Entities.ManagementFinancialAccount.ManagementFinancialAccount>>(managementFinancialAccounts);

            using (var context = new Context())
            {
                context.RemoveRange(model);
                context.SaveChanges();
            }
        }

        public List<ManagementFinancialAccount> GetAll()
        {
            using (var context = new Context())
            {
                var managementFinancialAccount = context.ManagementFinancialAccount
                    .ToList();

                return mapper.Map<List<ManagementFinancialAccount>>(managementFinancialAccount);
            }
        }

        public ManagementFinancialAccount GetbyFilter(Expression<Func<ManagementFinancialAccount, bool>> func)
        {
            using (var context = new Context())
            {
                var expr = mapper.Map<Expression<Func<Entities.ManagementFinancialAccount.ManagementFinancialAccount, bool>>>(func);
                var managementFinancialAccount = context.ManagementFinancialAccount.Where(expr).FirstOrDefault();
                    
                return mapper.Map<ManagementFinancialAccount>(managementFinancialAccount);
            }
        }
    }
}
