using System;

namespace Gcsb.Connect.SAP.Domain.JSDN
{
    public class PaymentReport
    {
        public string ServiceCode { get; private set; }
        public string ServiceName { get; private set; }
        public string StoreAcronym { get; private set; }
        public string ProviderCompanyAcronym { get; private set; }
        public string CustomerCode { get; private set; }
        public string InvoiceNumber { get; private set; }
        public string BankCode { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public decimal PaymentValue { get; private set; }
        public decimal TotalPaymentValue { get; private set; }

        public PaymentReport(string serviceCode, string serviceName, string storeAcronym, string providerCompanyAcronym, string customerCode, string invoiceNumber, string bankCode, DateTime paymentDate, decimal paymentValue, decimal totalPaymentValue)
        {
            ServiceCode = serviceCode;
            ServiceName = serviceName;
            StoreAcronym = storeAcronym;
            ProviderCompanyAcronym = providerCompanyAcronym;
            CustomerCode = customerCode;
            InvoiceNumber = invoiceNumber;
            BankCode = bankCode;
            PaymentDate = paymentDate;
            PaymentValue = paymentValue;
            TotalPaymentValue = totalPaymentValue;
        }
    }
}
