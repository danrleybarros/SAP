using System;
using System.Collections.Generic;
using System.Text;
using Gcsb.Connect.SAP.Domain.Upload;
using Gcsb.Connect.SAP.Domain.Upload.Enum;

namespace Gcsb.Connect.SAP.Tests.Builders.Upload
{
    public class InterfaceProgressBuilder
    {
        public Guid Id;
        public Guid? IdParent;
        public UploadTypeEnum UploadType;
        public StatusType StatusType;
        public DateTime RegisterDate;

        public static InterfaceProgressBuilder New()
        {
            return new InterfaceProgressBuilder()
            {
                Id = Guid.NewGuid(),
                IdParent = Guid.NewGuid(),
                UploadType = UploadTypeEnum.Billfeed,
                StatusType = StatusType.Processing,
                RegisterDate = DateTime.UtcNow
            };  
        }

        public InterfaceProgressBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public InterfaceProgressBuilder WithIdParent(Guid idParent)
        {
            IdParent = idParent;
            return this;
        }

        public InterfaceProgressBuilder WithUploadType(UploadTypeEnum uploadType)
        {
            UploadType = uploadType;
            return this;
        }

        public InterfaceProgressBuilder WithStatusType(StatusType statusType)
        {
            StatusType = statusType;
            return this;
        }

        public InterfaceProgressBuilder WithRegisterDate(DateTime registerDate)
        {
            RegisterDate = registerDate;
            return this;
        }

        public InterfaceProgress Build()
        {
            return new InterfaceProgress(Id, IdParent, UploadType, StatusType, RegisterDate);
        }
    }

}
