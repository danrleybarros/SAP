using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.DynamicSearch;
using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.DynamicSearch.Entity.Pay;
using System.Linq;

namespace Gcsb.Connect.SAP.Infrastructure.ServicesClients.DynamicSearch
{
    public class DynamicService : IDynamicService
    {
        private readonly IDynamicRepository<Bank> bankRepository;

        public DynamicService(IDynamicRepository<Bank> bankRepository)
        {
            this.bankRepository = bankRepository;
            bankRepository.ConfigDatabase("Pay", "Bank");
        }

        public List<KeyValuePair<int, string>> GetParticipantCode(List<int> bankNumbers)
        {
            var banks = bankRepository.Get(w => bankNumbers.Contains(w.BankNumber));
                       
           return banks.Select(d => new KeyValuePair<int, string>(d.BankNumber, d.CadgCod)).ToList();
        }
    }
}
