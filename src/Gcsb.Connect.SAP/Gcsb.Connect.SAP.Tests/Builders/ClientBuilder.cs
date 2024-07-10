using GW_FSW_SAP.Domain;

namespace Gcsb.Connect.SAP.Tests.Builders
{
    public class ClientBuilder
    {
        public string ClientIdentifier;

        public string CompanyName;

        public string Street;

        public string Number;

        public string Complement;

        public string Neighborhood;

        public string City;

        public string ZipCode;

        public string StateProvince;

        public string Country;

        public string CustomerPhoneNumber;

        public string DocType;

        public string UnformattedCPForCNPJ;

        public string StateRegistration;

        public string OptionalCityRegistration;

        public string CustomerEmailAddress;

        public string IndividualInvoice;

        public static ClientBuilder New()
        {
            return new ClientBuilder
            {
                ClientIdentifier = "D1",
                CompanyName = "Fake Company",
                Street = "Test street",
                Number = "43",
                Complement = "02",
                Neighborhood = "Center",
                City = "Sants",
                ZipCode = "7773-333",
                StateProvince = "SP",
                Country = "BR",
                CustomerPhoneNumber = "1144433333",
                DocType = "CPF",
                UnformattedCPForCNPJ = "77870851000110",
                StateRegistration = "ISENTO",
                OptionalCityRegistration = "",
                CustomerEmailAddress = "fake@email.com",
                IndividualInvoice = "6"
            };
        }

        public ClientBuilder WithCompanyName(string companyName)
        {
            CompanyName = companyName;
            return this;
        }

        public ClientBuilder WithStreet(string street)
        {
            Street = street;
            return this;
        }

        public ClientBuilder WithNumber(string number)
        {
            Number = number;
            return this;
        }

        public ClientBuilder WithComplement(string complement)
        {
            Complement = complement;
            return this;
        }

        public ClientBuilder WithNeighborhood(string neighborhood)
        {
            Neighborhood = neighborhood;
            return this;
        }

        public ClientBuilder WithCity(string city)
        {
            City = city;
            return this;
        }

        public ClientBuilder WithZipCode(string zipCode)
        {
            ZipCode = zipCode;
            return this;
        }

        public ClientBuilder WithStateProvince(string stateProvince)
        {
            StateProvince = stateProvince;
            return this;
        }

        public ClientBuilder WithPhoneNumber(string customerPhoneNumber)
        {
            CustomerPhoneNumber = customerPhoneNumber;
            return this;
        }

        public ClientBuilder WithCPForCNPJ(string unformattedCPForCNPJ)
        {
            UnformattedCPForCNPJ = unformattedCPForCNPJ;
            return this;
        }

        public ClientBuilder WithStateRegistration(string stateRegistration)
        {
            StateRegistration = stateRegistration;
            return this;
        }

        public ClientBuilder WithCityRegistration(string optionalCityRegistration)
        {
            OptionalCityRegistration = optionalCityRegistration;
            return this;
        }

        public ClientBuilder WithEmail(string email)
        {
            CustomerEmailAddress = email;
            return this;
        }

        public ClientBuilder WithIndividualInvoice(string invoice)
        {
            IndividualInvoice = invoice;
            return this;
        }

        public Client Build()
        {
            return new Client(CompanyName, Street, Number, Complement, Neighborhood, City, ZipCode, StateProvince, CustomerPhoneNumber, UnformattedCPForCNPJ,
                StateRegistration, OptionalCityRegistration, CustomerEmailAddress, IndividualInvoice);
        }
    }
}
