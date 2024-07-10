using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.JSDN.Stores
{
    public class JsdnStore
    {
        [Required]
        public string StoreAcronym { get; private set; }

        [Required]
        public string StoreName { get; private set; }

        [Required]
        public string StoreCnpj { get; private set; }

        [Required]
        public string Acronym { get; private set; }

        [Required]
        public string StoreDescription { get; private set; }

        [Required]
        public string IDPEntityName { get; private set; }

        public string StateRegistration { get; private set; }

        [Required]
        public string CompanyURL { get; private set; }

        [Required]
        public string Street { get; private set; }

        [Required]
        public string Number { get; private set; }

        public string Complement { get; private set; }

        [Required]
        public string Neighborhood { get; private set; }

        [Required]
        public string City { get; private set; }

        [Required]
        public string State { get; private set; }

        [Required]
        public string Country { get; private set; }

        [Required]
        public string ZipCode { get; private set; }

        [Required]
        public string CCMMunicipalTaxpayerRegister { get; private set; }

        [Required]
        public string CompanyCode { get; private set; }

        [Required]
        public string FilialCode { get; private set; }

        [Required]
        public string CityHallServiceCode { get; private set; }

        [Required]
        public string CityHallServiceDescription { get; private set; }

        [Required]
        public string SpecialRegimeProcessNumber { get; private set; }

        public JsdnStore(string storeAcronym, string storeName, string storeCnpj, string acronym, string storeDescription, string iDPEntityName, string stateRegistration, string companyURL, string street, string number, string complement, string neighborhood, string city,
            string state, string country, string zipCode, string cCMMunicipalTaxpayerRegister, string companyCode, string filialCode, string cityHallServiceCode, string cityHallServiceDescription, string specialRegimeProcessNumber)
        {
            StoreAcronym = storeAcronym;
            StoreName = storeName;
            StoreCnpj = storeCnpj;
            Acronym = acronym;
            StoreDescription = storeDescription;
            IDPEntityName = iDPEntityName;
            StateRegistration = stateRegistration;
            CompanyURL = companyURL;
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            CCMMunicipalTaxpayerRegister = cCMMunicipalTaxpayerRegister;
            CompanyCode = companyCode;
            FilialCode = filialCode;
            CityHallServiceCode = cityHallServiceCode;
            CityHallServiceDescription = cityHallServiceDescription;
            SpecialRegimeProcessNumber = specialRegimeProcessNumber;
        }
    }
}