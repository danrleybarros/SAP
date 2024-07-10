using Gcsb.Connect.SAP.Tests.Builders;
using GW_FSW_SAP.Domain;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain
{
    public class ClientDomainTest
    {
        #region Create Tests
        
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateClientDomain()
        {            
            var model = ClientBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region Tests With Null And Empty 
        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithCompanyName(string valor)
        {            
            var model = ClientBuilder.New().WithCompanyName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithStreet(string valor)
        {
            var model = ClientBuilder.New().WithStreet(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithNumber(string valor)
        {
            var model = ClientBuilder.New().WithNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithComplement(string valor)
        {
            var model = ClientBuilder.New().WithComplement(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithNeighborhood(string valor)
        {
            var model = ClientBuilder.New().WithNeighborhood(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithCity(string valor)
        {
            var model = ClientBuilder.New().WithCity(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithZipCode(string valor)
        {
            var model = ClientBuilder.New().WithZipCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithStateProvince(string valor)
        {
            var model = ClientBuilder.New().WithStateProvince(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithCustomerPhoneNumber(string valor)
        {
            var model = ClientBuilder.New().WithPhoneNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithCPForCNPJNumber(string valor)
        {
            var model = ClientBuilder.New().WithCPForCNPJ(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("87567405067", "")]
        [InlineData("87567405067", null)]
        public void NullOrEmptyShouldNotCreateWithStateRegistration(string cpf, string valor)
        {
            var model = ClientBuilder.New().WithCPForCNPJ(cpf).WithStateRegistration(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithOptionalCityRegistration(string valor)
        {
            var model = ClientBuilder.New().WithCityRegistration(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithCustomerEmailAddress(string valor)
        {
            var model = ClientBuilder.New().WithEmail(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithIndividualInvoice(string valor)
        {
            var model = ClientBuilder.New().WithIndividualInvoice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }


        #endregion

        #region Tests With MaxLenght

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem Ipsum is simply dummy text of the printing and typeset.")]
        public void MaxLenght60CompanyName(string valor)
        {
            var model = ClientBuilder.New().WithCompanyName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem Ipsum is simply dummy text of the printing and typeset.")]
        public void MaxLenght60Street(string valor)
        {
            var model = ClientBuilder.New().WithStreet(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("12345678901")]
        public void MaxLenght10Number(string valor)
        {
            var model = ClientBuilder.New().WithNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("12345678901")]
        public void MaxLenght10Complement(string valor)
        {
            var model = ClientBuilder.New().WithComplement(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem Ipsum is simply dummy text of.")]
        public void MaxLenght35Neighborhood(string valor)
        {
            var model = ClientBuilder.New().WithNeighborhood(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem Ipsum is simply dummy text of.")]
        public void MaxLenght35City(string valor)
        {
            var model = ClientBuilder.New().WithCity(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("12345678901")]
        public void MaxLenght10ZipCode(string valor)
        {
            var model = ClientBuilder.New().WithZipCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        [Theory]
        [Trait("Action", "None")]
        [InlineData("SSSP")]
        public void MaxLenght3StateProvince(string valor)
        {
            var model = ClientBuilder.New().WithStateProvince(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("12345678901234567")]
        public void MaxLenght16CustomerPhoneNumber(string valor)
        {
            var model = ClientBuilder.New().WithNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("123456789012345678901")]
        public void MaxLenght20CustomerUnformattedCPForCNPJ(string valor)
        {
            var model = ClientBuilder.New().WithCPForCNPJ(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("1234567890123456789")]
        public void MaxLenght18StateRegistration(string valor)
        {
            var model = ClientBuilder.New().WithStateRegistration(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("1234567890123456789")]
        public void MaxLenght18OptionalCityRegistration(string valor)
        {
            var model = ClientBuilder.New().WithCityRegistration(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("LoremIpsumIsSimplyDumm@emailfake.com")]
        public void MaxLenght35CustomerEmailAddress(string valor)
        {
            var model = ClientBuilder.New().WithEmail(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("66")]
        public void MaxLenght1IndividualInvoice(string valor)
        {
            var model = ClientBuilder.New().WithIndividualInvoice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion

        #region Tests With Invalid Formats

        [Theory]
        [Trait("Action", "None")]
        [InlineData("5555-4322")]
        [InlineData("(11)55554322")]
        [InlineData("+55115544-3322")]
        [InlineData("+55(11)5544-3322")]
        [InlineData("1166554433A")]
        public void InvalidFormatPhoneNumber(string valor)
        {
            var model = ClientBuilder.New().WithPhoneNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("77870851000110", "")]
        [InlineData("87567405067", "ISENTO")]
        [InlineData("87567405067", "667516421142")]
        [InlineData("87567405067", "237.581.027.870")]
        public void InvalidArgumentClientDomainStateRegistration(string cpfOrCnpj, string ie)
        {            
            var model = ClientBuilder.New().WithCPForCNPJ(cpfOrCnpj).WithStateRegistration(ie).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion

        #region Tests With Constants
        [Theory]
        [Trait("Action", "None")]
        [InlineData("D1", "BR", "CPF")]
        public void ShouldMatchConstantsClientDomain(string clientIdentifier, string country, string pfOrPj)
        {
            var model = ClientBuilder.New().Build();
            Assert.True(model.ClientIdentifier == clientIdentifier);
            Assert.True(model.Country == country);
            Assert.True(model.DocType == pfOrPj);
        }
        #endregion        
    }
}
