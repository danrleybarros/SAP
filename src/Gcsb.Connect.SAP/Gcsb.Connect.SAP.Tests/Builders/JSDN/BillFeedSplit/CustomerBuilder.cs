using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit
{
    public class CustomerBuilder
    {
        public Guid Id;
        public string CompanyName;
        public string CustomerCode;
        public DateTime? AccountCreationDate;
        public string FirstName;
        public string LastName;
        public string CustomerEmailAddress;
        public string CustomerPhoneNumber;
        public string BillingStreet;
        public string BillingNumber;
        public string BillingComplement;
        public string BillingNeighbourhood;
        public string BillingCity;
        public string BillingStateOrProvince;
        public string BillingZIPcode;
        public string BillingCountry;
        public string BillingCountryCode;
        public string BillingPhoneNumber;
        public string MailingStreet;
        public string MailingNumber;
        public string MailingComplement;
        public string MailingNeighbourhood;
        public string MailingCity;
        public string MailingStateOrProvince;
        public string MailingZIPcode;
        public string MailingCountry;
        public string MailingCountryCode;
        public string MailingPhoneNumber;
        public string CustomerCPF;
        public string CustomerCNPJ;
        public string CustomerStateRegistration;
        public string UserAccountStatus;
        public string IndividualInvoice;
        public Invoice Invoice;
        public string InvoiceNumber;
        public string CnpjMarketPlace;
        public string CompanyNameMarketPlace;
        public string CustomerAcronym;
        public string Segment;
        public string CpfUserHasMadeCredit;
        public string ProposalNumber;
        public string AdabasCode;
        public string OpportunityId;
        public string QuoteId;

        public CustomerBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public CustomerBuilder WithInvoiceNumber(string invoiceNumber)
        {
            InvoiceNumber = invoiceNumber;
            return this;
        }

        public CustomerBuilder WithCompanyName(string companyname)
        {
            CompanyName = companyname;
            return this;
        }

        public CustomerBuilder WithCustomerCode(string customercode)
        {
            CustomerCode = customercode;
            return this;
        }

        public CustomerBuilder WithAccountCreationDate(DateTime? accountcreationdate)
        {
            AccountCreationDate = accountcreationdate;
            return this;
        }

        public CustomerBuilder WithFirstName(string firstname)
        {
            FirstName = firstname;
            return this;
        }

        public CustomerBuilder WithLastName(string lastname)
        {
            LastName = lastname;
            return this;
        }

        public CustomerBuilder WithCustomerEmailAddress(string customeremailaddress)
        {
            CustomerEmailAddress = customeremailaddress;
            return this;
        }

        public CustomerBuilder WithCustomerPhoneNumber(string customerphonenumber)
        {
            CustomerPhoneNumber = customerphonenumber;
            return this;
        }

        public CustomerBuilder WithBillingStreet(string billingstreet)
        {
            BillingStreet = billingstreet;
            return this;
        }

        public CustomerBuilder WithBillingNumber(string billingnumber)
        {
            BillingNumber = billingnumber;
            return this;
        }

        public CustomerBuilder WithBillingComplement(string billingcomplement)
        {
            BillingComplement = billingcomplement;
            return this;
        }

        public CustomerBuilder WithBillingNeighbourhood(string billingneighbourhood)
        {
            BillingNeighbourhood = billingneighbourhood;
            return this;
        }

        public CustomerBuilder WithBillingCity(string billingcity)
        {
            BillingCity = billingcity;
            return this;
        }

        public CustomerBuilder WithBillingStateOrProvince(string billingstateorprovince)
        {
            BillingStateOrProvince = billingstateorprovince;
            return this;
        }

        public CustomerBuilder WithBillingZIPcode(string billingzipcode)
        {
            BillingZIPcode = billingzipcode;
            return this;
        }

        public CustomerBuilder WithBillingCountry(string billingcountry)
        {
            BillingCountry = billingcountry;
            return this;
        }

        public CustomerBuilder WithBillingCountryCode(string billingcountrycode)
        {
            BillingCountryCode = billingcountrycode;
            return this;
        }

        public CustomerBuilder WithBillingPhoneNumber(string billingphonenumber)
        {
            BillingPhoneNumber = billingphonenumber;
            return this;
        }

        public CustomerBuilder WithMailingStreet(string mailingstreet)
        {
            MailingStreet = mailingstreet;
            return this;
        }

        public CustomerBuilder WithMailingNumber(string mailingnumber)
        {
            MailingNumber = mailingnumber;
            return this;
        }

        public CustomerBuilder WithMailingComplement(string mailingcomplement)
        {
            MailingComplement = mailingcomplement;
            return this;
        }

        public CustomerBuilder WithMailingNeighbourhood(string mailingneighbourhood)
        {
            MailingNeighbourhood = mailingneighbourhood;
            return this;
        }

        public CustomerBuilder WithMailingCity(string mailingcity)
        {
            MailingCity = mailingcity;
            return this;
        }

        public CustomerBuilder WithMailingStateOrProvince(string mailingstateorprovince)
        {
            MailingStateOrProvince = mailingstateorprovince;
            return this;
        }

        public CustomerBuilder WithMailingZIPcode(string mailingzipcode)
        {
            MailingZIPcode = mailingzipcode;
            return this;
        }

        public CustomerBuilder WithMailingCountry(string mailingcountry)
        {
            MailingCountry = mailingcountry;
            return this;
        }

        public CustomerBuilder WithMailingCountryCode(string mailingcountrycode)
        {
            MailingCountryCode = mailingcountrycode;
            return this;
        }

        public CustomerBuilder WithMailingPhoneNumber(string mailingphonenumber)
        {
            MailingPhoneNumber = mailingphonenumber;
            return this;
        }

        public CustomerBuilder WithCustomerCPF(string customercpf)
        {
            CustomerCPF = customercpf;
            return this;
        }

        public CustomerBuilder WithCustomerCNPJ(string customercnpj)
        {
            CustomerCNPJ = customercnpj;
            return this;
        }

        public CustomerBuilder WithCustomerStateRegistration(string customerstateregistration)
        {
            CustomerStateRegistration = customerstateregistration;
            return this;
        }

        public CustomerBuilder WithUserAccountStatus(string useraccountstatus)
        {
            UserAccountStatus = useraccountstatus;
            return this;
        }

        public CustomerBuilder WithIndividualInvoice(string individualinvoice)
        {
            IndividualInvoice = individualinvoice;
            return this;
        }

        public CustomerBuilder WithInvoice(Invoice invoice)
        {
            Invoice = invoice;
            return this;
        }

        public CustomerBuilder WithCustomerAcronym(string customeracronym)
        {
            CustomerAcronym = customeracronym;
            return this;
        }

        public CustomerBuilder WithSegment(string segment)
        {
            Segment = segment;
            return this;
        }

        public CustomerBuilder WithCpfUserHasMadeCredit(string cpfUserHasMadeCredit)
        {
            CpfUserHasMadeCredit = cpfUserHasMadeCredit;
            return this;
        }

        public CustomerBuilder WithProposalNumber(string proposalNumber)
        {
            ProposalNumber = proposalNumber;
            return this;
        }

        public CustomerBuilder WithAdabasCode(string adabasCode)
        {
            AdabasCode = adabasCode;
            return this;
        }

        public CustomerBuilder WithOpportunityId(string opportunityId)
        {
            OpportunityId = opportunityId;
            return this;
        }

        public CustomerBuilder WithQuoteId(string quoteId)
        {
            QuoteId = quoteId;
            return this;
        }

        public static CustomerBuilder New()
        {
            return new CustomerBuilder
            {
                Id = Guid.NewGuid(),
                CompanyName = "CompanyNameTest",
                AccountCreationDate = DateTime.UtcNow,
                FirstName = "FirstNameTest",
                LastName = "LastNameTest",
                CustomerEmailAddress = "CustomerEmailAddressTest",
                CustomerPhoneNumber = "CustomerPhoneNumberTest",
                BillingStreet = "BillingStreetTest",
                BillingNumber = "100",
                BillingComplement = "BillingComplementTest",
                BillingNeighbourhood = "BillingNeighbourhoodTest",
                BillingCity = "BillingCityTest",
                BillingStateOrProvince = "São Paulo",
                BillingZIPcode = "BillingZIPcodeTest",
                BillingCountry = "BillingCountryTest",
                BillingCountryCode = "BillingCountryCodeTest",
                BillingPhoneNumber = "BillingPhoneNumberTest",
                MailingStreet = "MailingStreetTest",
                MailingNumber = "100",
                MailingComplement = "MailingComplementTest",
                MailingNeighbourhood = "MailingNeighbourhoodTest",
                MailingCity = "São Paulo",
                MailingStateOrProvince = "SP",
                MailingZIPcode = "04571936",
                MailingCountry = "Brasil",
                MailingCountryCode = "MailingCountryCodeTest",
                MailingPhoneNumber = "MailingPhoneNumberTest",
                CustomerCPF = "10030456745",
                CustomerCNPJ = "80.166.553/0001-58",
                CustomerStateRegistration = "CustomerStateRegistrationTest",
                UserAccountStatus = "UserAccountStatusTest",
                IndividualInvoice = "S",
                CnpjMarketPlace = "100029/0001",
                CompanyNameMarketPlace = "Company teste",
                CustomerCode = "CustomerTest",
                CustomerAcronym = "",
                Segment = "Massive",
                CpfUserHasMadeCredit = "989.661.310-93",
                ProposalNumber = "123456",
                AdabasCode = "8045965",
                OpportunityId = "00656000008T0ORAA0",
                QuoteId = "0Q063000000CvT8CAK"
            };
        }

        public Customer Build()
        {
            var customer = new Customer(Id, CompanyName, CustomerCode, AccountCreationDate, FirstName, LastName, CustomerEmailAddress, CustomerPhoneNumber, BillingStreet, BillingNumber, BillingComplement,
                BillingNeighbourhood, BillingCity, BillingStateOrProvince, BillingZIPcode, BillingCountry, BillingCountryCode, BillingPhoneNumber, MailingStreet, MailingNumber, MailingComplement,
                MailingNeighbourhood, MailingCity, MailingStateOrProvince, MailingZIPcode, MailingCountry, MailingCountryCode, MailingPhoneNumber, CustomerCPF, CustomerCNPJ, CustomerStateRegistration,
                UserAccountStatus, IndividualInvoice, Invoice, CnpjMarketPlace, CompanyNameMarketPlace, CustomerAcronym, Segment, CpfUserHasMadeCredit, ProposalNumber, AdabasCode, OpportunityId, QuoteId);

            customer.SetInvoiceNumber(InvoiceNumber);
            return customer;
        }
    }
}
