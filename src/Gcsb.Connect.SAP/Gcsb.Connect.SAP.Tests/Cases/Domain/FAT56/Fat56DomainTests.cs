using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.FAT56
{
    public class Fat56DomainTests
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShoudCreateFatDomain()
        {
            var model = Builders.Build.FAT56.Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
    }
}
