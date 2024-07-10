using Gcsb.Connect.SAP.Tests.Builders.AJU;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.AJU
{
    public class IdentificationRegisterDomainTest
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreate()
        {
            var model = new IdentificationRegisterBuilder().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(int.MinValue)]
        public void TestRequiredNullSequence(int value)
        {
            var model = new IdentificationRegisterBuilder().WithSequence(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }


        [Theory]
        [Trait("Action", "None")]
        [InlineData("FAT57TB29")]
        public void ShouldMatchConstantsIdentificationRegisterDomain(string fileName)
        {
            var model = new IdentificationRegisterBuilder().Build();

            fileName += $"{DateTime.Now.ToString("yy")}0001{string.Format("{0:ddyyyyMMdd}", model.BillingCycleDate)}.TXT";
            Assert.Equal(model.FileName, fileName);
        }
    }
}
