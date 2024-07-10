using Gcsb.Connect.SAP.Domain.Upload.Enum;
using Gcsb.Connect.SAP.Tests.Builders.Upload;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Upload
{
    public class UploadDomainTests
    {
        #region Create Domain
        [Fact]
        public void ShouldCreateUpload()
        {
            var model = UploadBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region Null or Empty
        [Fact]
        public void ShouldNotCreateIdNullOrEmpty()
        {
            var model = UploadBuilder.New().WithId(new Guid()).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [InlineData(null)]
        public void ShouldNotCreateWithUploadTypeNullOrEmpty(UploadTypeEnum uploadType)
        {
            var model = UploadBuilder.New().WithUploadType(uploadType).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithUserIdNullOrEmpty(string userId)
        {
            var model = UploadBuilder.New().WithUserId(userId).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [InlineData(null)]
        public void ShouldNotCreateWithUploadDateNullOrEmpty(DateTime uploadDate)
        {
            var model = UploadBuilder.New().WithUploadDate(uploadDate).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithFileNameNullOrEmpty(string fileName)
        {
            var model = UploadBuilder.New().WithFileName(fileName).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [InlineData(null)]
        public void ShouldNotCreateWithStatusTypeNullOrEmpty(StatusType statusType)
        {
            var model = UploadBuilder.New().WithStatusType(statusType).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }


        #endregion

    }
}
