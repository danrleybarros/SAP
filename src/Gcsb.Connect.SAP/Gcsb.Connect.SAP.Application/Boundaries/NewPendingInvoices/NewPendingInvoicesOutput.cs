using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.Boundaries.NewPendingInvoices
{
    public class NewPendingInvoicesOutput
    {
        public string CustomerCode { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? AccountStartDate { get; set; }
        public string InvoiceStatus { get; set; }
        public DateTime? InvoiceCreationDate { get; set; }
        public DateTime CycleDate { get; set; }
        public decimal? InvoiceValue { get; set; }
        public DateTime DueDate { get; set; }

        public NewPendingInvoicesOutput(string customerCode, string cpf, string cnpj, 
            string invoiceNumber, DateTime? accountStartDate, string invoiceStatus, 
            DateTime? invoiceCreationDate, DateTime cycleDate, decimal? invoiceValue,
            DateTime dueDate)
        {
            CustomerCode = customerCode;
            Cpf = cpf;
            Cnpj = cnpj;
            InvoiceNumber = invoiceNumber;
            AccountStartDate = accountStartDate;
            InvoiceStatus = invoiceStatus;
            InvoiceCreationDate = invoiceCreationDate;
            CycleDate = cycleDate;
            InvoiceValue = invoiceValue;
            DueDate = dueDate;
        }
    }
}
