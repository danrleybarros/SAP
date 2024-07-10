using Gcsb.Connect.SAP.Tests.Builders.GF;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.GF
{
    public class MasterDomainTests
    {
        #region Create Domain

        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreate()
        {
            var model = new MasterBuilder().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #endregion

        #region REQUIREDS AND MAXLENGTH
        [Theory]
        [InlineData("AAAAAAAAAA")]
        [InlineData(null)]
        [InlineData("")]
        public void TestRequiredAndMaxLengthCompanyCode(System.String value)
        {
            var model = new MasterBuilder().WithCompanyCode(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        
        
        [Theory]
        [InlineData("AA")]
        [InlineData(null)]
        [InlineData("")]
        public void TestRequiredAndMaxLengthCancelNF(System.String value)
        {
            var model = new MasterBuilder().WithCancelNF(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion

        #region Tests With Constants

        [Theory]
        [InlineData("NFS", "@", "CL", 0, "Vivo Plataforma Digital", "", 0,"1")]
        public void ShouldMatchConstantsMasterDomain(string nfs, string infssSerie, string catgCod, decimal totalRetailPriceDiscount, string var05, string chaveNF, int mnfssTipPag, string affiliateCode)
        {
            var model = new MasterBuilder().Build();

            Assert.Equal(nfs, model.Nfs);
            Assert.Equal(infssSerie, model.InfssSerie);
            Assert.Equal(catgCod, model.CatgCod);
            Assert.Equal(totalRetailPriceDiscount, model.TotalRetailPriceDiscount);
            Assert.Equal(var05, model.Var05);
            Assert.Equal(chaveNF, model.ChaveNF);
            Assert.Equal(mnfssTipPag, model.MnfssTipPag);
            Assert.Equal(affiliateCode, model.AffiliateCode);
        }

        #endregion
    }
}
