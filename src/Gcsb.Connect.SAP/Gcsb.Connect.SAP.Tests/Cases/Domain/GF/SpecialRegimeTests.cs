using Gcsb.Connect.SAP.Tests.Builders.GF;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.GF
{
    public class SpecialRegimeTests
    {
        #region Create Test 

        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreate()
        {
            var model = SpecialRegimeBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #endregion

        #region Null Or Empty Tests
        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyInvoiceNumberShouldNotCreate(string valor)
        {
            var model = SpecialRegimeBuilder.New().WithInvoiceNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyServiceCodeShouldNotCreate(string valor)
        {
            var model = SpecialRegimeBuilder.New().WithServiceCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyServiceNameShouldNotCreate(string valor)
        {
            var model = SpecialRegimeBuilder.New().WithServiceName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyCompanyNameShouldNotCreate(string valor)
        {
            var model = SpecialRegimeBuilder.New().WithCompanyName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyInvoiceNumberRefDocOrigemShouldNotCreate(string valor)
        {
            var model = SpecialRegimeBuilder.New().WithInvoiceNumberRefDocOrigem(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyCityBillingShouldNotCreate(string valor)
        {
            var model = SpecialRegimeBuilder.New().WithCityBilling(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyZipCodeBillingShouldNotCreate(string valor)
        {
            var model = SpecialRegimeBuilder.New().WithZipCodeBilling(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyStreetBillingShouldNotCreate(string valor)
        {
            var model = SpecialRegimeBuilder.New().WithStreetBilling(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyCpfShouldNotCreate(string valor)
        {
            var model = SpecialRegimeBuilder.New().WithCpf(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyCnpjMarketPlaceShouldNotCreate(string valor)
        {
            var model = SpecialRegimeBuilder.New().WithCnpjMarketPlace(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyCompanyNameMarketPlaceShouldNotCreate(string valor)
        {
            var model = SpecialRegimeBuilder.New().WithCompanyNameMarketPlace(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyCustomerCodeShouldNotCreate(string valor)
        {
            var model = SpecialRegimeBuilder.New().WithCustomerCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion

        #region MaxLength Tests

        [Theory]
        [InlineData("ABCDEABCDEABCDEABCDEABCDEABCDEABCDEZ")]
        public void MaxLength35CityBilling(string valor)
        {
            var model = SpecialRegimeBuilder.New().WithCityBilling(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("ABCDEABCDEABCDEABCDEABCDEABCDEABCDEZABCDEABCDEABCDEABCDEABCDEABC")]
        public void MaxLength60StreetBilling(string valor)
        {
            var model = SpecialRegimeBuilder.New().WithStreetBilling(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion

        #region Invalid Format Tests

        [Theory]
        [Trait("Action", "None")]
        [InlineData("77870851050110")]
        [InlineData("87567405267")]
        public void InvalidArgumentCnpj(string cnpj)
        {
            var model = SpecialRegimeBuilder.New().WithCnpj(cnpj).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("77870851050110")]
        [InlineData("87567405267")]
        public void InvalidArgumentCnpjMarketPlace(string cnpj)
        {
            var model = SpecialRegimeBuilder.New().WithCnpjMarketPlace(cnpj).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("77870851050110")]
        [InlineData("87567405267")]
        public void InvalidArgumentCpf(string cnpj)
        {
            var model = SpecialRegimeBuilder.New().WithCpf(cnpj).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion

        #region Constants Tests
        [Theory]
        [InlineData("", "", "", "", "", "9141")]
        public void ShouldConstantsMatch(string nf, string serie, string cfop, string rg, string zone, string affiliateCode)
        {
            var model = SpecialRegimeBuilder.New().Build();
            Assert.True(model.NF == nf);
            Assert.True(model.Serie == serie);
            Assert.True(model.Cfop == cfop);
            Assert.True(model.RG == rg);
            Assert.True(model.Zone == zone);
            Assert.True(model.AffiliateCode == affiliateCode);
        }

        [Theory]
        [InlineData("{0:dd/MM/yyyy}", "{0,0:0.00}", "{0:MMyyyy}", "{0:00000000}", "{0:00000000000}", "{0:00000000000000}")]
        public void ShouldFormatConstantsMatch(string formatDate, string formatValue, string monthFormat, string zipCodeFormat, string cpfFormat, string cnpjFormat)
        {
            var model = SpecialRegimeBuilder.New().Build();
            var arrConst = model.GetConstantsValues();
            Assert.True(arrConst[0] == formatDate);
            Assert.True(arrConst[1] == formatValue);
            Assert.True(arrConst[2] == monthFormat);
            Assert.True(arrConst[3] == zipCodeFormat);
            Assert.True(arrConst[4] == cpfFormat);
            Assert.True(arrConst[5] == cnpjFormat);
        }
        #endregion
    }
}
