using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Tests.Fixture;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Infrastructure.JSDN
{
    public class JsdnStoreServiceTest : IClassFixture<ApplicationFixture>
    {
        private readonly IJsdnStoreService jsdnStoreService;

        public JsdnStoreServiceTest(ApplicationFixture fixture)
        {
            jsdnStoreService = fixture.Container.Resolve<IJsdnStoreService>();
        }

        [Fact]
        public void ShouldGetStores()
        {
            var stores = jsdnStoreService.GetStores("cloudco");

            stores.Should().NotBeNull();
        }
    }
}
