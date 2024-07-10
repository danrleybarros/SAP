using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.SearchExpressions;
using Gcsb.Connect.SAP.Domain.Deferral.StatusActivationService;

namespace Gcsb.Connect.SAP.Application.Repositories.StatusActivationServices
{
    public interface IStatusActivationServiceReadOnlyRepository
    {
        StatusActivationService GetByOfferCode(string offerCode);

        List<StatusActivationService> Get(Expression<Func<StatusActivationService, bool>> func);

        List<StatusActivationService> GetOffersByCode(params string[] offerCodes);
    }
}
