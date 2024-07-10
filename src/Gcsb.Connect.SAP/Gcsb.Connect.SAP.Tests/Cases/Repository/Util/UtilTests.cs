using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.Util
{
    public class UtilTests
    {
        [Theory]
        [InlineData("04/2019")]
        [InlineData("04-2019")]
        [InlineData("01/04/2019")]
        [InlineData("01-04-2019")]
        [InlineData("2019-04-01 00:00")]
        [InlineData("2019-04-01 00:00:00.000")]
        public void ShouldConvertDatesFormats(string date)
        {
            var dateConverted = (DateTime)SAP.Infrastructure.Util.ConvertDateBill(date);
            Assert.True(DateTime.Compare(dateConverted, new DateTime(2019, 04, 01, 00, 00, 00)) == 0);
        }
    }
}
