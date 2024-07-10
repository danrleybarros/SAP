using Gcsb.Connect.SAP.Domain.Upload.Enum;
using System;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
{
    public class InterfaceProgress
    {
        public Guid Id { get; set; }
        public Guid? IdParent { get; set; }
        public UploadTypeEnum UploadType { get; set; }
        public StatusType StatusType { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
