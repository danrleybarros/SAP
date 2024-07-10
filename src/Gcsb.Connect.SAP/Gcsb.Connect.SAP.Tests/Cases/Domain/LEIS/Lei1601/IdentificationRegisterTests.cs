using Gcsb.Connect.SAP.Tests.Builders.LEIS.Lei1601;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.LEIS.Lei1601
{
    [Trait("Action", "Create")]
    public class IdentificationRegisterTests
    {
        [Fact]
        public void DontShouldCreateIdentificationRegisterDomain()
        {
            var model = IdentificationRegisterBuilder.New().WithSequence(0).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void ShouldCreateIdentificationRegisterDomain()
        {
            var model = IdentificationRegisterBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
    }
}
