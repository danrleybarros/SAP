using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit
{
    public class InvoiceBuilder
    {
        public Guid IdFile;

        public string InvoiceNumber;

        public string Marketplace;

        public string ResellerName;

        public string ResellerContactName;

        public string ResellerEmailAddress;

        public string ResellerPhoneNumber;

        public string OrderId;

        public DateTime? BillFrom;

        public DateTime? BillTo;

        public DateTime? InvoiceCreationDate;

        public string StoreCode;

        public string MarketplaceCity;

        public string MarketplaceState;

        public string Premeditateddefaulter;

        public string CustomerTransactionCurrency;

        public string PaymentMethod;

        public string PaymentStatus;

        public string RefundType;

        public string RefundAmount;

        public string InvoiceStatus;

        public Customer Customer;

        public List<PaymentCreditCard> PaymentFeedDocs;

        public List<PaymentBoleto> PaymentFeedsBoleto;

        public List<ServiceInvoice> Services;

        public string CompanyCode;

        public string AffiliateCode;

        public string CityServiceCode;

        public string CityHallServiceDescription;

        public string SpecialProcedureNumber;

        public decimal? TotalInvoicePrice;

        public string MunicipalTaxpayerRegistration;

        public DateTime? CycleCode;

        public string StoreAcronym;

        public static InvoiceBuilder New()
        {
            return new InvoiceBuilder
            {
                IdFile = Guid.NewGuid(),
                InvoiceNumber = "",
                Marketplace = "MarketplaceTest",
                ResellerName = "ResellerNameTest",
                ResellerContactName = "ResellerContactNameTest",
                ResellerEmailAddress = "ResellerEmailAddressTest",
                ResellerPhoneNumber = "6545-6544",
                OrderId = "666",
                BillFrom = DateTime.UtcNow,
                BillTo = DateTime.UtcNow,
                InvoiceCreationDate = DateTime.UtcNow,
                StoreCode = "StoreCodeTest",
                MarketplaceCity = "MarketplaceCityTest",
                MarketplaceState = "MarketplaceStateTest",
                Premeditateddefaulter = "PremeditateddefaulterTest",
                CustomerTransactionCurrency = "CustomerTransactionCurrencyTest",
                PaymentMethod = "PaymentMethodTest",
                PaymentStatus = "PaymentStatusTest",
                RefundType = "RefundTypeTest",
                RefundAmount = "RefundAmountTest",
                InvoiceStatus = "InvoiceStatusTest",
                PaymentFeedDocs = new List<PaymentCreditCard>() { PaymentFeedDocBuilder.New().Build() },
                PaymentFeedsBoleto = new List<PaymentBoleto>() { new PaymentBoletoBuilder().Build() },
                CompanyCode = "TBRA",
                AffiliateCode = "0001",
                CityServiceCode = "",
                CityHallServiceDescription = "",
                SpecialProcedureNumber = "",
                TotalInvoicePrice = 100.00M,
                MunicipalTaxpayerRegistration = "77434",
                CycleCode = DateTime.UtcNow,
                Customer = CustomerBuilder.New().Build(),
                StoreAcronym = "telerese",
                Services = new List<ServiceInvoice>() { new ServiceInvoice(
                    Guid.NewGuid(),
                    "",
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    "",
                    "",
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    "",
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    "1 Year",
                    DateTime.UtcNow,
                    "",
                    "",
                    DateTime.UtcNow,
                    "",
                    "",
                    "",
                    "",
                    "",
                    15,
                    20,
                    25,
                    30,
                    40,
                    45,
                    50,
                    55,
                    60,
                    65,
                    70,
                    "",
                    "",
                    85,
                    90,
                    "",
                    95,
                    100,
                    105,
                    110,
                    120,
                    125,
                    130,
                    "",
                    135,
                    140,
                    150,
                    155,
                    160,
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    null,
                    2,
                    10.29m,
                    2,
                    50.29m,
                    2,
                    100.62m,
                    DateTime.UtcNow,
                    "",
                    "",
                    "",
                    10,
                    "Telefonica Brasil",
                    "007.455.987/01",
                    "telerese"
                 )}
            };
        }

        public InvoiceBuilder WithIdFile(Guid idFile)
        {
            IdFile = idFile;
            return this;
        }

        public InvoiceBuilder WithInvoiceNumber(string invoiceNumber)
        {
            InvoiceNumber = invoiceNumber;
            return this;
        }

        public InvoiceBuilder WithMarketplace(string marketplace)
        {
            Marketplace = marketplace;
            return this;
        }

        public InvoiceBuilder WithResellerName(string resellerName)
        {
            ResellerName = resellerName;
            return this;
        }

        public InvoiceBuilder WithResellerContactName(string resellerContactName)
        {
            ResellerContactName = resellerContactName;
            return this;
        }

        public InvoiceBuilder WithResellerEmailAddress(string resellerEmailAddress)
        {
            ResellerEmailAddress = resellerEmailAddress;
            return this;
        }

        public InvoiceBuilder WithResellerPhoneNumber(string resellerPhoneNumber)
        {
            ResellerPhoneNumber = resellerPhoneNumber;
            return this;
        }

        public InvoiceBuilder WithOrderId(string orderId)
        {
            OrderId = orderId;
            return this;
        }

        public InvoiceBuilder WithBillFrom(DateTime? billFrom)
        {
            BillFrom = billFrom;
            return this;
        }

        public InvoiceBuilder WithBillTo(DateTime? billTo)
        {
            BillTo = billTo;
            return this;
        }

        public InvoiceBuilder WithStoreCode(string storeCode)
        {
            StoreCode = storeCode;
            return this;
        }

        public InvoiceBuilder WithMarketplaceCity(string marketplaceCity)
        {
            MarketplaceCity = marketplaceCity;
            return this;
        }

        public InvoiceBuilder WithMarketplaceState(string marketplaceState)
        {
            MarketplaceState = marketplaceState;
            return this;
        }

        public InvoiceBuilder WithPremeditateddefaulter(string premeditateddefaulter)
        {
            Premeditateddefaulter = premeditateddefaulter;
            return this;
        }

        public InvoiceBuilder WithCustomerTransactionCurrency(string customerTransactionCurrency)
        {
            CustomerTransactionCurrency = customerTransactionCurrency;
            return this;
        }

        public InvoiceBuilder WithPaymentMethod(string paymentMethod)
        {
            PaymentMethod = paymentMethod;
            return this;
        }

        public InvoiceBuilder WithPaymentStatus(string paymentStatus)
        {
            PaymentStatus = paymentStatus;
            return this;
        }

        public InvoiceBuilder WithRefundType(string refundType)
        {
            RefundType = refundType;
            return this;
        }

        public InvoiceBuilder WithRefundAmount(string refundAmount)
        {
            RefundAmount = refundAmount;
            return this;
        }

        public InvoiceBuilder WithInvoiceStatus(string invoiceStatus)
        {
            InvoiceStatus = invoiceStatus;
            return this;
        }

        public InvoiceBuilder WithCompanyCode(string companycode)
        {
            CompanyCode = companycode;
            return this;
        }

        public InvoiceBuilder WithAffiliateCode(string affiliatecode)
        {
            AffiliateCode = affiliatecode;
            return this;
        }

        public InvoiceBuilder WithCityServiceCode(string cityservicecode)
        {
            CityServiceCode = cityservicecode;
            return this;
        }

        public InvoiceBuilder WithCityHallServiceDescription(string ctyhallservicedescription)
        {
            CityHallServiceDescription = ctyhallservicedescription;
            return this;
        }

        public InvoiceBuilder WithSpecialProcedureNumber(string specialprocedurenumber)
        {
            SpecialProcedureNumber = specialprocedurenumber;
            return this;
        }

        public InvoiceBuilder WithServices(List<ServiceInvoice> serviceInvoices)
        {
            Services = serviceInvoices;
            return this;
        }

        public InvoiceBuilder WithTotalInvoicePrice(decimal? totalinvoiceprice)
        {
            TotalInvoicePrice = totalinvoiceprice;
            return this;
        }

        public InvoiceBuilder WithMunicipalTaxpayerRegistration(string municipaltaxpayerregistration)
        {
            MunicipalTaxpayerRegistration = municipaltaxpayerregistration;
            return this;
        }

        public InvoiceBuilder WithCustomer(Customer customer)
        {
            Customer = customer;
            return this;
        }

        public InvoiceBuilder WithCustomer(decimal? totalinvoiceprice)
        {
            TotalInvoicePrice = totalinvoiceprice;
            return this;
        }

        public InvoiceBuilder WithCycleCode(DateTime? cycleCode)
        {
            CycleCode = cycleCode;
            return this;
        }

        public InvoiceBuilder WithStoreAcronym(string storeAcronym)
        {
            StoreAcronym = storeAcronym;
            return this;
        }

        public Invoice Build()
        {
            var invoice = new Invoice(IdFile, InvoiceNumber, Marketplace, ResellerName, ResellerContactName, ResellerEmailAddress, ResellerPhoneNumber,
                OrderId, BillFrom, BillTo, InvoiceCreationDate, StoreCode, MarketplaceCity, MarketplaceState, Premeditateddefaulter,
                CustomerTransactionCurrency, PaymentMethod, PaymentStatus, RefundType, RefundAmount, InvoiceStatus, Customer, Services, CompanyCode, AffiliateCode, CityServiceCode,
                CityHallServiceDescription, SpecialProcedureNumber, TotalInvoicePrice, MunicipalTaxpayerRegistration, CycleCode, StoreAcronym);

            invoice.PaymentFeedsCredit = PaymentFeedDocs;
            invoice.PaymentFeedsBoleto = PaymentFeedsBoleto;

            return invoice;
        }
    }
}
