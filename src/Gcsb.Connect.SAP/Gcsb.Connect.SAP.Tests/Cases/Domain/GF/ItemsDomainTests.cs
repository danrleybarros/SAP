using Gcsb.Connect.SAP.Tests.Builders.GF;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.GF
{
    public class ItemsDomainTests
    {
        #region Create Domain

        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreate()
        {
            var model = new ItemsBuilder().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #endregion

        #region Required and MaxLength

        [Theory]
        [InlineData("AAAAAAAAAA")]
        [InlineData(null)]
        [InlineData("")]
        public void TestRequiredAndMaxLengthCompanyCode(string value)
        {
            var model = new ItemsBuilder().WithCompanyCode(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("AAAAAAAAAA")]
        [InlineData(null)]
        [InlineData("")]
        public void TestRequiredAndMaxLengthAffiliateCode(string value)
        {
            var model = new ItemsBuilder().WithAffiliateCode(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("AAAAAAAAAAAAAAAAA")]
        public void TestMaxLengthCadgCod(string value)
        {
            var model = new ItemsBuilder().WithCadgCod(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("AAAAAAAAAAAAAAAAAAAAAAAAAAAAA")]
        public void TestMaxLengthAccountingAccount(string value)
        {
            var model = new ItemsBuilder().WithAccountingAccount(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion

        #region Tests With Constants

        [Theory]
        [Trait("Action", "None")]
        [InlineData("NFS", "@", "CL", "29TR018233", "00", "13", "Vivo Plataforma Digital", "Processamento,armaz. ou hosped. de dados, textos, imagens, videos, paginas eletronicas, apps e sist. de info., entre outros formatos e congeneres", "1.03", 0, "1.03", "41431077")]
        public void ShouldMatchConstantsItemsDomain(string tdoc_cod, string infss_serie, string catg_cod, string ccus_cod, string infss_cst_iss, string tp_loc, string var05, string serviceName, 
            string serviceCode, decimal totalRetailPriceDiscount, string cslcCodLst, string pconCodConta)
        {
            var model = new ItemsBuilder().Build();

            Assert.Equal(tdoc_cod, model.Nfs);
            Assert.Equal(infss_serie, model.InfssSerie);
            Assert.Equal(catg_cod, model.CatgCod);
            Assert.Equal(ccus_cod, model.CostCenter);
            Assert.Equal(infss_cst_iss, model.FullyTaxed);
            Assert.Equal(tp_loc, model.TpLoc);
            Assert.Equal(var05, model.Var05);
            Assert.Equal(serviceName, model.ServiceName);
            Assert.Equal(serviceCode, model.ServiceCode);
            Assert.Equal(totalRetailPriceDiscount, model.TotalRetailPriceDiscount);
            Assert.Equal(cslcCodLst, model.CslcCodLst);
            Assert.Equal(pconCodConta, model.PconCodConta);
        }

        #endregion
    }
}