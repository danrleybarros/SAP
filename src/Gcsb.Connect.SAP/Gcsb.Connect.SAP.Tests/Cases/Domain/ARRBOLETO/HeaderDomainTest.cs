using Gcsb.Connect.SAP.Tests.Builders.ARRBOLETO;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.ARRBOLETO
{
    public class HeaderDomainTest
    {
        #region Create Tests

        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateHeaderDomain()
        {
            var model = HeaderBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #endregion

        #region Tests With Constants

        [Theory]
        [Trait("Action", "None")]
        [InlineData("HH", "ARR", "TBRA", "29SP")]
        public void ShouldMatchConstantsHeaderDomain(string typeLine, string source, string company, string division)
        {
            var model = HeaderBuilder.New().Build();
            Assert.Equal(model.TypeLine, typeLine);
            Assert.Equal(model.Source, source);
            Assert.Equal(model.Company, company);
            Assert.Equal(model.Division, division);
        }

        #endregion

        #region Tests With Null And Empty 

        [Theory]
        [Trait("Action", "None")]
        [InlineData("010120199")]
        public void MaxLenght8InitialStartDate(string valor)
        {
            var model = HeaderBuilder.New().WithInitialStartDate(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("010120199")]
        public void MaxLenght8LateEndtDate(string valor)
        {
            var model = HeaderBuilder.New().WithLateEndDate(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion

    }
}
