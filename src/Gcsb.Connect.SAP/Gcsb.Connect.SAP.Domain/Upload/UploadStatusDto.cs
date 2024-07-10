using System;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.Upload.Enum;

namespace Gcsb.Connect.SAP.Domain.Upload
{
    public class UploadStatusDto
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public string FileName { get; set; }
        public UploadTypeEnum UploadType { get; set; }
        public string UserId { get; set; }
        public DateTime UploadDate { get; set; }
        public StatusType StatusType { get; set; }
        public List<Messaging.Messages.Log.Log> Logs { get; set; }
    }
}
