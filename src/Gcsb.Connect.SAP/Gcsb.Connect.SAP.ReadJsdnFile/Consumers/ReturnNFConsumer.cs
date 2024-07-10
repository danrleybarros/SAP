using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.UseCases.GF;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using MassTransit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.ReadJsdnFile.Consumers
{
    public class ReturnNFConsumer : IConsumer<ReturnNFCsv>
    {
        private readonly IReturnNFUseCase returnNFUseCase;
        private readonly IReadFile readFile;
        private readonly string basePath;

        public ReturnNFConsumer(IReturnNFUseCase returnNFUseCase, IReadFile readFile)
        {
            this.returnNFUseCase = returnNFUseCase;
            this.readFile = readFile;
            this.basePath = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
        }

        public async Task Consume(ConsumeContext<ReturnNFCsv> context)
        {
            ReturnNFCsv returNFCsv = context.Message;

            await Task.Run(() =>
            {
                var dicFiles = new Dictionary<string, string>();
                var nfeFiles = JsonConvert.DeserializeObject<List<NfeFiles>>(returNFCsv.FileName);
                var fileDate = nfeFiles.Select(s => s.DateFileStr).FirstOrDefault();

                nfeFiles.ForEach(f => dicFiles.Add(f.StoreAcronym, readFile.ToBase64($"{basePath}{f.FileName}")));

                returnNFUseCase.Execute(new ReturnNFRequest(TypeRegister.RETURNNF, fileDate, dicFiles));                
            });
        }
    }
}
