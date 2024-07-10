using System;

namespace Gcsb.Connect.SAP.Domain.PAY
{
    public class InvoicePayment
    {
        public long CustomerCode { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal InvoiceAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string FormAssignment { get; set; }
        public decimal Credit { get; set; }

        public InvoicePayment(long customerCode, string invoiceNumber, decimal paidAmount, decimal amount, DateTime paymentDate, string formAssignment, decimal invoiceAmount, decimal credit)
        {
            CustomerCode = customerCode;
            InvoiceNumber = invoiceNumber;
            PaidAmount = paidAmount;
            Amount = amount;
            PaymentDate = paymentDate;
            FormAssignment = formAssignment;
            InvoiceAmount = invoiceAmount;
            Credit = credit;
        }
    }
}
