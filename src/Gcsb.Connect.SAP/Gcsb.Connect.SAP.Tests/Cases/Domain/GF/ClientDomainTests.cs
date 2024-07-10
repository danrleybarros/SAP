using Gcsb.Connect.SAP.Tests.Builders.GF;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.GF
{
    public class ClientDomainTests
    {
        #region Create
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreate()
        {
            var model = ClientBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region With null values
        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithNullOrEmptyCustomerCode(string value)
        {
            var model = ClientBuilder.New().WithCustomerCode(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithNullOrEmptyStatefederativeunit(string value)
        {
            var model = ClientBuilder.New().WithStatefederativeunit(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithNullOrEmptyCustomerDocument(string value)
        {
            var model = ClientBuilder.New().WithCustomerDocument(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithNullOrEmptyCustomerType(string value)
        {
            var model = ClientBuilder.New().WithCustomerType(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateWithNullOrEmptyCustomerStateRegistration(string value)
        {
            var model = ClientBuilder.New().WithCustomerStateRegistration(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        
        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithNullOrEmptyCustomerName(string value)
        {
            var model = ClientBuilder.New().WithCustomerName(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithNullOrEmptyCustomerAddress(string value)
        {
            var model = ClientBuilder.New().WithCustomerAddress(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithNullOrEmptyCustomerAddressNumber(string value)
        {
            var model = ClientBuilder.New().WithCustomerAddressNumber(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateWithNullOrEmptyCustomerAddressCompletion(string value)
        {
            var model = ClientBuilder.New().WithCustomerAddressCompletion(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "none")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithNullOrEmptyCustomerNeighborhood(string value)
        {
            var model = ClientBuilder.New().WithCustomerNeighborhood(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "none")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithNullOrEmptyCustomerCity(string value)
        {
            var model = ClientBuilder.New().WithCustomerCity(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "none")]
        [InlineData("CL", "BRA", "Vivo Plataforma Digital")]
        public void VerifyConstrains(string category, string country, string plataform)
        {
            var model = ClientBuilder.New().Build();
            Assert.True(model.CategoryCode == category);
            Assert.True(model.CountryCode == country);
            Assert.True(model.Var05 == plataform);
        }
        #endregion
    }
}