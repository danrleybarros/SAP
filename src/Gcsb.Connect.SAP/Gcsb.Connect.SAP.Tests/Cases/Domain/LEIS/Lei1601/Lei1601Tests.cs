using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.LEIS.Lei1601
{
    [Trait("Action", "Create")]
    public class Lei1601Tests
    {
        [Fact]
        public void ShouldCreateLei1601Domain()
        {
            var model = Builders.LEIS.Lei1601.Lei1601Builder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
    }
}
