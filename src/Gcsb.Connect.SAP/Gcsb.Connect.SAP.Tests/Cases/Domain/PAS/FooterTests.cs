using Gcsb.Connect.SAP.Tests.Builders.PAS;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.PAS
{
    public class FooterTests
    {
        #region Create Tests
        [Fact]
        [Trait("Action","Create")]
        public void ShouldCreateFooter()
        {
            var model = FooterBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region Null and Empty Tests

        [Theory]
        [Trait("Action", "None")]
        [InlineData(int.MinValue)]
        public void NullOrEmptyShouldNotCreateWithQtdeRegistros(int valor)
        {
            var model = FooterBuilder.New().ComQtdeRegistros(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion

        #region MaxLength Tests

        [Theory]
        [Trait("Action", "None")]
        [InlineData(99999999)]
        public void MaxLenght7QtdeRegistros(int valor)
        {
            var model = FooterBuilder.New().ComQtdeRegistros(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion
    }
}
