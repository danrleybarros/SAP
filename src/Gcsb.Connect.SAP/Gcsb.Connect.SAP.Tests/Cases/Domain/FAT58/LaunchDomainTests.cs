using Gcsb.Connect.SAP.Tests.Builders.FAT.FAT58;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.FAT58
{
    public class LaunchDomainTests
    {
        #region Create
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateLaunch()
        {
            var model = LaunchBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region Create with null or empty information
        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateLaunchWithComplementNullOrEmpty(string value)
        {
            var model = LaunchBuilder.New().WithComplement(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateLaunchWithISSCodeNullOrEmpty(string value)
        {
            var model = LaunchBuilder.New().WithISSCode(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateLaunchWithISSCodeNull(string value)
        {
            var model = LaunchBuilder.New().WithISSValue(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateLaunchWithOperatorComplementNullOrEmpty(string value)
        {
            var model = LaunchBuilder.New().WithProduct(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        
        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateLaunchWithInternalOrderNullOrEmpty(string value)
        {
            var model = LaunchBuilder.New().WithInternalOrder(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateLaunchWithCostObjectNullOrEmpty(string value)
        {
            var model = LaunchBuilder.New().WithCostObject(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateLaunchWithTaxCostCenterNullOrEmpty(string value)
        {
            var model = LaunchBuilder.New().WithTaxCostCenter(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateLaunchWithNetValueNullOrEmpty(string value)
        {
            var model = LaunchBuilder.New().WithNetValue(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateLaunchWithAccountingEntryNullOrEmpty(string value)
        {
            var model = LaunchBuilder.New().WithAccountingEntry(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateLaunchWithAccountingAccountNullOrEmpty(string value)
        {
            var model = LaunchBuilder.New().WithAccountingAccount(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region Not create with invalid information
        [Theory]
        [Trait("Action", "None")]
        [InlineData(0)]
        public void ShouldNotCreateWithInvalidNumberLine(int value)
        {
            var model = LaunchBuilder.New().WithNumberLine(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("AAAAAAAAAAAAAAAB")]
        public void ShouldNotCreateWithInvalidFinancialAccount(string value)
        {
            var model = LaunchBuilder.New().WithFinancialAccount(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("AAAB")]
        public void ShouldNotCreateWithInvalidComplement(string value)
        {
            var model = LaunchBuilder.New().WithComplement(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(0.001)]
        [InlineData(0.1)]
        public void ShouldNotCreateWithInvalidLaunchValue(decimal value)
        {
            var model = LaunchBuilder.New().WithLaunchValue(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("AAAAAAAAAAAAAAAB")]
        public void ShouldNotCreateWithInvalidISSCode(string value)
        {
            var model = LaunchBuilder.New().WithISSCode(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("000")]
        [InlineData("0")]
        public void ShouldNotCreateWithInvalidISSValue(string value)
        {
            var model = LaunchBuilder.New().WithISSValue(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("AAAAAAAAAAAAB")]
        public void ShouldNotCreateWithInvalidInternalOrder(string value)
        {
            var model = LaunchBuilder.New().WithInternalOrder(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("AAAAAAAAAAAAB")]
        public void ShouldNotCreateWithInvalidCostObject(string value)
        {
            var model = LaunchBuilder.New().WithCostObject(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("AAAAAAAAAAAAB")]
        public void ShouldNotCreateWithInvalidTaxCostCenter(string value)
        {
            var model = LaunchBuilder.New().WithTaxCostCenter(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("0,001")]
        [InlineData("00")]
        public void ShouldNotCreateWithInvalidNetValue(string value)
        {
            var model = LaunchBuilder.New().WithNetValue(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Z")]
        [InlineData("TR")]
        public void ShouldNotCreateWithInvalidAccountingEntry(string value)
        {
            var model = LaunchBuilder.New().WithAccountingEntry(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("AAAAAAAAAAAAB")]
        [InlineData("TERYRT       ")]
        public void ShouldNotCreateWithInvalidAccountingAccount(string value)
        {
            var model = LaunchBuilder.New().WithAccountingAccount(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion

        #region Tests constants
        [Theory]
        [Trait("Action", "None")]
        [InlineData("D1", "ECM", "GW", "9141", "29TR018233")]
        public void ShouldMatchConstantsLaunchDomain(string linetype, string type, string operatorcomplement, string businesslocation, string costcenter)
        {
            var model = LaunchBuilder.New().Build();
            Assert.True(model.LineType == linetype);
            Assert.True(model.Type == type);
            Assert.True(model.OperatorComplement == operatorcomplement);
            Assert.True(model.BusinessLocation == businesslocation);
            Assert.True(model.CostCenter == costcenter);
        }
        #endregion
    }
}
