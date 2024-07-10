using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.InterestAndFine
{
    public class CustomerInterestAndFine
    {
        public string CustomerCode { get; private set; }
        public string CompanyName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Cpf { get; private set; }
        public string Cnpj { get; private set; }
        public string Segment { get; private set; }
        public string Uf { get; private set; }
        public string City { get; private set; }
        public string Email { get; private set; }
        public string ZipCode { get; private set; }

        public CustomerInterestAndFine(string customerCode, string companyName, string firstName, 
            string lastName, string cpf, string cnpj, string segment, string uf, string city, 
            string email, string zipCode)
        {
            CustomerCode = customerCode;
            CompanyName = companyName;
            FirstName = firstName;
            LastName = lastName;
            Cpf = cpf;
            Cnpj = cnpj;
            Segment = segment;
            Uf = uf;
            City = city;
            Email = email;
            ZipCode = zipCode;
        }
    }
}
