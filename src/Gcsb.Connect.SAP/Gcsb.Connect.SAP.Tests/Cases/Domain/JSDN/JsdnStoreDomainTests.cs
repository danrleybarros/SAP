using Gcsb.Connect.SAP.Tests.Builders.JSDN.Stores;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.JSDN
{
    public class JsdnStoreDomainTests
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateJsdnStoreDomain()
        {
            var model = JsdnStoreBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #region NullOrEmpty

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateStoreAcronym(string valor)
        {
            var model = JsdnStoreBuilder.New().WithStoreAcronym(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateStoreName(string valor)
        {
            var model = JsdnStoreBuilder.New().WithStoreName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateStoreCnpj(string valor)
        {
            var model = JsdnStoreBuilder.New().WithStoreCnpj(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateAcronym(string valor)
        {
            var model = JsdnStoreBuilder.New().WithAcronym(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateStoreDescription(string valor)
        {
            var model = JsdnStoreBuilder.New().WithStoreDescription(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateIDPEntityName(string valor)
        {
            var model = JsdnStoreBuilder.New().WithIDPEntityName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateStateRegistration(string valor)
        {
            var model = JsdnStoreBuilder.New().WithStateRegistration(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateCompanyURL(string valor)
        {
            var model = JsdnStoreBuilder.New().WithCompanyURL(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateStreet(string valor)
        {
            var model = JsdnStoreBuilder.New().WithStreet(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateNumber(string valor)
        {
            var model = JsdnStoreBuilder.New().WithNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateComplement(string valor)
        {
            var model = JsdnStoreBuilder.New().WithComplement(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateNeighborhood(string valor)
        {
            var model = JsdnStoreBuilder.New().WithNeighborhood(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateCity(string valor)
        {
            var model = JsdnStoreBuilder.New().WithCity(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateState(string valor)
        {
            var model = JsdnStoreBuilder.New().WithState(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateCountry(string valor)
        {
            var model = JsdnStoreBuilder.New().WithCountry(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateZipCode(string valor)
        {
            var model = JsdnStoreBuilder.New().WithZipCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateCCMMunicipalTaxpayerRegister(string valor)
        {
            var model = JsdnStoreBuilder.New().WithCCMMunicipalTaxpayerRegister(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateCompanyCode(string valor)
        {
            var model = JsdnStoreBuilder.New().WithCompanyCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateFilialCode(string valor)
        {
            var model = JsdnStoreBuilder.New().WithFilialCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateCityHallServiceCode(string valor)
        {
            var model = JsdnStoreBuilder.New().WithCityHallServiceCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateCityHallServiceDescription(string valor)
        {
            var model = JsdnStoreBuilder.New().WithCityHallServiceDescription(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateSpecialRegimeProcessNumber(string valor)
        {
            var model = JsdnStoreBuilder.New().WithSpecialRegimeProcessNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion
    }
}
