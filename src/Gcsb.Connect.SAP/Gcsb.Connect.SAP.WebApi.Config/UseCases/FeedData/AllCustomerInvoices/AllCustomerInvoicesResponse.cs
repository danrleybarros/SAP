using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.AllCustomerInvoices
{
    public class AllCustomerInvoicesResponse
    {
        public long CustomerCode { get; private set; }
        public string CompanyName { get; private set; }
        public string CycleCode { get; private set; }
        public string InvoiceNumber { get; private set; }
        public DateTime InvoiceDate { get; private set; }
        public decimal InvoiceValue { get; private set; }
        public List<Services> Services { get; private set; }
        public string PaymentStatus { get; private set; }
        public DateTime? PaymentDate { get; private set; }

        public AllCustomerInvoicesResponse(long customerCode, string companyName, string cycleCode, string invoiceNumber, DateTime invoiceDate, decimal invoiceValue, List<Services> services, string paymentStatus, DateTime? paymentDate)
        {
            CustomerCode = customerCode;
            CompanyName = companyName;
            CycleCode = cycleCode;
            InvoiceNumber = invoiceNumber;
            InvoiceDate = invoiceDate;
            InvoiceValue = invoiceValue;
            Services = services;
            PaymentStatus = paymentStatus;
            PaymentDate = paymentDate;
        }
    }

    public partial class Services
    {
        public string ServiceCode { get; private set; }
        public string ServiceName { get; private set; }
        public string ServiceType { get; private set; }
        public decimal GrandTotalRetailPrice { get; private set; }
        public string Activity { get; private set; }
        public DateTime? OrderCreationDate { get; private set; }

        public Services(string serviceCode, string serviceName, string serviceType, decimal grandTotalRetailPrice, string activity, DateTime? orderCreationDate)
        {
            ServiceCode = serviceCode;
            ServiceName = serviceName;
            ServiceType = serviceType;
            GrandTotalRetailPrice = grandTotalRetailPrice;
            Activity = activity;
            OrderCreationDate = orderCreationDate;
        }
    }
}
