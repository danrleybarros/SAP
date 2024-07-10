using Gcsb.Connect.SAP.Tests.Builders.ARR;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.ARR
{
    public class LaunchItemDomainTest
    {
        #region Create Tests

        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateIdentificationRegisterDomain()
        {
            var model = LaunchItemBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #endregion

        #region Tests With Constants

        [Theory]
        [Trait("Action", "None")]
        [InlineData("D1")]
        public void ShouldMatchConstantsLaunchItemDomain(string typeLine)
        {
            var model = LaunchItemBuilder.New().Build();

            Assert.Equal(model.TypeLine, typeLine);
        }
        #endregion

        #region Tests With Null And Empty 

        [Theory]
        [Trait("Action", "None")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithLineNumber(int? valor)
        {
            var model = LaunchItemBuilder.New().WithLineNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        } 
        

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithType(string valor)
        {
            var model = LaunchItemBuilder.New().WithType(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        
        #endregion

        #region Tests With MaxLenght
       
        [Theory]
        [Trait("Action", "None")]
        [InlineData(00000000000000000)]
        public void MaxLenght16LaunchValue(decimal valor)
        {
            var model = LaunchItemBuilder.New().WithLaunchValue(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem ipsum dolor")]
        public void MaxLenght10Type(string valor)
        {
            var model = LaunchItemBuilder.New().WithType(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem ipsum dolor")]
        public void MaxLenght2Complement(string valor)
        {
            var model = LaunchItemBuilder.New().WithComplement(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem ipsum dolor")]
        public void MaxLenght10SecondComplement(string valor)
        {
            var model = LaunchItemBuilder.New().WithSecondComplement(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("C  ")]
        public void MaxLenght2AccountingEntry(string valor)
        {
            var model = LaunchItemBuilder.New().WithAccountingEntry(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("0000000001B")]
        public void MaxLenght10AccountingAccount(string valor)
        {
            var model = LaunchItemBuilder.New().WithAccountingAccount(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion

        #region Tests With Invalid Formats

        [Theory]
        [Trait("Action", "None")]
        [InlineData(999999.9)]
        [InlineData(.00)]
        public void LaunchItemWrongTotalReleases(decimal value)
        {
            var model = LaunchItemBuilder.New().WithLaunchValue(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("A ")]
        public void InvalidAccountingEntry(string valor)
        {
            var model = LaunchItemBuilder.New().WithAccountingEntry(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("000000 001-")]
        public void InvalidAccountingAccount(string valor)
        {
            var model = LaunchItemBuilder.New().WithAccountingAccount(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion
    }
}
