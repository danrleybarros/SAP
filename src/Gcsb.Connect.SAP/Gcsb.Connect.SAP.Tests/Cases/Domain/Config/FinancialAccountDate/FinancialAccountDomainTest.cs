using Gcsb.Connect.SAP.Tests.Builders.Config.FinancialAccountDate;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Config.FinancialAccountDate
{
    public class FinancialAccountDomainTest
    {
        #region Create Tests

        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreate()
        {
            var model = new FinancialAccountBuilder().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #endregion

        #region Tests With Null And Empty 

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyServiceCodeNotCreate(string valor)
        {
            var model = new FinancialAccountBuilder().WithServiceCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyServiceNameNotCreate(string valor)
        {
            var model = new FinancialAccountBuilder().WithServiceName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyFaturamentoFatNotCreate(string valor)
        {
            var model = new FinancialAccountBuilder().WithFaturamentoFAT(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyFaturamentoAjuNotCreate(string valor)
        {
            var model = new FinancialAccountBuilder().WithFaturamentoAJU(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyDescontoFatNotCreate(string valor)
        {
            var model = new FinancialAccountBuilder().WithDescontoFAT(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        
        [Theory]
        [InlineData(null)]
        public void NullOrEmptyDateIncludedCreate(DateTime? valor)
        {
            var model = new FinancialAccountBuilder().WithDateIncluded(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyContaContabilAjusteCompetenciaDeb(string ajusteCompetenciaDeb)
        {
            var model = new FinancialAccountBuilder().WithContaContabilAjusteCompetenciaDeb(ajusteCompetenciaDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyContaContabilAjusteCompetenciaCred(string ajusteCompetenciaCred)
        {
            var model = new FinancialAccountBuilder().WithContaContabilAjusteCompetenciaCred(ajusteCompetenciaCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyContaContabilEstimativaCicloDeb(string estimativaCicloDeb)
        {
            var model = new FinancialAccountBuilder().WithContaContabilAjusteCompetenciaDeb(estimativaCicloDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyContaContabilEstimativaCicloCred(string estimativaCicloCred)
        {
            var model = new FinancialAccountBuilder().WithContaContabilAjusteCompetenciaCred(estimativaCicloCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion

        #region Tests With MaxLenght

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem ipsum dolor sit")]
        public void MaxLenght15ServiceCode(string valor)
        {
            var model = new FinancialAccountBuilder().WithServiceCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem ipsum dolor sit amet turpis consequat molestie")]
        public void MaxLenght50ServiceName(string valor)
        {
            var model = new FinancialAccountBuilder().WithServiceName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem ipsum dolor sit")]
        public void MaxLenght15FaturamentoFat(string valor)
        {
            var model = new FinancialAccountBuilder().WithFaturamentoFAT(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem ipsum dolor sit")]
        public void MaxLenght15FaturamentoAju(string valor)
        {
            var model = new FinancialAccountBuilder().WithFaturamentoAJU(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem ipsum dolor sit")]
        public void MaxLenght15DescontoFat(string valor)
        {
            var model = new FinancialAccountBuilder().WithDescontoFAT(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("ajusteCompetenciaDeb")]
        public void MaxLength8AjusteCompetenciaDeb(string ajusteCompetenciaDeb)
        {           
            var model = new FinancialAccountBuilder().WithContaContabilAjusteCompetenciaDeb(ajusteCompetenciaDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("ajusteCompetenciaCred")]
        public void MaxLength8AjusteCompetenciaCred(string ajusteCompetenciaCred)
        {           
            var model = new FinancialAccountBuilder().WithContaContabilAjusteCompetenciaCred(ajusteCompetenciaCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("estimativaCicloDeb")]
        public void MaxLength8EstimativaCicloDeb(string estimativaCicloDeb)
        {                
            var model = new FinancialAccountBuilder().WithContaContabilEstimativaCicloDeb(estimativaCicloDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("estimativaCicloCred")]
        public void MaxLength8EstimativaCicloCred(string estimativaCicloCred)
        {            
            var model = new FinancialAccountBuilder().WithContaContabilEstimativaCicloCred(estimativaCicloCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion
    }
}
