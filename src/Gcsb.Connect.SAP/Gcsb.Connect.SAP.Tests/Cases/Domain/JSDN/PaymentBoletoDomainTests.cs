using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.JSDN
{
    public class PaymentBoletoDomainTests
    {
        #region Create Domain
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreate()
        {
            var model = new PaymentBoletoBuilder().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion
                
        #region REQUIREDS

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullUF(System.String value)
        {
            var model = new PaymentBoletoBuilder().WithUF(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(0)]
        [InlineData(int.MinValue)]
        public void TestRequiredNullCodigoBanco(System.Int32 value)
        {
            var model = new PaymentBoletoBuilder().WithCodigoBanco(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullCodigoBarras(System.String value)
        {
            var model = new PaymentBoletoBuilder().WithCodigoBarras(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion

        #region MAX LENGTH
        #endregion
    }
}
