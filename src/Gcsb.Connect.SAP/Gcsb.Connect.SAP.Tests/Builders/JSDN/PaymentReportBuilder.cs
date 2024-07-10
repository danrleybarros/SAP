using System;
using Gcsb.Connect.SAP.Domain.JSDN;

namespace Gcsb.Connect.SAP.Tests.Builders.JSDN
{
    public class PaymentReportBuilder
    {
        public string ServiceCode;
        public string ServiceName;
        public string StoreAcronym;
        public string ProviderCompanyAcronym;
        public string CustomerCode;
        public string InvoiceNumber;
        public string BankCode;
        public DateTime PaymentDate;
        public decimal PaymentValue;
        public decimal TotalPaymentValue;

        public static PaymentReportBuilder New()
        {
            return new PaymentReportBuilder()
            {
                ServiceCode = "ServiceCodeTest",
                ServiceName = "ServiceNameTest",
                StoreAcronym = "telerese",
                ProviderCompanyAcronym = "telerese",
                CustomerCode = "12345",
                InvoiceNumber = "12345",
                BankCode = "1",
                PaymentDate = DateTime.UtcNow,
                PaymentValue = 0,
                TotalPaymentValue = 0
            };
        }

        public PaymentReportBuilder WithServiceCode(string serviceCode)
        {
            ServiceCode = serviceCode;
            return this;
        }

        public PaymentReportBuilder WithServiceName(string serviceName)
        {
            ServiceName = serviceName;
            return this;
        }

        public PaymentReportBuilder WithStoreAcronym(string storeAcronym)
        {
            StoreAcronym = storeAcronym;
            return this;
        }

        public PaymentReportBuilder WithProviderCompanyAcronym(string providerCompanyAcronym)
        {
            ProviderCompanyAcronym = providerCompanyAcronym;
            return this;
        }

        public PaymentReportBuilder WithCustomerCode(string customerCode)
        {
            CustomerCode = customerCode;
            return this;
        }

        public PaymentReportBuilder WithInvoiceNumber(string invoiceNumber)
        {
            InvoiceNumber = invoiceNumber;
            return this;
        }

        public PaymentReportBuilder WithBankCode(string bankCode)
        {
            BankCode = bankCode;
            return this;
        }

        public PaymentReportBuilder WithPaymentDate(DateTime paymentDate)
        {
            PaymentDate = paymentDate;
            return this;
        }

        public PaymentReportBuilder WithPaymentValue(decimal paymentValue)
        {
            PaymentValue = paymentValue;
            return this;
        }

        public PaymentReportBuilder WithTotalPaymentValue(decimal totalPaymentValue)
        {
            TotalPaymentValue = totalPaymentValue;
            return this;
        }

        public PaymentReport Build()
            => new PaymentReport(ServiceCode, ServiceName, StoreAcronym, ProviderCompanyAcronym, CustomerCode, InvoiceNumber, BankCode, PaymentDate, PaymentValue, TotalPaymentValue);
    }
}
