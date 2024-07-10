using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit
{
    public class Invoice : IEntity
    {
        public Guid Id { get; private set; }

        public Guid IdFile { get; private set; }

        public string InvoiceNumber { get; private set; }

        public string Marketplace { get; private set; }

        public string ResellerName { get; private set; }

        public string ResellerContactName { get; private set; }

        public string ResellerEmailAddress { get; private set; }

        public string ResellerPhoneNumber { get; private set; }

        public string OrderId { get; private set; }

        public DateTime? BillFrom { get; private set; }

        public DateTime? BillTo { get; private set; }

        public DateTime? InvoiceCreationDate { get; private set; }

        public string StoreCode { get; private set; }

        public string MarketplaceCity { get; private set; }

        public string MarketplaceState { get; private set; }

        public string Premeditateddefaulter { get; private set; }

        public string CustomerTransactionCurrency { get; private set; }

        public string PaymentMethod { get; private set; }

        public string PaymentStatus { get; private set; }

        public string RefundType { get; private set; }

        public string RefundAmount { get; private set; }

        public string InvoiceStatus { get; private set; }

        public Customer Customer { get; set; }

        public List<ServiceInvoice> Services { get; set; }

        public virtual List<PaymentCreditCard> PaymentFeedsCredit { get; set; }

        public virtual List<PaymentBoleto> PaymentFeedsBoleto { get; set; }

        [MaxLength(10)]
        public string CompanyCode { get; set; }

        [MaxLength(10)]
        public string AffiliateCode { get; set; }

        [MaxLength(10)]
        public string CityServiceCode { get; set; }

        [MaxLength(150)]
        public string CityHallServiceDescription { get; set; }

        [MaxLength(150)]
        public string SpecialProcedureNumber { get; set; }

        public decimal? TotalInvoicePrice { get; set; }

        public string MunicipalTaxpayerRegistration { get; set; }

        public DateTime? CycleCode { get; set; }

        public string StoreAcronym { get; set; }


        public Invoice(Guid idFile, string invoiceNumber, string marketplace, string resellerName, string resellerContactName, string resellerEmailAddress,
            string resellerPhoneNumber, string orderId, DateTime? billFrom, DateTime? billTo, DateTime? invoiceCreationDate, string storeCode,
            string marketplaceCity, string marketplaceState, string premeditateddefaulter, string customerTransactionCurrency, string paymentMethod,
            string paymentStatus, string refundType, string refundAmount, string invoiceStatus, Customer customer, List<ServiceInvoice> services, string companycode,
            string affiliatecode, string cityservicecode, string cityhallservicedescription, string specialprocedurenumber, decimal? totalinvoiceprice,
            string municipaltaxpayerregistration, DateTime? cycleCode, string storeAcronym)
        {
            Id = Guid.NewGuid();
            IdFile = idFile;
            InvoiceNumber = invoiceNumber;
            Marketplace = marketplace;
            ResellerName = resellerName;
            ResellerContactName = resellerContactName;
            ResellerEmailAddress = resellerEmailAddress;
            ResellerPhoneNumber = resellerPhoneNumber;
            OrderId = orderId;
            BillFrom = billFrom;
            BillTo = billTo;
            InvoiceCreationDate = invoiceCreationDate;
            StoreCode = storeCode;
            MarketplaceCity = marketplaceCity;
            MarketplaceState = marketplaceState;
            Premeditateddefaulter = premeditateddefaulter;
            CustomerTransactionCurrency = customerTransactionCurrency;
            PaymentMethod = paymentMethod;
            PaymentStatus = paymentStatus;
            RefundType = refundType;
            RefundAmount = refundAmount;
            InvoiceStatus = invoiceStatus;
            Customer = customer;
            Services = services;
            CompanyCode = companycode;
            AffiliateCode = affiliatecode;
            CityServiceCode = cityservicecode;
            CityHallServiceDescription = cityhallservicedescription;
            SpecialProcedureNumber = specialprocedurenumber;
            TotalInvoicePrice = totalinvoiceprice;
            MunicipalTaxpayerRegistration = municipaltaxpayerregistration;
            CycleCode = cycleCode;
            StoreAcronym = storeAcronym;
        }
    }
}
