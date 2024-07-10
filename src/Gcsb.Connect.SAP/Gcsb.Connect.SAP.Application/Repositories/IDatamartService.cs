using System;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.Boundaries.Deferral;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IDatamartService
    {
        List<ConfigDeferralOffer> GetAllDeferralOffers();
        List<Order> GetOrderByCycle(DateTime dateFrom , DateTime dateTo);
    }
}
