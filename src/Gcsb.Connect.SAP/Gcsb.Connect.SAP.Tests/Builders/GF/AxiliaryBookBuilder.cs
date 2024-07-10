using Gcsb.Connect.SAP.Domain.GF;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.GF
{
    public partial class AxiliaryBookBuilder
    {
        public string CompanyCode;
        public string AffiliateCode;
        public string CustomerCode;
        public DateTime DateInvoiceClosing;
        public string FinancialAccount;
        public string InvoiceNumber;      
        public DateTime DateEmissNF;
        public DateTime DateVencNF;
        public decimal TotalInvoicePrice;
        public string DcliNumArq;
        public decimal DcliValDocto;     
       
        public DateTime CycleBilling;

        public static AxiliaryBookBuilder New()
        {
            return new AxiliaryBookBuilder
            {
                CompanyCode = "TBRA",
                AffiliateCode = "9141",
                CustomerCode = "00000000123456",
                DateInvoiceClosing = DateTime.UtcNow,
                FinancialAccount = "FATCONTACONTABILCREDIT00001",
                InvoiceNumber = "VL-1-00012123",
                DateEmissNF = DateTime.UtcNow,
                DateVencNF = DateTime.UtcNow,
                TotalInvoicePrice = 123456.88M,
                DcliNumArq = "788",
                DcliValDocto = 123456.88M,             
                CycleBilling = DateTime.Now.AddMonths(-1)
            };
        }

        public AxiliaryBookBuilder WithCompanyCode(string companyCode)
        {
            CompanyCode = companyCode;
            return this;
        }

        public AxiliaryBookBuilder WithAffiliateCode(string affiliateCode)
        {
            AffiliateCode = affiliateCode;
            return this;
        }

        public AxiliaryBookBuilder WithCustomerCode(string customerCode)
        {
            CustomerCode = customerCode;
            return this;
        }

        public AxiliaryBookBuilder WithDateInvoiceClosing(System.DateTime dateInvoiceClosing)
        {
            DateInvoiceClosing = dateInvoiceClosing;
            return this;
        }

        public AxiliaryBookBuilder WithFinancialAccount(string financialAccount)
        {
            FinancialAccount = financialAccount;
            return this;
        }

        public AxiliaryBookBuilder WithInvoiceNumber(string invoiceNumber)
        {
            InvoiceNumber = invoiceNumber;
            return this;
        }   

        public AxiliaryBookBuilder WithDateEmissNF(DateTime dateEmissNF)
        {
            DateEmissNF = dateEmissNF;
            return this;
        }

        public AxiliaryBookBuilder WithDateVencNF(DateTime dateVencNF)
        {
            DateVencNF = dateVencNF;
            return this;
        }

        public AxiliaryBookBuilder WithTotalInvoicePrice(decimal totalInvoicePrice)
        {
            TotalInvoicePrice = totalInvoicePrice;
            return this;
        }

        public AxiliaryBookBuilder WithDcliNumArq(string dclinumarq)
        {
            DcliNumArq = dclinumarq;
            return this;
        }

        public AxiliaryBookBuilder WithDcliValDocto(decimal dclivaldocto)
        {
            DcliValDocto = dclivaldocto;
            return this;
        }       

        public AxiliaryBook Build()
             => new AxiliaryBook(CompanyCode, AffiliateCode, CustomerCode, DateInvoiceClosing, FinancialAccount, InvoiceNumber,DateEmissNF, DateVencNF, TotalInvoicePrice,
            DcliNumArq, DcliValDocto,CycleBilling);

    }
}
