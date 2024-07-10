using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories.Pay.Critical;
using Gcsb.Connect.SAP.Domain.PAY;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class CriticalRepository : ICriticaReadRepository, ICriticaWriteRepository
    {
        private readonly IMapper mapper;
        public CriticalRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(List<Critical> criticas)
        {
            using (var context = new Context())
            {      
                context.AddRange(mapper.Map<List<Entities.Pay.Critical>>(criticas));

                return context.SaveChanges();
            }
        }

        public List<Critical> get(Guid idPayment)
        {
            using (var context = new Context())
            {
                var criticas = context.Critica
                    .Where(f => f.IdFile.Equals(idPayment))
                    .ToList();

                return mapper.Map<List<Critical>>(criticas).ToList();
            }
        }
    }
}
