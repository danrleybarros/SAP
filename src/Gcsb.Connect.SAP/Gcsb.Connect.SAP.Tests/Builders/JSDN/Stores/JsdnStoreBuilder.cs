using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Tests.Builders.JSDN.Stores
{
    public class JsdnStoreBuilder
    {
        public string StoreAcronym;
        public string StoreName;
        public string StoreCnpj;
        public string Acronym;
        public string StoreDescription;
        public string IDPEntityName;
        public string StateRegistration;
        public string CompanyURL;
        public string Street;
        public string Number;
        public string Complement;
        public string Neighborhood;
        public string City;
        public string State;
        public string Country;
        public string ZipCode;
        public string CCMMunicipalTaxpayerRegister;
        public string CompanyCode;
        public string FilialCode;
        public string CityHallServiceCode;
        public string CityHallServiceDescription;
        public string SpecialRegimeProcessNumber;

        public static JsdnStoreBuilder New()
        {
            return new JsdnStoreBuilder()
            {
                StoreAcronym = "telerese",
                StoreName = "VIVO PLATAFORMA DIGITAL",
                StoreCnpj = "22016867000178",
                Acronym = "TBRA",
                StoreDescription = "Loja TBRA vivo",
                IDPEntityName = "teste",
                StateRegistration = "teste",
                CompanyURL = "admin-dev.vivoplataformadigital.com.br",
                Street = "Av Luis Carlos Berrini",
                Number = "1376",
                Complement = "",
                Neighborhood = "Berrini",
                City = "São Paulo",
                State = "SP",
                Country = "Brasil",
                ZipCode = "04571936",
                CCMMunicipalTaxpayerRegister = "77434",
                CompanyCode = "4011775",
                FilialCode = "4011775",
                CityHallServiceCode = "1.03",
                CityHallServiceDescription = "teste",
                SpecialRegimeProcessNumber = "002/2018"
            };
        }

        public JsdnStoreBuilder WithStoreAcronym(string storeAcronym)
        {
            StoreAcronym = storeAcronym;
            return this;
        }

        public JsdnStoreBuilder WithStoreName(string storeName)
        {
            StoreName = storeName;
            return this;
        }

        public JsdnStoreBuilder WithStoreCnpj(string storeCnpj)
        {
            StoreCnpj = storeCnpj;
            return this;
        }

        public JsdnStoreBuilder WithAcronym(string acronym)
        {
            Acronym = acronym;
            return this;
        }

        public JsdnStoreBuilder WithStoreDescription(string storeDescription)
        {
            StoreDescription = storeDescription;
            return this;
        }

        public JsdnStoreBuilder WithIDPEntityName(string idpEntityName)
        {
            IDPEntityName = idpEntityName;
            return this;
        }

        public JsdnStoreBuilder WithStateRegistration(string stateRegistration)
        {
            StateRegistration = stateRegistration;
            return this;
        }

        public JsdnStoreBuilder WithCompanyURL(string companyURL)
        {
            CompanyURL = companyURL;
            return this;
        }

        public JsdnStoreBuilder WithStreet(string street)
        {
            Street = street;
            return this;
        }

        public JsdnStoreBuilder WithNumber(string number)
        {
            Number = number;
            return this;
        }

        public JsdnStoreBuilder WithComplement(string complement)
        {
            Complement = complement;
            return this;
        }

        public JsdnStoreBuilder WithNeighborhood(string neighborhood)
        {
            Neighborhood = neighborhood;
            return this;
        }

        public JsdnStoreBuilder WithCity(string city)
        {
            City = city;
            return this;
        }

        public JsdnStoreBuilder WithState(string state)
        {
            State = state;
            return this;
        }

        public JsdnStoreBuilder WithCountry(string country)
        {
            Country = country;
            return this;
        }

        public JsdnStoreBuilder WithZipCode(string zipCode)
        {
            ZipCode = zipCode;
            return this;
        }

        public JsdnStoreBuilder WithCCMMunicipalTaxpayerRegister(string ccmMunicipalTaxpayerRegister)
        {
            CCMMunicipalTaxpayerRegister = ccmMunicipalTaxpayerRegister;
            return this;
        }

        public JsdnStoreBuilder WithCompanyCode(string companyCode)
        {
            CompanyCode = companyCode;
            return this;
        }

        public JsdnStoreBuilder WithFilialCode(string filialCode)
        {
            FilialCode = filialCode;
            return this;
        }

        public JsdnStoreBuilder WithCityHallServiceCode(string cityHallServiceCode)
        {
            CityHallServiceCode = cityHallServiceCode;
            return this;
        }

        public JsdnStoreBuilder WithCityHallServiceDescription(string cityHallServiceDescription)
        {
            CityHallServiceDescription = cityHallServiceDescription;
            return this;
        }

        public JsdnStoreBuilder WithSpecialRegimeProcessNumber(string specialRegimeProcessNumber)
        {
            SpecialRegimeProcessNumber = specialRegimeProcessNumber;
            return this;
        }

        public JsdnStore Build()
            => new JsdnStore(StoreAcronym,
                StoreName,
                StoreCnpj,
                Acronym,
                StoreDescription,
                IDPEntityName,
                StateRegistration,
                CompanyURL,
                Street,
                Number,
                Complement,
                Neighborhood,
                City,
                State,
                Country,
                ZipCode,
                CCMMunicipalTaxpayerRegister,
                CompanyCode,
                FilialCode,
                CityHallServiceCode,
                CityHallServiceDescription,
                SpecialRegimeProcessNumber);
    }
}
