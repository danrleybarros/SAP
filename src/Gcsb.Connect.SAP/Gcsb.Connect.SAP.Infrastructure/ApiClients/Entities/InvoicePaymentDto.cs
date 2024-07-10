using System;

namespace Gcsb.Connect.SAP.Infrastructure.ApiClients.Entities
{
    public class InvoicePaymentDto
    {
        public long CustomerCode { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string FormAssignment { get; set; }
        public decimal Credit { get; set; }
    }
}
