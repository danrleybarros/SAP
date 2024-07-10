using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit
{
    public class Customer
    {
        public Guid Id { get; private set; }

        public string InvoiceNumber { get; private set; }

        public string CompanyName { get; private set; }

        public string CustomerCode { get; private set; }

        public DateTime? AccountCreationDate { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string CustomerEmailAddress { get; private set; }

        public string CustomerPhoneNumber { get; private set; }

        public string BillingStreet { get; private set; }

        public string BillingNumber { get; private set; }

        public string BillingComplement { get; private set; }

        public string BillingNeighbourhood { get; private set; }

        public string BillingCity { get; private set; }

        public string BillingStateOrProvince { get; private set; }

        public string BillingZIPcode { get; private set; }

        public string BillingCountry { get; private set; }

        public string BillingCountryCode { get; private set; }

        public string BillingPhoneNumber { get; private set; }

        public string MailingStreet { get; private set; }

        public string MailingNumber { get; private set; }

        public string MailingComplement { get; private set; }

        public string MailingNeighbourhood { get; private set; }

        public string MailingCity { get; private set; }

        public string MailingStateOrProvince { get; private set; }

        public string MailingZIPcode { get; private set; }

        public string MailingCountry { get; private set; }

        public string MailingCountryCode { get; private set; }

        public string MailingPhoneNumber { get; private set; }

        public string CustomerCPF { get; private set; }

        public string CustomerCNPJ { get; private set; }

        public string CustomerStateRegistration { get; private set; }

        public string UserAccountStatus { get; private set; }

        [MaxLength(1)]
        public string IndividualInvoice { get; private set; }

        public Invoice Invoice { get; private set; }

        public string CnpjMarketPlace { get; private set; }

        public string CompanyNameMarketPlace { get; private set; }

        public string CustomerAcronym { get; private set; }

        public string Segment { get; private set; }

        public string CpfUserHasMadeCredit { get; private set; }

        public string ProposalNumber { get; private set; }

        public string AdabasCode { get; private set; }

        public string OpportunityId { get; private set; }

        public string QuoteId { get; private set; }

        public Customer(Guid id, string companyName, string customerCode, DateTime? accountCreationDate, string firstName, string lastName, string customerEmailAddress, string customerPhoneNumber,
            string billingStreet, string billingNumber, string billingComplement, string billingNeighbourhood, string billingCity, string billingStateOrProvince, string billingZIPcode, string billingCountry,
            string billingCountryCode, string billingPhoneNumber, string mailingStreet, string mailingNumber, string mailingComplement, string mailingNeighbourhood, string mailingCity,
            string mailingStateOrProvince, string mailingZIPcode, string mailingCountry, string mailingCountryCode, string mailingPhoneNumber, string customerCPF, string customerCNPJ,
            string customerStateRegistration, string userAccountStatus, string individualinvoice, Invoice invoice, string cnpjmarketplace, string companynamemarketplace, string customeracronym, string segment,
            string cpfUserHasMadeCredit, string proposalNumber, string adabasCode, string opportunityId, string quoteId)
        {
            Id = id;
            CompanyName = companyName;
            CustomerCode = customerCode;
            AccountCreationDate = accountCreationDate;
            FirstName = firstName;
            LastName = lastName;
            CustomerEmailAddress = customerEmailAddress;
            CustomerPhoneNumber = customerPhoneNumber;
            BillingStreet = billingStreet;
            BillingNumber = billingNumber;
            BillingComplement = billingComplement;
            BillingNeighbourhood = billingNeighbourhood;
            BillingCity = billingCity;
            BillingStateOrProvince = billingStateOrProvince;
            BillingZIPcode = billingZIPcode.Replace(@"-", "");
            BillingCountry = billingCountry;
            BillingCountryCode = billingCountryCode;
            BillingPhoneNumber = billingPhoneNumber;
            MailingStreet = mailingStreet;
            MailingNumber = mailingNumber;
            MailingComplement = mailingComplement;
            MailingNeighbourhood = mailingNeighbourhood;
            MailingCity = mailingCity;
            MailingStateOrProvince = mailingStateOrProvince;
            MailingZIPcode = mailingZIPcode;
            MailingCountry = mailingCountry;
            MailingCountryCode = mailingCountryCode;
            MailingPhoneNumber = mailingPhoneNumber;
            CustomerCPF = Regex.Replace(customerCPF ?? "", @"[^0-9]+", "");
            CustomerCNPJ = Regex.Replace(customerCNPJ ?? "", @"[^0-9]+", "");
            CustomerStateRegistration = customerStateRegistration;
            UserAccountStatus = userAccountStatus;
            IndividualInvoice = individualinvoice;
            Invoice = invoice;
            CnpjMarketPlace = cnpjmarketplace;
            CompanyNameMarketPlace = companynamemarketplace;
            CustomerAcronym = customeracronym;
            Segment = segment;
            CpfUserHasMadeCredit = cpfUserHasMadeCredit;
            ProposalNumber = proposalNumber;
            AdabasCode = adabasCode;
            OpportunityId = opportunityId;
            QuoteId = quoteId;
        }

        public void SetInvoiceNumber(string invoiceNumber)
            => InvoiceNumber = invoiceNumber;

        public void SetInvoice(Invoice invoice)
            => Invoice = invoice;
    }
}
