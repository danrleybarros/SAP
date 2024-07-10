using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.UploadTypeDto;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.UploadType
{
    public class UploadTypeResponse
    {
        public List<UploadTypeDto> UploadTypes { get; set; }
    }
}
