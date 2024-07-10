using Gcsb.Connect.SAP.Tests.Builders.AJU;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.AJU
{
    public class LaunchDomainTests
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreate()
        {
            var model = new LaunchBuilder().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void TestRequiredNullFinancialAccount(string value)
        {
            var model = new LaunchBuilder().WithFinancialAccount(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("D1", "CONT", "29TR018233", "01", "GW", "9141", "Pos")]
        public void ShouldMatchConstantsLaunchDomain(string typeLine, string type, string costCenter, string cycleNumber, string operatorcomplement
            , string businesslocation, string billingOption)
        {
            var model = new LaunchBuilder().Build();

            Assert.Equal(typeLine, model.TypeLine);
            Assert.Equal(type, model.Type);
            Assert.Equal(costCenter, model.CostCenter);
            Assert.Equal(cycleNumber, model.CycleNumber);
            Assert.Equal(operatorcomplement, model.OperatorComplement);
            Assert.Equal(businesslocation, model.BusinessLocation);
            Assert.Equal(billingOption, model.BillingOption);
        }



        [Fact]
        public void DateLaunchShouldStartWith21()
        {
            var model = new LaunchBuilder().Build();
            var year = DateTime.UtcNow.ToString("yy");

            Assert.StartsWith("21", model.LaunchDateStr);
        }


        [Fact]
        public void DateLaunchShoulAddNextMonthBillTo()
        {
            var billTo = System.DateTime.UtcNow;
            var expected = System.DateTime.UtcNow.AddMonths(1);
            var year = DateTime.UtcNow.ToString("yy");

            var model = new LaunchBuilder().WithLaunchDate(billTo).Build();

            Assert.Equal($"21{expected.ToString("MMyyyy")}", model.LaunchDateStr);
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateDomainWithTypeLaunchAccountingNullOrEmpty(string typeLaunchAccounting)
        {
            var model = new LaunchBuilder().WithTypeLaunchAccounting(typeLaunchAccounting).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);

        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateDomainWithAccountingAccountNullOrEmpty(string accountingAccount)
        {
            var model = new LaunchBuilder().WithAccountingAccount(accountingAccount).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [InlineData("XCC")]
        public void ShouldNotCreateDomainWithTypeLaunchGreatherThan2Chacaracter(string InvalidTypeLaunchAccounting)
        {
            var model = new LaunchBuilder().WithTypeLaunchAccounting(InvalidTypeLaunchAccounting).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [InlineData("CCOFFICE365GW")]
        public void ShouldNotCreateDomainWithAccountingAccountGreatherThan10Chacaracter(string InvalidAccountingAccount)
        {
            var model = new LaunchBuilder().WithAccountingAccount(InvalidAccountingAccount).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);

        }


        [Theory]
        [InlineData("DC")]
        public void ShouldNotCreateDomainWithTypeLaunchAccountingInvalid(string InvalidtypeLaunchAccounting)
        {
            var model = new LaunchBuilder().WithTypeLaunchAccounting(InvalidtypeLaunchAccounting).Build();

            Assert.True(Util.ValidateModel(model).Count > 0);

        }

    }
}
