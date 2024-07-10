using System;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.Boundaries.Deferral;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Tests.Builders.Deferral;
using Moq;

namespace Gcsb.Connect.SAP.Tests.Mock
{
    public class GetDatamartResultMock
    {
        public Mock<IDatamartService> Execute()
        {
            var getDatamartResultMock = new Mock<IDatamartService>();

            getDatamartResultMock
                .Setup(s => s.GetAllDeferralOffers())
                .Returns(new List<ConfigDeferralOffer>
                {
                      DeferralOfferPkgBuilder.New().Build(),
                      DeferralOfferPkgBuilder.New().WithOfferCode("office365be").Build(),
                      DeferralOfferPkgBuilder.New().WithOfferCode("Microsoft365F1_offer").WithNumberOfInstallments(24).Build(),
                      DeferralOfferPkgBuilder.New().WithOfferCode("ExchangeOnlinePlan2_offer").WithNumberOfInstallments(24).WithSubscriptionCycle("Teste").Build(),
                });

            getDatamartResultMock
             .Setup(s => s.GetOrderByCycle(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
             .Returns(new List<Application.Boundaries.Deferral.Order>
             {
                  OrderPkgBuilder.New().Build()
             });

            return getDatamartResultMock;
        }
    }
}


