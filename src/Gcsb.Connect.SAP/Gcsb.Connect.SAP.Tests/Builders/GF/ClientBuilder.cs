using Gcsb.Connect.SAP.Domain.GF;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.GF
{
    public class ClientBuilder
    {
        public string CustomerCode;
        public DateTime CustomerUpdateDate;
        public string Statefederativeunit;
        public string CustomerDocument;
        public string CustomerType;
        public string CustomerStateRegistration;
        public string CustomerName;
        public string CustomerAddress;
        public string CustomerAddressNumber;
        public string CustomerAddressCompletion;
        public string CustomerNeighborhood;
        public string CustomerCity;
        public string CustomerZipCode;
        public string IBGECode;

        public static ClientBuilder New()
        {
            return new ClientBuilder()
            {
                CustomerCode = "GW00000000123456",
                CustomerUpdateDate = DateTime.UtcNow,
                Statefederativeunit = "SP",
                CustomerDocument = "60701190000104",
                CustomerType = "J",
                CustomerStateRegistration = "123456789",
                CustomerName = "CustomerName LTDA",
                CustomerAddress = "Rua Maria",
                CustomerAddressNumber = "1234",
                CustomerAddressCompletion = "",
                CustomerNeighborhood = "Jardim Paulista",
                CustomerCity = "Barueri",
                CustomerZipCode = "12345678",
                IBGECode = "7654321"
            };
        }

        public ClientBuilder WithCustomerCode(string customercode)
        {
            CustomerCode = customercode;
            return this;
        }

        public ClientBuilder WithStatefederativeunit(string statefederativeunit)
        {
            Statefederativeunit = statefederativeunit;
            return this;
        }

        public ClientBuilder WithCustomerDocument(string customerdocument)
        {
            CustomerDocument = customerdocument;
            return this;
        }

        public ClientBuilder WithCustomerType(string customertype)
        {
            CustomerType = customertype;
            return this;
        }

        public ClientBuilder WithCustomerStateRegistration(string customerstateregistration)
        {
            CustomerStateRegistration = customerstateregistration;
            return this;
        }

        public ClientBuilder WithCustomerName(string customername)
        {
            CustomerName = customername;
            return this;
        }

        public ClientBuilder WithCustomerAddress(string customeraddress)
        {
            CustomerAddress = customeraddress;
            return this;
        }

        public ClientBuilder WithCustomerAddressNumber(string customeraddressnumber)
        {
            CustomerAddressNumber = customeraddressnumber;
            return this;
        }

        public ClientBuilder WithCustomerAddressCompletion(string customeraddresscompletion)
        {
            CustomerAddressCompletion = customeraddresscompletion;
            return this;
        }

        public ClientBuilder WithCustomerNeighborhood(string customerneighborhood)
        {
            CustomerNeighborhood = customerneighborhood;
            return this;
        }

        public ClientBuilder WithCustomerCity(string customercity)
        {
            CustomerCity = customercity;
            return this;
        }

        public ClientBuilder WithCustomerZipCode(string customerzipcode)
        {
            CustomerZipCode = customerzipcode;
            return this;
        }

        public ClientBuilder WithIBGECode(string ibgecode)
        {
            IBGECode = ibgecode;
            return this;
        }

        public Client Build()
        {
            return new Client(CustomerCode, CustomerUpdateDate, Statefederativeunit, CustomerDocument, CustomerType, CustomerStateRegistration, CustomerName,
                CustomerAddress, CustomerAddressNumber, CustomerAddressCompletion, CustomerNeighborhood, CustomerCity, CustomerZipCode, IBGECode);
        }
    }
}
