using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomersConsumption
{
    public class CustomersResponse
    {
        public string CustomerCode { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? AccountStartDate { get; set; }
        public string InvoiceStatus { get; set; }
        public DateTime? InvoiceCreationDate { get; set; }
        public DateTime CycleDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentValue { get; set; }
        public bool InvoicePaid { get; set; }
        public string PaidBoleto { get; }
        public decimal? CreditValue { get; set; }

        public CustomersResponse(string customerCode,
            string invoiceNumber,
            DateTime? accountStartDate,
            string invoiceStatus,
            DateTime? invoiceCreationDate,
            DateTime cycleDate,
            DateTime? paymentDate,
            decimal? paymentValue,
            bool invoicePaid, 
            string paidBoleto,
            decimal? creditValue)
        {
            CustomerCode = customerCode;
            InvoiceNumber = invoiceNumber;
            AccountStartDate = accountStartDate;
            InvoiceStatus = invoiceStatus;
            InvoiceCreationDate = invoiceCreationDate;
            CycleDate = cycleDate;
            PaymentDate = paymentDate;
            PaymentValue = paymentValue;
            InvoicePaid = invoicePaid;
            PaidBoleto = paidBoleto;
            CreditValue = creditValue;
        }
    }

    
}
