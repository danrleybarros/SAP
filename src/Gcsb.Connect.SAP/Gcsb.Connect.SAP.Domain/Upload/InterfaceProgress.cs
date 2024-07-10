using Gcsb.Connect.SAP.Domain.Upload.Enum;
using System;

namespace Gcsb.Connect.SAP.Domain.Upload
{
    public class InterfaceProgress
    {
        public Guid Id { get; private set; }
        public Guid? IdParent { get; private set; }
        public UploadTypeEnum UploadType { get; private set; }
        public StatusType StatusType { get; private set; }
        public DateTime RegisterDate { get; private set; }

        public InterfaceProgress(Guid id, Guid? idParent, UploadTypeEnum uploadType, StatusType statusType, DateTime registerDate)
        {
            Id = id;
            IdParent = idParent;
            UploadType = uploadType;
            StatusType = statusType;
            RegisterDate = registerDate;
        }

        public void SetStatus(StatusType statusType)
        {
            StatusType = statusType;
            RegisterDate = DateTime.UtcNow;
        }
    }
}
