using System;
using System.Collections.Generic;
using AutoMapper;
using Gcsb.Connect.Pkg.Datamart.Application.Contract;
using Gcsb.Connect.SAP.Application.Boundaries.Deferral;
using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Infrastructure.ServicesClients.Datamart
{
    public class DatamartService : IDatamartService
    {
        private readonly IGetDatamartResult getDatamartResult;
        private readonly IMapper mapper;

        public DatamartService(IGetDatamartResult getDatamartResult, IMapper mapper)
        {
            this.getDatamartResult = getDatamartResult;
            this.mapper = mapper;
        }

        public List<ConfigDeferralOffer> GetAllDeferralOffers()
        {
            var configDeferralOffer = getDatamartResult.GetAllDeferralOffers();

            return mapper.Map<List<ConfigDeferralOffer>>(configDeferralOffer);
        }

        public List<Order> GetOrderByCycle(DateTime dateFrom, DateTime dateTo)
        {
            var orders = getDatamartResult.GetOrdersByCycle(dateFrom, dateTo);

            return mapper.Map<List<Order>>(orders);
        }
    }
}
