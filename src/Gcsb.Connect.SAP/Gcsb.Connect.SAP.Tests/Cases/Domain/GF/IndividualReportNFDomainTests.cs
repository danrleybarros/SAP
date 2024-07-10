using Gcsb.Connect.SAP.Tests.Builders.GF;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.GF
{
    public class IndividualReportNFDomainTests
    {
        #region Create Domain

        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreate()
        {
            var model = new IndividualReportNFBuilder().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #endregion

        #region Requireds

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullCCM(string value)
        {
            var model = new IndividualReportNFBuilder().WithCCM(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullReference(string value)
        {
            var model = new IndividualReportNFBuilder().WithReference(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullCityHallServiceCode(string value)
        {
            var model = new IndividualReportNFBuilder().WithCityHallServiceCode(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullCPF(string value)
        {
            var model = new IndividualReportNFBuilder().WithCPF(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullCompanyName(string value)
        {
            var model = new IndividualReportNFBuilder().WithCompanyName(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullStateRegistration(string value)
        {
            var model = new IndividualReportNFBuilder().WithStateRegistration(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullMailingStreet(string value)
        {
            var model = new IndividualReportNFBuilder().WithMailingStreet(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullMailingNumber(string value)
        {
            var model = new IndividualReportNFBuilder().WithMailingNumber(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullCounty(string value)
        {
            var model = new IndividualReportNFBuilder().WithCounty(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullUF(string value)
        {
            var model = new IndividualReportNFBuilder().WithUF(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullZipCode(string value)
        {
            var model = new IndividualReportNFBuilder().WithZipCode(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullCustomerEmail(string value)
        {
            var model = new IndividualReportNFBuilder().WithCustomerEmail(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullBillingAddress(string value)
        {
            var model = new IndividualReportNFBuilder().WithBillingAddress(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullBillingNumberAddress(string value)
        {
            var model = new IndividualReportNFBuilder().WithBillingNumberAddress(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullCPF_CNPJ_Tomador(string value)
        {
            var model = new IndividualReportNFBuilder().WithCPF(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion

        #region Tests With Constants

        [Theory]
        [Trait("Action", "None")]
        [InlineData("1", 0, "001", "UM", "1.03", "Processamento,armaz. ou hosped. de dados, textos, imagens, videos, paginas eletronicas, apps e sist. de info., entre outros formatos e congeneres", 0, 0, 0)]
        public void ShouldMatchConstantsIndividualReportNFDomain(string locationServiceProvision, int retainedIRRFValue, string expiryCode, string unity, string serviceCode, string description,
            int retainedISSValue, int retainedPISValue, int retainedCofinsValue)
        {
            var model = new IndividualReportNFBuilder().Build();

            Assert.Equal(model.LocationServiceProvision, locationServiceProvision);
            Assert.Equal(model.RetainedIRRFValue, retainedIRRFValue);
            Assert.Equal(model.ExpiryCode, expiryCode);
            Assert.Equal(model.Unity, unity);
            Assert.Equal(model.ServiceCode, serviceCode);
            Assert.Equal(model.Description, description);
            Assert.Equal(model.RetainedISSValue, retainedISSValue);
            Assert.Equal(model.RetainedPISValue, retainedPISValue);
            Assert.Equal(model.RetainedCofinsValue, retainedCofinsValue);
        }

        #endregion
    }
}