using System;
using Gcsb.Connect.SAP.Domain.Upload.Enum;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress
{
    public class InterfaceProgressRequest
    {
        public Guid? IdParent { get; set; }
        public UploadTypeEnum UploadType { get; set; }

        public InterfaceProgressRequest(Guid? idParent, UploadTypeEnum uploadTypeEnum)
        {
            IdParent = idParent;
            UploadType = uploadTypeEnum;
        }
    }
}
