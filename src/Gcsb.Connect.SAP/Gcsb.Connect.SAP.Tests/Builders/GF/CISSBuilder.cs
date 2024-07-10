using Gcsb.Connect.SAP.Domain.GF;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.GF
{
    public class CISSBuilder
    {
        public CISSBuilder()
        {
            Defaults();
        }

        public string CompanyCode;
        public string AffiliateCode;
        public string NFFSeries;
        public int NFFNumber;
        public DateTime NFFEmissionDate;
        public int NFFSequenceItem;
        public decimal GrossRetailPrice;
        public int GrossRetailPriceInt;
        public decimal TaxPisPercentual;
        public decimal TaxPisTotalValue;
        public decimal TaxCofinsPercentual;
        public decimal TaxCofinsTotalValue;
        public int TaxCofinsTotalValueInt;
        public DateTime CycleDate;
        public string InvoiceNumber;
        public string ServiceCode;

        public CISSBuilder WithCompanyCode(string companycode)
        {
            CompanyCode = companycode;
            return this;
        }

        public CISSBuilder WithAffiliateCode(string affiliatecode)
        {
            AffiliateCode = affiliatecode;
            return this;
        }

        public CISSBuilder WithNFFSeries(string nffseries)
        {
            NFFSeries = nffseries;
            return this;
        }

        public CISSBuilder WithNFFNumber(int nffnumber)
        {
            NFFNumber = nffnumber;
            return this;
        }

        public CISSBuilder WithNFFEmissionDate(DateTime nffemissiondate)
        {
            NFFEmissionDate = nffemissiondate;
            return this;
        }

        public CISSBuilder WithNFFSequenceItem(int nffsequenceitem)
        {
            NFFSequenceItem = nffsequenceitem;
            return this;
        }

        public CISSBuilder WithGrossRetailPrice(decimal grossretailprice)
        {
            GrossRetailPrice = grossretailprice;
            return this;
        }

        public CISSBuilder WithTaxPisPercentual(decimal taxpispercentual)
        {
            TaxPisPercentual = taxpispercentual;
            return this;
        }

        public CISSBuilder WithTaxPisTotalValue(decimal taxpistotalvalue)
        {
            TaxPisTotalValue = taxpistotalvalue;
            return this;
        }
        
        public CISSBuilder WithTaxCofinsPercentual(decimal taxcofinspercentual)
        {
            TaxCofinsPercentual = taxcofinspercentual;
            return this;
        }
        
        public CISSBuilder WithTaxCofinsTotalValue(decimal taxcofinstotalvalue)
        {
            TaxCofinsTotalValue = taxcofinstotalvalue;
            return this;
        }

        public CISSBuilder WithCycleDate(DateTime cycledate)
        {
            CycleDate = cycledate;
            return this;
        }

        public CISSBuilder WithInvoiceNumber(string invoicenumber)
        {
            InvoiceNumber = invoicenumber;
            return this;
        }

        public CISSBuilder WithServiceCode(string servicecode)
        {
            ServiceCode = servicecode;
            return this;
        }

        public CISS Build()
            => new CISS(CompanyCode, AffiliateCode, NFFNumber, NFFEmissionDate, NFFSequenceItem, GrossRetailPrice, TaxPisPercentual, TaxPisTotalValue, TaxCofinsPercentual, TaxCofinsTotalValue,
                CycleDate, InvoiceNumber, ServiceCode);

        public void Defaults()
        {
            CompanyCode = "TBRA";
            AffiliateCode = "9640";
            NFFNumber = 250;
            NFFEmissionDate = DateTime.UtcNow;
            NFFSequenceItem = 1;
            GrossRetailPrice = 1000m;
            TaxPisPercentual = 2m;
            TaxPisTotalValue = 100m;
            TaxCofinsPercentual = 7.5m;
            TaxCofinsTotalValue = 1000m;
            CycleDate = DateTime.UtcNow.AddMonths(-1);
            InvoiceNumber = "INV-00001";
            ServiceCode = "1.03";
        }
    }
}
