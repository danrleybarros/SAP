using Gcsb.Connect.SAP.Domain.Upload.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.Upload
{
    public class Upload
    {
        public Guid Id { get; private set; }
        public UploadTypeEnum UploadType { get; private set; }
        public string UserId { get; private set; }
        public DateTime UploadDate { get; private set; }
        public string FileName { get; private set; }
        public StatusType StatusType { get; private set; }

        public Upload(Guid id, UploadTypeEnum uploadType, string userId, DateTime uploadDate, string fileName, StatusType statusType)
        {
            this.Id = id;
            UploadType = uploadType;
            UserId = userId;
            UploadDate = uploadDate;
            FileName = fileName;
            StatusType = statusType;
        }

        public void SetStatus(StatusType statusType)
            => StatusType = statusType;
    }
}
