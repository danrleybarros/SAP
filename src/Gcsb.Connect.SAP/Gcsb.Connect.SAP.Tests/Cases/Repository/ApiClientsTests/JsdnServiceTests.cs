using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Tests.Builders.Util;
using Newtonsoft.Json;
using RestSharp;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.ApiClientsTests
{
    public class JsdnServiceTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private IJsdnService jsdnService;

        public JsdnServiceTests(Fixture.ApplicationFixture fixture)
        {
            this.jsdnService = fixture.Container.Resolve<SAP.Application.Repositories.IJsdnService>();
        }

        [Fact]
        [Trait("Action", "Integrate")]
        public async void JsdnServiceRepositoryTestShouldExecute()
        {         
            var services = await jsdnService.GetServices(string.Empty);
            Assert.NotNull(services);
            Assert.NotEmpty(services);
        }       

    }
}
