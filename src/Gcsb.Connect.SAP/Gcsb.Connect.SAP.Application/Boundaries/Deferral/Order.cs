using System;

namespace Gcsb.Connect.SAP.Application.Boundaries.Deferral
{
    public class Order
    {
        public string OrderId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string ServiceCode { get; private set; }
        public string OfferCode { get; private set; }
        public string ServiceType { get; private set; }
        public string PaymentMethod { get; private set; }
        public string CustomerCode { get; private set; }
        public double TotalOrderPrice { get; private set; }
        public string StoreAcronym { get; private set; }
        public string StoreAcronymServiceProvider { get; private set; }
        public string BillingStateOrProvince { get; private set; }

        public Order(string orderId, DateTime orderDate, string serviceCode, string offerCode, string serviceType, string paymentMethod, string customerCode, double totalOrderPrice, string storeAcronym, string storeAcronymServiceProvider, string billingStateOrProvince)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            ServiceCode = serviceCode;
            OfferCode = offerCode;
            ServiceType = serviceType;
            PaymentMethod = paymentMethod;
            CustomerCode = customerCode;
            TotalOrderPrice = totalOrderPrice;
            StoreAcronym = storeAcronym;
            StoreAcronymServiceProvider = storeAcronymServiceProvider;
            BillingStateOrProvince = billingStateOrProvince;
        }
    }
}
