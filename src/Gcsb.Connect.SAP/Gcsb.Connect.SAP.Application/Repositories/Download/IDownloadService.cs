using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Repositories.Download
{
    public interface IDownloadService
    {
        byte[] DownloadZip(List<string> fileNames, string destLocalPath);
    }
}
