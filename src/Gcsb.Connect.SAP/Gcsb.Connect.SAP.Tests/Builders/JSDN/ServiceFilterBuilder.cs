using Gcsb.Connect.SAP.Domain.Config;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;

namespace Gcsb.Connect.SAP.Tests.Builders.JSDN
{
    public class ServiceFilterBuilder
    {
        public double? GrandTotalRetailPrice;
        public decimal? GrossRetailPrice;
        public decimal? TotalRetailPriceDiscountAmount;
        public decimal? TotalDiscount;
        public Domain.JSDN.BillFeedSplit.Invoice Invoice;
        public string ServiceCode;
        public string ServiceType;
        public string StoreAcronym;
        public string ProviderCompanyAcronym;
        public string Receivable;

        public static ServiceFilterBuilder New()
        {
            return new ServiceFilterBuilder()
            {
                GrandTotalRetailPrice = 90,
                GrossRetailPrice = 10.0m,
                TotalRetailPriceDiscountAmount = 5.0m,
                TotalDiscount = 10,
                Invoice = InvoiceBuilder.New().Build(),                
                ServiceCode = "",
                ServiceType = "SaaS",
                StoreAcronym = "",
                ProviderCompanyAcronym = "",                
                Receivable = "SPIAASTBRAC"
            };
        }

        public ServiceFilterBuilder WithGrossRetailPrice(decimal? grossretailprice)
        {
            GrossRetailPrice = grossretailprice;
            return this;
        }

        public ServiceFilterBuilder WithGrandTotalRetailPrice(double? grandTotalRetailPrice)
        {
            GrandTotalRetailPrice = grandTotalRetailPrice;
            return this;
        }

        public ServiceFilterBuilder WithTotalRetailPriceDiscountAmount(decimal? totalretailpricediscountamount)
        {
            TotalRetailPriceDiscountAmount = totalretailpricediscountamount;
            return this;
        }

        public ServiceFilterBuilder WithTotalDiscount(decimal? totalDiscount)
        {
            TotalDiscount = totalDiscount;
            return this;
        }

        public ServiceFilterBuilder WithInvoice(Domain.JSDN.BillFeedSplit.Invoice invoice)
        {
            Invoice = invoice;
            return this;
        }

        public ServiceFilterBuilder WithServiceCode(string servicecode)
        {
            ServiceCode = servicecode;
            return this;
        }

        public ServiceFilterBuilder WithServiceType(string servicetype)
        {
            ServiceType = servicetype;
            return this;
        }

        public ServiceFilterBuilder WithStoreAcronym(string storeAcronym)
        {
            StoreAcronym = storeAcronym;
            return this;
        }

        public ServiceFilterBuilder WithProviderCompanyAcronym(string providerCompanyAcronym)
        {
            ProviderCompanyAcronym = providerCompanyAcronym;
            return this;
        }

        public ServiceFilterBuilder WithReceivable(string receivable)
        {
            Receivable = receivable;
            return this;
        }

        public ServiceFilter Build()
            => new ServiceFilter(GrandTotalRetailPrice, GrossRetailPrice, TotalRetailPriceDiscountAmount, TotalDiscount, Invoice, ServiceCode, ServiceType, StoreAcronym, ProviderCompanyAcronym, Receivable);
    }
}
