using System;
using System.IO;

namespace Gcsb.Connect.SAP.Infrastructure.FileConvert.TsvBoletoConvert
{
    public class PaymentFeedReadTsv : Application.Repositories.IPaymentFeedReadTsvRepository
    {
        public string ReadTsvFile(string path)
        {
            Byte[] bytes = File.ReadAllBytes(path);
            return Convert.ToBase64String(bytes);
        }
    }
}
