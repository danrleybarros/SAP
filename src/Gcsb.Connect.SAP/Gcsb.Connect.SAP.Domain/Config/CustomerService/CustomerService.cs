using System;

namespace Gcsb.Connect.SAP.Domain.Config.CustomerService
{
    public class CustomerService
    {
        public string CustomerAccount { get; set; }
        public string AccountStatus { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalInvoicePrice { get; set; }
        public DateTime AccountStartDate { get; set; }
        public string UF { get; set; }
        public string ProductType { get; set; }
        public string CustomerCode { get; set; }
        public string InvoiceNumber { get; set; }
        public string ServiceCode { get; set; }
        public DateTime OrignalDueDate { get; set; }
        public DateTime OldestDueDate { get; set; }
    }
}
