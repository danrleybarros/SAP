namespace Gcsb.Connect.SAP.Domain.Download
{
    public class FileByteInfo
    {
        public string FileName { get; private set; }
        public byte[] File { get; private set; }

        public FileByteInfo(string fileName, byte[] file)
        {
            this.FileName = fileName;
            this.File = file;
        }
    }
}
