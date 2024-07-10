using Gcsb.Connect.SAP.Tests.Builders.GF;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.GF
{
    public class CepOutputDomainTests
    {
        #region Create Domain

        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreate()
        {
            var model = new CepOutputBuilder().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #endregion

        #region REQUIREDS AND MAXLENGTH

        [Theory]
        [InlineData("AAA")]
        [InlineData(null)]
        [InlineData("")]
        public void TestRequiredAndMaxLengthUf(string value)
        {
            var model = new CepOutputBuilder().WithUf(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion

        #region REQUIREDS

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullNomeLocalidade(string value)
        {
            var model = new CepOutputBuilder().WithNomeLocalidade(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        
        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullTipoLogradouro(string value)
        {
            var model = new CepOutputBuilder().WithTipoLogradouro(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullNomeLogradouro(string value)
        {
            var model = new CepOutputBuilder().WithNomeLogradouro(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        
        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullBairro(string value)
        {
            var model = new CepOutputBuilder().WithBairro(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullCep(string value)
        {
            var model = new CepOutputBuilder().WithCep(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion
    }
}
