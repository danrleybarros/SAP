using System.Collections.Generic;
using Gcsb.Connect.Messaging.Messages.Log;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Download
{
    public class DownloadOutput
    {
        public byte[] BytesFile { get; set; }
        public string Base64 { get; set; }
        public List<Log> Logs { get; set; }
    }
}
