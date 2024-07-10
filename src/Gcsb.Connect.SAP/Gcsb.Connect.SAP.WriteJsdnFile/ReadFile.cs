using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gcsb.Connect.SAP.WriteJsdnFile
{
    public interface IReadFile
    {
        string ToBase64(string fileName);
    }
    public class ReadFile : IReadFile
    {
        public string ToBase64(string fileName)
        {
            using (var fs = new FileStream(fileName,
                                           FileMode.Open,
                                           FileAccess.Read))
            {
                byte[] filebytes = new byte[fs.Length];
                fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
                string encodedData =
                    Convert.ToBase64String(filebytes);
                return encodedData;
            }
        }
    }
}
