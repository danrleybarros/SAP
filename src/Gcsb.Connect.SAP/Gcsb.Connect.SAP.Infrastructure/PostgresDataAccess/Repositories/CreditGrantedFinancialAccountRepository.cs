using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories.Config.CreditGrantedFinancialAccount;
using Gcsb.Connect.SAP.Domain.Config.CreditGrantedFinancialAccount;
using Gcsb.Connect.SAP.Domain.Config.Enum;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class CreditGrantedFinancialAccountRepository : ICreditGrantedFinancialAccountReadOnlyRepository, ICreditGrantedFinancialAccountWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public CreditGrantedFinancialAccountRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(CreditGrantedFinancialAccount creditGrantedFinancialAccount)
        {
            using var context = new Context();
            context.Add(mapper.Map<Entities.CreditGrantedFinancialAccount>(creditGrantedFinancialAccount));
            var ret = context.SaveChanges();
            return ret;
        }

        public List<CreditGrantedFinancialAccount> GetAll()
        {
            using var context = new Context();
            var accounts = mapper.Map<List<CreditGrantedFinancialAccount>>(context.CreditGrantedFinancialAccount.ToList());
            return accounts;
        }

        public CreditGrantedFinancialAccount GetByStore(StoreType storeAcronym)
        {
            using var context = new Context();
            var account = context.CreditGrantedFinancialAccount.Where(c => c.StoreAcronym.Equals(storeAcronym)).FirstOrDefault();
            return mapper.Map<CreditGrantedFinancialAccount>(account);
        }

        public int Update(CreditGrantedFinancialAccount creditGrantedFinancialAccount)
        {
            using var context = new Context();
            context.Update(mapper.Map<Entities.CreditGrantedFinancialAccount>(creditGrantedFinancialAccount));
            var ret = context.SaveChanges();
            return ret;
        }
    }
}
