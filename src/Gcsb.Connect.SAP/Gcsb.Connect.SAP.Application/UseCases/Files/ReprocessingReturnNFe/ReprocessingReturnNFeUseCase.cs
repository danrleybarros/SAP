using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.UseCases.GF;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.ReprocessingReturnNFe
{
    public class ReprocessingReturnNFeUseCase : IReprocessingReturnNFeUseCase
    {
        private readonly IReturnNFUseCase ReturnNFUseCase;

        public ReprocessingReturnNFeUseCase(IReturnNFUseCase returnNFUseCase)
        {
            ReturnNFUseCase = returnNFUseCase;
        }

        public void Execute(ReprocessingReturnNFeRequest request)
        {
            var dicFiles = new Dictionary<string, string>();
            var basePath = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
            var fileDate = request.NfeFiles.Select(s => s.DateFileStr).FirstOrDefault();

            request.NfeFiles.ForEach(f => dicFiles.Add(f.StoreAcronym, ToBase64($"{basePath}{f.FileName}")));

            var returnNFRequest = new ReturnNFRequest(TypeRegister.RETURNNF, fileDate, dicFiles);
            returnNFRequest.BillFeedFileId = request.BillFeedFileId;

            ReturnNFUseCase.Execute(returnNFRequest);
        }

        private string ToBase64(string fileName)
        {
            using var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var filebytes = new byte[fs.Length];

            fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));

            return Convert.ToBase64String(filebytes);
        }
    }
}
