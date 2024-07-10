using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.Pay;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.ApiClientsTests
{
   public class PayServiceTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IServicePay servicePay;

        public PayServiceTests(Fixture.ApplicationFixture fixture)
        {
            this.servicePay = fixture.Container.Resolve<IServicePay>();
        }

        [Fact]
        public void ShouldReturnListCritical()
        {
            var criticals = servicePay.Execute(DateTime.UtcNow, DateTime.UtcNow);

            Assert.True(criticals.Count > 0);
        }
    }
}
