using System;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
{
    public class PaymentReport
    {
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string StoreAcronym { get; set; }
        public string ProviderCompanyAcronym { get; set; }
        public string CustomerCode { get; set; }
        public string InvoiceNumber { get; set; }
        public string BankCode { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentValue { get; set; }
        public decimal? TotalPaymentValue { get; set; }
    }
}
