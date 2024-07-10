using Gcsb.Connect.SAP.Domain.Upload;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.GetUploadStatus
{
    public class FileResponse
    {
        public List<UploadStatusDto> Uploads { get; set; }
    }    
}
