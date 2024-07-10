using Gcsb.Connect.SAP.Tests.Builders.GF;
using System;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.GF
{
    public class ReturnNFDomainTests
    {
        #region Create Domain
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreate()
        {
            var model = new ReturnNFBuilder().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region REQUIREDS AND MAXLENGTH
        #endregion

        #region REQUIREDS

        [Theory]
        [Trait("Action", "None")]
        [InlineData(null)]
        [InlineData("")]
        public void TestRequiredNullReferencia(System.String invoiceID)
        {
            var model = new ReturnNFBuilder().WithInvoiceID(invoiceID).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullNumeroNF(System.String value)
        {
            var model = new ReturnNFBuilder().WithNumeroNF(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullSerieNF(System.String value)
        {
            var model = new ReturnNFBuilder().WithSerieNF(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullNFCancelada(System.String value)
        {
            var model = new ReturnNFBuilder().WithNFCancelada(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullChaveNF(System.String value)
        {
            var model = new ReturnNFBuilder().WithChaveNF(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion

        #region MAX LENGTH
        #endregion
    }
}
