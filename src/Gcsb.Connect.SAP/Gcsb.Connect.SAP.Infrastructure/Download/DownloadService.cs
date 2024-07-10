using Gcsb.Connect.SAP.Application.Repositories.Download;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Gcsb.Connect.SAP.Infrastructure.Download
{
    public class DownloadService : IDownloadService
    {
        public byte[] DownloadZip(List<string> fileNames, string destLocalPath)
        {
            var fileNamesPath = fileNames.Select(fileName => $"{destLocalPath}{fileName}").ToList();
            MemoryStream zipStream = new MemoryStream();
            using (var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create, leaveOpen: true))
            {
                foreach (var path in fileNamesPath)
                {
                    string fileName = path;
                    int index = fileName.LastIndexOf("/");
                    if (index != -1)
                        fileName = fileName.Substring(index + 1);
                    zipArchive.CreateEntryFromFile(path, fileName);
                }
            }
            zipStream.Position = 0; //reset memory stream position.
            return zipStream.ToArray();
        }
    }
}
