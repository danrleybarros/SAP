using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.JSDN
{
    public class ServiceFilterTest
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateBillFeedDocDomain()
        {
            var model = ServiceFilterBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
    }
}
