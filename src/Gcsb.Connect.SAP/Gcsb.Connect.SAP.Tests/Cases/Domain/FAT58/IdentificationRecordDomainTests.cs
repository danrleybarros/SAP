using Gcsb.Connect.SAP.Tests.Builders.FAT.FAT58;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.FAT58
{
    public class IdentificationRecordDomainTests
    {
        #region Should create
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateIdentificationRecord()
        {
            var model = IdentificationRecordBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region Should not create with invalid informations
        [Fact]
        [Trait("Action", "None")]
        public void ShouldNotCreateWithInvalidFileName()
        {
            var year = DateTime.UtcNow.ToString("yy");
            var model = IdentificationRecordBuilder.New().WithGenerationDate(DateTime.Now).Build();
            string filename = model.FileName;
            Assert.Equal($"FAT58TB29{year}00003120190331.TXT", filename);
        }
        #endregion

        #region Tests constants
        [Theory]
        [Trait("Action", "None")]
        [InlineData("ID")]
        public void ShouldMatchConstantsIdentificationRecordDomain(string linetype)
        {
            var model = IdentificationRecordBuilder.New().Build();
            Assert.True(model.LineType == linetype);
        }
        #endregion
    }
}
