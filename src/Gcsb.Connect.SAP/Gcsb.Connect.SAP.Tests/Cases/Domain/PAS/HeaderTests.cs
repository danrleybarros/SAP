using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.PAS
{
    public class HeaderTests
    {
        #region Create Tests
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateHeader()
        {
            var model = new SAP.Domain.PAS.Header(StoreType.TBRA);
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #endregion

        #region Constants Tests

        [Theory]
        [InlineData("HD")]
        [Trait("Action", "None")]
        public void ShouldMacthHDConstant(string constant)
        {
            var model = new SAP.Domain.PAS.Header(StoreType.TBRA);
            Assert.True(model.HD == constant);
        }

        [Theory]
        [InlineData("TBRA")]
        [Trait("Action", "None")]
        public void ShouldMacthEmpresaConstant(string constant)
        {
            var model = new SAP.Domain.PAS.Header(StoreType.TBRA);
            Assert.True(model.Empresa == constant);
        }

        [Theory]
        [InlineData("GLWEB")]
        [Trait("Action", "None")]
        public void ShouldMacthCodLegadoConstant(string constant)
        {
            var model = new SAP.Domain.PAS.Header(StoreType.TBRA);
            Assert.True(model.CodLegado == constant);
        }

        [Theory]
        [InlineData("29SP")]
        [Trait("Action", "None")]
        public void ShouldMacthDivisaoConstant(string constant)
        {
            var model = new SAP.Domain.PAS.Header(StoreType.TBRA);
            Assert.True(model.Divisao == constant);
        }
        #endregion
    }
}
