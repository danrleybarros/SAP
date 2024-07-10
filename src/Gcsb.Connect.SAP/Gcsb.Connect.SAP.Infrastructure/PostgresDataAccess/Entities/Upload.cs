using Gcsb.Connect.SAP.Domain.Upload.Enum;
using System;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
{
    public class Upload
    {
        public Guid Id { get; set; }
        public UploadTypeEnum UploadType { get; set; }
        public string UserId { get; set; }
        public DateTime? UploadDate { get; set; }
        public string FileName { get; set; }
        public StatusType StatusType { get; set; }

    }
}
