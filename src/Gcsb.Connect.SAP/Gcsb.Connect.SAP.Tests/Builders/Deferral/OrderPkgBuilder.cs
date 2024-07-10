using System;
using Gcsb.Connect.SAP.Application.Boundaries.Deferral;

namespace Gcsb.Connect.SAP.Tests.Builders.Deferral
{
    public class OrderPkgBuilder
    {
        public string OrderId;
        public DateTime OrderDate;
        public string ServiceCode;
        public string OfferCode;
        public string ServiceType;
        public string PaymentMethod;
        public string CustomerCode;
        public double TotalOrderPrice;
        public string StoreAcronym;
        public string StoreAcronymServiceProvider;
        public string BillingStateOrProvince;

        public static OrderPkgBuilder New()
        {
            return new OrderPkgBuilder()
            {
                OrderId = "4015480",
                OrderDate = DateTime.Now,
                ServiceCode = "Office365EnterpriseE1",
                OfferCode = "Office365EnterpriseE1_offer",
                ServiceType = "SAAS",
                PaymentMethod = "Boleto",
                CustomerCode = "4018953",
                TotalOrderPrice = 32.99,
                StoreAcronym = "telerese",
                StoreAcronymServiceProvider = "cloudco",
                BillingStateOrProvince = "SP"
            };
        }

        public OrderPkgBuilder SetOrderId(string orderId)
        {
            OrderId = orderId;
            return this;
        }

        public OrderPkgBuilder SetOrderDate(DateTime orderDate)
        {
            OrderDate = orderDate;
            return this;
        }

        public OrderPkgBuilder SetServiceCode(string serviceCode)
        {
            ServiceCode = serviceCode;
            return this;
        }

        public OrderPkgBuilder SetOfferCode(string offerCode)
        {
            OfferCode = offerCode;
            return this;
        }

        public OrderPkgBuilder SetServiceType(string serviceType)
        {
            ServiceType = serviceType;
            return this;
        }

        public OrderPkgBuilder SetPaymentMethod(string paymentMethod)
        {
            PaymentMethod = paymentMethod;
            return this;
        }

        public OrderPkgBuilder SetCustomerCode(string customerCode)
        {
            CustomerCode = customerCode;
            return this;
        }

        public OrderPkgBuilder SetTotalOrderPrice(double totalOrderPrice)
        {
            TotalOrderPrice = totalOrderPrice;
            return this;
        }

        public OrderPkgBuilder SetStoreAcronym(string storeAcronym)
        {
            StoreAcronym = storeAcronym;
            return this;
        }

        public OrderPkgBuilder SetStoreAcronymServiceProvider(string storeAcronymServiceProvider)
        {
            StoreAcronymServiceProvider = storeAcronymServiceProvider;
            return this;
        }

        public OrderPkgBuilder SetBillingStateOrProvince(string billingStateOrProvince)
        {
            BillingStateOrProvince = billingStateOrProvince;
            return this;
        }

        public Order Build()
            => new Order(
                OrderId,
                OrderDate,
                ServiceCode,
                OfferCode,
                ServiceType,
                PaymentMethod,
                CustomerCode,
                TotalOrderPrice,
                StoreAcronym,
                StoreAcronymServiceProvider,
                BillingStateOrProvince);
    }

}
