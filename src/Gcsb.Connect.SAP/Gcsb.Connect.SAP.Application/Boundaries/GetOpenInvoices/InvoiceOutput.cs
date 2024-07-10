using System;

namespace Gcsb.Connect.SAP.Application.Boundaries.GetOpenInvoices
{
    public class InvoiceOutput
    {
        public string CustomerCode { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Cycle { get; set; }
        public DateTime DueDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal PaidAmount { get; set; }

        public InvoiceOutput(string customerCode, string companyName, string cnpj, string invoiceNumber, 
            DateTime cycle, DateTime dueDate, decimal invoiceAmount, decimal paidAmount)
        {
            CustomerCode = customerCode;
            CompanyName = companyName;
            Cnpj = cnpj;
            InvoiceNumber = invoiceNumber;
            Cycle = cycle;
            DueDate = dueDate;
            InvoiceAmount = invoiceAmount;
            PaidAmount = paidAmount;
        }
    }
}
