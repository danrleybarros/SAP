using Gcsb.Connect.SAP.Domain.AttributeValidation;
using System.ComponentModel.DataAnnotations;

namespace GW_FSW_SAP.Domain
{
    public class Client
    {
        private const string clientIdentifier = "D1";
        private const string country = "BR";
        private const string docType = "CPF";

        [Required]
        [MaxLength(2)]
        public string ClientIdentifier { get => clientIdentifier; }
        [Required]
        [MaxLength(60)]
        public string CompanyName { get; private set; }
        [Required]
        [MaxLength(60)]
        public string Street { get; private set; }
        [Required]
        [MaxLength(10)]
        public string Number { get; private set; }
        [MaxLength(10)]
        public string Complement { get; private set; }
        [Required]
        [MaxLength(35)]
        public string Neighborhood { get; private set; }
        [Required]
        [MaxLength(35)]
        public string City { get; private set; }
        [Required]
        [MaxLength(10)]
        public string ZipCode { get; private set; }
        [Required]
        [MaxLength(3)]
        public string StateProvince { get; private set; }
        [Required]
        [MaxLength(2)]
        public string Country { get => country; }
        [Required]
        [MaxLength(16)]
        [RegularExpression(@"^[0-9]*$")]
        public string CustomerPhoneNumber { get; private set; }
        [Required]
        [MaxLength(4)]
        public string DocType { get => docType; }
        [Required]
        [MaxLength(20)]
        [ValidDoc]
        public string UnformattedCPForCNPJ { get; private set; }
        [MaxLength(18)]
        [ValidIE]
        public string StateRegistration { get; private set; }
        [MaxLength(18)]
        public string OptionalCityRegistration { get; private set; }
        [MaxLength(35)]
        public string CustomerEmailAddress { get; private set; }
        [MaxLength(1)]
        public string IndividualInvoice { get; private set; }

        public Client(string companyName, string street, string number, string complement, string neighborhood, string city, string zipCode, 
            string stateProvince, string customerPhoneNumber, string unformattedCPForCNPJ, string stateRegistration, 
            string optionalCityRegistration, string customerEmailAddress, string individualInvoice)
        {
            CompanyName = companyName;
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            ZipCode = zipCode;
            StateProvince = stateProvince;
            CustomerPhoneNumber = customerPhoneNumber;
            UnformattedCPForCNPJ = unformattedCPForCNPJ;
            StateRegistration = stateRegistration;
            OptionalCityRegistration = optionalCityRegistration;
            CustomerEmailAddress = customerEmailAddress;
            IndividualInvoice = individualInvoice;
        }

    }
}
