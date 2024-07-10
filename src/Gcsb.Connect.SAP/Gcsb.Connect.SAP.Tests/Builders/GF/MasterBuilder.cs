using System;

namespace Gcsb.Connect.SAP.Tests.Builders.GF
{
    public partial class MasterBuilder : Builder<Gcsb.Connect.SAP.Domain.GF.Master>
    {
        public MasterBuilder()
        {
            Defaults();
        }

        #region Properties

        public System.String CompanyCode;
        public System.String AffiliateCode;
        public System.String Nfs;
        public System.String InfssSerie;
        public System.Int32 NumberNotaFiscal;
        public System.DateTime IssueDate;
        public System.String CatgCod;
        public System.String CadgCod;
        public System.Decimal TotalInvoicePrice;
        public System.String CancelNF;
        public System.String Var05;
        public System.String FileName;
        public System.Double GrandTotalRetailPrice;
        public System.String ChaveNF;
        public System.DateTime CycleFatDate;

        #endregion

        #region With Methods

        public MasterBuilder WithCompanyCode(System.String companycode)
        {
            CompanyCode = companycode;
            return this;
        }

        public MasterBuilder WithAffiliateCode(System.String affiliatecode)
        {
            AffiliateCode = affiliatecode;
            return this;
        }

        public MasterBuilder WithNfs(System.String nfs)
        {
            Nfs = nfs;
            return this;
        }

        public MasterBuilder WithInfssSerie(System.String infssserie)
        {
            InfssSerie = infssserie;
            return this;
        }

        public MasterBuilder WithNumberNotaFiscal(System.Int32 numbernotafiscal)
        {
            NumberNotaFiscal = numbernotafiscal;
            return this;
        }

        public MasterBuilder WithIssueDate(System.DateTime issuedate)
        {
            IssueDate = issuedate;
            return this;
        }

        public MasterBuilder WithCatgCod(System.String catgcod)
        {
            CatgCod = catgcod;
            return this;
        }

        public MasterBuilder WithCadgCod(System.String cadgcod)
        {
            CadgCod = cadgcod;
            return this;
        }

        public MasterBuilder WithTotalInvoicePrice(System.Decimal totalinvoiceprice)
        {
            TotalInvoicePrice = totalinvoiceprice;
            return this;
        }

        public MasterBuilder WithCancelNF(System.String cancelnf)
        {
            CancelNF = cancelnf;
            return this;
        }

        public MasterBuilder WithVar05(System.String var05)
        {
            Var05 = var05;
            return this;
        }

        public MasterBuilder WithFileName(System.String filename)
        {
            FileName = filename;
            return this;
        }
        
        public MasterBuilder WithGrandTotalRetailPrice(System.Double grandTotalRetailPrice)
        {
            GrandTotalRetailPrice = grandTotalRetailPrice;
            return this;
        }

        public MasterBuilder WithChaveNF(System.String chaveNF)
        {
            ChaveNF = chaveNF;
            return this;
        }

        public MasterBuilder WithCycleFatDate(System.DateTime cycleFatDate)
        {
            CycleFatDate = cycleFatDate;
            return this;
        }
        #endregion

        #region Build
        public new Gcsb.Connect.SAP.Domain.GF.Master Build()
        {
            return new Domain.GF.Master(
                        CompanyCode,                      
                        NumberNotaFiscal,
                        IssueDate,
                        CatgCod,
                        TotalInvoicePrice,
                        CancelNF,
                        GrandTotalRetailPrice,
                        CycleFatDate);
        }
        #endregion

        #region Default Methods 
        public new void Defaults()
        {
            /*** maxlength : 9 ****/
            CompanyCode = "AAAAAAAAA";
            /*** maxlength : 9 ****/
            AffiliateCode = "AAAAAAAAA";
            /*** maxlength : 3 ****/
            Nfs = "AAA";
            /*** maxlength : 5 ****/
            InfssSerie = "AAAAA";
            NumberNotaFiscal = 1;
            IssueDate = DateTime.UtcNow;
            /*** maxlength : 2 ****/
            CatgCod = "AA";
            /*** maxlength : 16 ****/
            CadgCod = "AAAAAAAAAAAAAAAA";
            /*** maxlength : 1 ****/
            CancelNF = "A";
            /*** maxlength : 150 ****/
            Var05 = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            GrandTotalRetailPrice = 1;
            /*** maxlength : 60 ****/
            ChaveNF = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            CycleFatDate = DateTime.UtcNow;
        }
        #endregion
    }
}
