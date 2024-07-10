using System;
using System.IO;

namespace Gcsb.Connect.SAP.ReadJsdnFile
{
    public interface IReadFile
    {
        string ToBase64(string fileName);
    }

    public class ReadFile : IReadFile
    {
        public string ToBase64(string fileName)
        {
            using var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var filebytes = new byte[fs.Length];

            fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));

            return Convert.ToBase64String(filebytes);
        }
    }
}
