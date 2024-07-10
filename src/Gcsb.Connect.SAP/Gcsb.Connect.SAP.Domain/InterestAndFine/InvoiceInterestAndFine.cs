using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.InterestAndFine
{
    public class InvoiceInterestAndFine
    {
        public string CustomerCode { get; set; }
        public string InvoiceNumber { get; set; }
        public string BillingCycle { get; set; }
        public decimal InvoiceAmount { get; set; }
        public DateTime DueDate { get; set; }
        public List<ServiceInterestAndFine> Services { get; set; }

        public InvoiceInterestAndFine(string customerCode, string invoiceNumber, string billingCycle, 
            decimal invoiceAmount, DateTime dueDate, List<ServiceInterestAndFine> services)
        {
            CustomerCode = customerCode;
            InvoiceNumber = invoiceNumber;
            BillingCycle = billingCycle;
            InvoiceAmount = invoiceAmount;
            DueDate = dueDate;
            Services = services;
        }
    }
}
