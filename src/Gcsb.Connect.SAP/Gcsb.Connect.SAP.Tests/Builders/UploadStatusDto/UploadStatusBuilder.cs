using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Domain.Upload.Enum;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Tests.Builders.Upload
{
    public class UploadStatusBuilder
    {
        public Guid Id;
        public Guid FileId;
        public string FileName;
        public UploadTypeEnum UploadType;
        public string UserId;
        public DateTime UploadDate;
        public StatusType StatusType;
        public List<Messaging.Messages.Log.Log> Logs;

        public static UploadStatusBuilder New()
        {
            return new UploadStatusBuilder()
            {
                Id = Guid.NewGuid(),
                FileId = Guid.NewGuid(),
                FileName = "Billfeed_Janeiro",
                UploadType = UploadTypeEnum.Billfeed,
                UserId = "Maria.Castro",
                UploadDate = DateTime.UtcNow,
                StatusType = StatusType.Processing,
                Logs = new List<Log>()
            };
        }

        public UploadStatusBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public UploadStatusBuilder WithFileId(Guid fileId)
        {
            FileId = fileId;
            return this;
        }

        public UploadStatusBuilder WithFileName(string fileName)
        {
            FileName = fileName;
            return this;
        }



        public UploadStatusBuilder WithUploadType(UploadTypeEnum uploadType)
        {
            UploadType = uploadType;
            return this;
        }


        public UploadStatusBuilder WithUserId(string userId)
        {
            UserId = userId;
            return this;
        }

        public UploadStatusBuilder WithUploadDate(DateTime uploadDate)
        {
            UploadDate = uploadDate;
            return this;
        }

        public UploadStatusBuilder WithStatusType(StatusType statusType)
        {
            StatusType = statusType;
            return this;
        }

        public UploadStatusBuilder WithLog(List<Messaging.Messages.Log.Log> logs)
        {
            Logs = logs;
            return this;
        }

        public Domain.Upload.UploadStatusDto Build()
        {
            return new Domain.Upload.UploadStatusDto();
        }
    }
}
