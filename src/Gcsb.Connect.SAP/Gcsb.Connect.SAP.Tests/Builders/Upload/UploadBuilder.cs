using Gcsb.Connect.SAP.Domain.Upload.Enum;
using System;


namespace Gcsb.Connect.SAP.Tests.Builders.Upload
{
    public class UploadBuilder
    {
        public Guid Id;
        public UploadTypeEnum UploadType;
        public string UserId;
        public DateTime UploadDate;
        public string FileName;
        public StatusType StatusType;

        public static UploadBuilder New()
        {
            return new UploadBuilder()
            {
                Id = Guid.NewGuid(),
                UploadType = UploadTypeEnum.Billfeed,
                UserId = "Maria.Castro",
                UploadDate = DateTime.UtcNow,
                FileName = "Billfeed_Janeiro",
                StatusType = StatusType.Processing

            };
        }

        public UploadBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public UploadBuilder WithUploadType(UploadTypeEnum uploadType)
        {
            UploadType = uploadType;
            return this;
        }

        public UploadBuilder WithUserId(string userId)
        {
            UserId = userId;
            return this;
        }

        public UploadBuilder WithUploadDate(DateTime uploadDate)
        {
            UploadDate = uploadDate;
            return this;
        }

        public UploadBuilder WithFileName(string fileName)
        {
            FileName = fileName;
            return this;
        }

        public UploadBuilder WithStatusType(StatusType statusType)
        {
            StatusType = statusType;
            return this;
        }

        public Domain.Upload.Upload Build()
        {
            return new Domain.Upload.Upload(Id, UploadType, UserId, UploadDate, FileName, StatusType);
        }
    }
}
