using System;
using System.IO;

namespace Gcsb.Connect.SAP.Infrastructure.CsvConvert
{
    public class ReturnNFReaderCsv : Application.Repositories.GF.IReturnNFReadCsvRepository
    {
        public string ReadCsvFile(string path)
        {
            Byte[] bytes = File.ReadAllBytes(path);
            return Convert.ToBase64String(bytes);
        }
    }
}