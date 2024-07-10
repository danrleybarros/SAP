using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Gcsb.Connect.Pkg.Datamart.Domain;
using Gcsb.Connect.SAP.Application.Repositories.StatusActivationServices;
using Gcsb.Connect.SAP.Domain.Deferral.StatusActivationService;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class StatusActivationServiceRepository : IStatusActivationServiceReadOnlyRepository, IStatusActivationServiceWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public StatusActivationServiceRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(IEnumerable<StatusActivationService> statusActivationServices)
        {
            var model = mapper.Map<List<Entities.StatusActivationService>>(statusActivationServices.ToList());
            var retorno = 0;

            using (var context = new Context())
            {
                context.StatusActivationService.AddRange(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Add(StatusActivationService statusActivationServices)
        {
            var model = mapper.Map<Entities.StatusActivationService>(statusActivationServices);
            var retorno = 0;

            using (var context = new Context())
            {
                context.StatusActivationService.Add(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public List<StatusActivationService> Get(Expression<Func<StatusActivationService, bool>> func)
        {
            using var context = new Context();

            var predicate = mapper.Map<Expression<Func<Entities.StatusActivationService,bool>>>(func);
            var offers = context.StatusActivationService.Where(predicate).ToList();
            var map = mapper.Map<List<StatusActivationService>>(offers);

            return map;
        }

        public StatusActivationService GetByOfferCode(string offerCode)
        {
            using var context = new Context();
            var map = mapper.Map<StatusActivationService>(context.StatusActivationService.Where(c => c.OfferCode.Equals(offerCode)).FirstOrDefault());
            return map;
        }

        public List<StatusActivationService> GetOffersByCode(params string[] offerCodes)
        {
            using var context = new Context();

            var offers = context.StatusActivationService.Where(c => offerCodes.Contains(c.OfferCode)).ToList();
            var map = mapper.Map<List<StatusActivationService>>(offers);

            return map;
        }
    }
}
