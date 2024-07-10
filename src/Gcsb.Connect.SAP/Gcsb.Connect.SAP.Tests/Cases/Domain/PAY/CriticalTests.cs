using Gcsb.Connect.SAP.Tests.Builders.PAY;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.PAY
{
    public class CriticalTests
    {
        #region Create Domain
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreate()
        {
            var model = CriticalBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region REQUIREDS
        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateBankCode(string value)
        {
            var model = CriticalBuilder.New().WithBankCode(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void NullOrEmptyShouldCreateIdFile()
        {
            var model = CriticalBuilder.New().WithIdFile(default(Guid)).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion
    }
}
