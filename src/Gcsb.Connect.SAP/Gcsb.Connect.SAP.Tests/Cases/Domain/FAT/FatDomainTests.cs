using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.FAT
{
    public class FatDomainTests
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShoudCreateFatDomain()
        {
            var model = Builders.Build.FAT.Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
    }
}
