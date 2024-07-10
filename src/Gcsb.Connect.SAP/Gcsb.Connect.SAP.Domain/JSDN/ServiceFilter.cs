using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;

namespace Gcsb.Connect.SAP.Domain.JSDN
{
    public class ServiceFilter
    {
        public decimal? GrossRetailPrice { get; set; }
        public decimal? TotalRetailPriceDiscountAmount { get; set; }
        public string TaxCodeISS { get; set; }
        public decimal? TaxRateISS { get; set; }
        public decimal? TaxRatePIS { get; set; }
        public decimal? TotalRetailTaxPIS { get; set; }
        public decimal? TaxRateCOFINS { get; set; }
        public decimal? TotalRetailTaxCOFINS { get; set; }
        public Domain.Config.FinancialAccount Account { get; set; } /*TODO: DELETE*/        
        public Invoice Invoice { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string StoreAcronym { get; set; }
        public string ProviderCompanyAcronym { get; set; }
        public DateTime? DueDate { get; set; }
        public double? Qty { get; set; }
        public decimal TotalTaxISS { get; set; }
        public decimal TotalTaxPIS { get; set; }
        public decimal TotalTaxCOFINS { get; set; }
        public double? RetailUnitPrice { get; set; }
        public double? GrandTotalRetailPrice { get; set; }
        public string ServiceType { get; set; }
        public DateTime? CycleReference { get; set; }
        public decimal? TotalRetailPriceWithTaxesWithoutDiscount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public string Receivable { get; set; }
        public string InvoiceNumber { get; set; }

        public ServiceFilter() { }

        public ServiceFilter(double? grandTotalRetailPrice, decimal? grossRetailPrice, decimal? totalRetailPriceDiscountAmount, decimal? totalDiscount, Invoice invoice, string serviceCode, string serviceType, string storeAcronym, string providerCompanyAcronym, string receivable)
        {
            this.GrandTotalRetailPrice = grandTotalRetailPrice;
            this.GrossRetailPrice = grossRetailPrice;
            this.TotalRetailPriceDiscountAmount = totalRetailPriceDiscountAmount; 
            this.TotalDiscount = totalDiscount;
            this.Invoice = invoice;
            this.ServiceCode = serviceCode;
            this.ServiceType = serviceType;
            this.StoreAcronym = storeAcronym;
            this.ProviderCompanyAcronym = providerCompanyAcronym;
            this.Receivable = receivable;
        }

        public decimal GetLaunchAmount(bool isDescont, bool isRound = true)
        {
            var grandTotalRetailPrice = Convert.ToDecimal(GrandTotalRetailPrice);
            var totalRetailPriceWithTaxesWithoutDiscount = Convert.ToDecimal(TotalRetailPriceWithTaxesWithoutDiscount);
            if (isDescont)
            {
                if (ServiceType.ToUpper() == "SAAS")
                    return isRound ?
                        Math.Abs(Math.Round(TotalRetailPriceDiscountAmount.Value, 2)) :
                        Math.Abs(TotalRetailPriceDiscountAmount.Value);
                else
                    return isRound ?
                        Math.Abs(Math.Round(grandTotalRetailPrice - totalRetailPriceWithTaxesWithoutDiscount, 2)) :
                        Math.Abs(grandTotalRetailPrice - totalRetailPriceWithTaxesWithoutDiscount);
            }
            else
            {
                var discount = GetLaunchAmount(true, true);
                return isRound ? Math.Abs(Math.Round(grandTotalRetailPrice + discount, 2)) :
                     Math.Abs(grandTotalRetailPrice + discount);
            }
        }
    }
}
