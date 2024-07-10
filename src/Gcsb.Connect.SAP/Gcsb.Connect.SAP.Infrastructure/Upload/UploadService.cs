using Gcsb.Connect.SAP.Application.Repositories.Upload;
using System;
using System.IO;

namespace Gcsb.Connect.SAP.Infrastructure.Upload
{
    public class UploadService : IUploadService
    {
        public void Upload(string fileName, string base64, string destLocalPath)
            => File.WriteAllBytes($"{destLocalPath}{fileName}", Convert.FromBase64String(base64));        
    }
}
