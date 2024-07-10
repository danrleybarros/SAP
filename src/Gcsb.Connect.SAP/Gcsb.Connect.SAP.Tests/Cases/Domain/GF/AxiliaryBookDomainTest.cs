using Gcsb.Connect.SAP.Tests.Builders.GF;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.GF
{
    public class AxiliaryBookDomainTest
    {
        #region Create Test 
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateDomain()
        {
            var model = AxiliaryBookBuilder.New().Build();

            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region Null Or Empty Tests
        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateEmpsCodNullOrEmpty(string valor)
        {
            var model = AxiliaryBookBuilder.New().WithCompanyCode(valor).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateFiliCodNullOrEmpty(string valor)
        {
            var model = AxiliaryBookBuilder.New().WithAffiliateCode(valor).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateCadgCodNullOrEmpty(string valor)
        {
            var model = AxiliaryBookBuilder.New().WithCustomerCode(valor).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreatePconCodContaNullOrEmpty(string valor)
        {
            var model = AxiliaryBookBuilder.New().WithFinancialAccount(valor).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);

        }


        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateDcliNumDocNullOrEmpty(string valor)
        {
            var model = AxiliaryBookBuilder.New().WithInvoiceNumber(valor).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        #endregion

        #region Constants Tests and Formats

        [Theory]
        [InlineData("CL", "Fatura", "NFS", "D")]
        public void ShouldValueConstants(string catgCod, string topeCod, string tdocCod, string dcliIndLancto)
        {
            var model = AxiliaryBookBuilder.New().Build();

            Assert.True(model.CatgCod == catgCod);
            Assert.True(model.TypeOperation == topeCod);
            Assert.True(model.TdocCod == tdocCod);
            Assert.True(model.DcliIndLancto == dcliIndLancto);
        }


        [Theory]
        [InlineData("{0:yyyyMMdd}", "{0:000000000000000}")]
        public void ShouldFormatConstantsMatch(string formatDate, string sequence)
        {
            var model = AxiliaryBookBuilder.New().Build();
            var arrConst = model.GetConstantsValues();
            Assert.True(arrConst[0] == formatDate);
            Assert.True(arrConst[1] == sequence);
        }
        #endregion

        #region Test DateTime Value Default

        [Fact]
        public void ShouldNotCreateDcliDatLanctoWithDefaultValue()
        {
            var model = AxiliaryBookBuilder.New().WithDateInvoiceClosing(DateTime.MinValue.Date).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void ShouldNotCreateDcliDatEmissWithDefaultValue()
        {
            var model = AxiliaryBookBuilder.New().WithDateEmissNF(DateTime.MinValue.Date).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void ShouldNotCreateDcliDatVencWithDefaultValue()
        {
            var model = AxiliaryBookBuilder.New().WithDateVencNF(DateTime.MaxValue.Date).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion        
    }
}
