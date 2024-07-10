using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit
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
        public string IndividualInvoice { get; set; }

        public virtual Invoice Invoice { get; set; }

        public string CnpjMarketPlace { get; set; }

        public string CompanyNameMarketPlace { get; set; }

        public string CustomerAcronym { get; set; }

        public string Segment { get; set; }

        public string CpfUserHasMadeCredit { get; set; }

        public string ProposalNumber { get; set; }

        public string AdabasCode { get; set; }

        public string OpportunityId { get; set; }

        public string QuoteId { get; set; }
    }
}
