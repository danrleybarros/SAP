using System;

namespace Gcsb.Connect.SAP.Tests.Builders.GF
{
    public class ItemsBuilder
    {
        public ItemsBuilder()
        {
            Defaults();
        }

        public string CompanyCode;
        public string AffiliateCode;
        public string Nfs;
        public string InfssSerie;
        public int NumberNotaFiscal;
        public DateTime IssueDate;
        public string CatgCod;
        public string CadgCod;
        public string AccountingAccount;
        public string CostCenter;
        public double RetailUnitPrice;
        public string FullyTaxed;
        public decimal PercentualISS;
        public double GrandTotalRetailPrice;
        public decimal TotalInvoicePrice;
        public decimal TotalTaxISSCode;
        public int SequentialNumberNote;
        public string TpLoc;
        public string IbgeCod;
        public string Var05;
        public DateTime CycleFatDate;

        public ItemsBuilder WithCompanyCode(string companycode)
        {
            CompanyCode = companycode;
            return this;
        }

        public ItemsBuilder WithAffiliateCode(string affiliatecode)
        {
            AffiliateCode = affiliatecode;
            return this;
        }

        public ItemsBuilder WithNfs(string nfs)
        {
            Nfs = nfs;
            return this;
        }

        public ItemsBuilder WithInfssSerie(string infssserie)
        {
            InfssSerie = infssserie;
            return this;
        }

        public ItemsBuilder WithNumberNotaFiscal(int numbernotafiscal)
        {
            NumberNotaFiscal = numbernotafiscal;
            return this;
        }

        public ItemsBuilder WithIssueDate(DateTime issuedate)
        {
            IssueDate = issuedate;
            return this;
        }

        public ItemsBuilder WithCatgCod(string catgcod)
        {
            CatgCod = catgcod;
            return this;
        }

        public ItemsBuilder WithCadgCod(string cadgcod)
        {
            CadgCod = cadgcod;
            return this;
        }

        public ItemsBuilder WithAccountingAccount(string accountingaccount)
        {
            AccountingAccount = accountingaccount;
            return this;
        }

        public ItemsBuilder WithCostCenter(string costcenter)
        {
            CostCenter = costcenter;
            return this;
        }

        public ItemsBuilder WithRetailUnitPrice(double retailunitprice)
        {
            RetailUnitPrice = retailunitprice;
            return this;
        }

        public ItemsBuilder WithFullyTaxed(string fullytaxed)
        {
            FullyTaxed = fullytaxed;
            return this;
        }

        public ItemsBuilder WithPercentualISS(decimal percentualiss)
        {
            PercentualISS = percentualiss;
            return this;
        }

        public ItemsBuilder WithGrossRetailPrice(double grossretailprice)
        {
            GrandTotalRetailPrice = grossretailprice;
            return this;
        }

        public ItemsBuilder WithTotalInvoicePrice(decimal totalinvoiceprice)
        {
            TotalInvoicePrice = totalinvoiceprice;
            return this;
        }

        public ItemsBuilder WithSequentialNumberNote(int sequentialnumbernote)
        {
            SequentialNumberNote = sequentialnumbernote;
            return this;
        }

        public ItemsBuilder WithTpLoc(string tploc)
        {
            TpLoc = tploc;
            return this;
        }

        public ItemsBuilder WithIbgeCod(string ibgecod)
        {
            IbgeCod = ibgecod;
            return this;
        }

        public ItemsBuilder WithVar05(string var05)
        {
            Var05 = var05;
            return this;
        }

        public ItemsBuilder WithCycleFatDate(DateTime cycleFatDate)
        {
            CycleFatDate = cycleFatDate;
            return this;
        }

        public ItemsBuilder WithTotalTaxISSCode(decimal totalTaxISSCode)
        {
            TotalTaxISSCode = totalTaxISSCode;
            return this;
        }

        public Domain.GF.Items Build()
            => new Domain.GF.Items(CompanyCode, AffiliateCode, NumberNotaFiscal, IssueDate, CadgCod, AccountingAccount, RetailUnitPrice, PercentualISS, GrandTotalRetailPrice, TotalTaxISSCode, TotalInvoicePrice, 
                SequentialNumberNote, IbgeCod, CycleFatDate);

        public void Defaults()
        {
            CompanyCode = "TBRA";
            AffiliateCode = "0001";
            NumberNotaFiscal = 3779;
            IssueDate = DateTime.UtcNow;
            CadgCod = "123456";
            AccountingAccount = "";
            RetailUnitPrice = 100.59;
            PercentualISS = 2.00m;
            GrandTotalRetailPrice = 100.59;
            TotalTaxISSCode = 1.135m;
            TotalInvoicePrice = 56.75m;
            SequentialNumberNote = 1;
            IbgeCod = "1234567";
            CycleFatDate = new DateTime(2019, 04, 15);
        }
    }
}
