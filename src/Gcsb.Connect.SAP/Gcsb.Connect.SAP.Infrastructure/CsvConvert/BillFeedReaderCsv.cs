using System;
using System.IO;

namespace Gcsb.Connect.SAP.Infrastructure.CsvConvert
{
    public class BillFeedReaderCsv : Application.Repositories.IBillFeedReadCsvRepository
    {
        
        public string ReadCsvFile(string path)
        {
            Byte[] bytes = File.ReadAllBytes(path);
            return Convert.ToBase64String(bytes);
        }
    }
}
