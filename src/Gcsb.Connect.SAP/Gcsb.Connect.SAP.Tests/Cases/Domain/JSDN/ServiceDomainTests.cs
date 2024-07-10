using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.JSDN
{
    public class ServiceDomainTests
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateBillFeedDocDomain()
        {
            var model = Builders.Build.Service.Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithServiceCode(string valor)
        {
            var model = Builders.Build.Service.WithCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithServiceName(string valor)
        {
            var model = Builders.Build.Service.WithName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

    }
}
