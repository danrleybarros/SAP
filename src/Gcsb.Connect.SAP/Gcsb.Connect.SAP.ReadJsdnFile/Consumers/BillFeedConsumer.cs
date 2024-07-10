using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.ReadJsdnFile.Consumers
{
    public class BillFeedConsumer : IConsumer<Messaging.Messages.File.BillFeedCsv>
    {
        private readonly IBillFeedUseCase billFeedUseCase;
        private readonly IReadFile readFile;
        private readonly string basePath;

        public BillFeedConsumer(IBillFeedUseCase billFeedUseCase, IReadFile readFile)
        {
            this.billFeedUseCase = billFeedUseCase;
            this.readFile = readFile;
            this.basePath = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
        }

        public async Task Consume(ConsumeContext<Messaging.Messages.File.BillFeedCsv> context)
        {
            var billFeedCsv = context.Message;

            await Task.Run(() =>
            {
                var base64 = readFile.ToBase64($"{basePath}{billFeedCsv.FileName}");
                DocFeedRequest request = new DocFeedRequest(TypeRegister.BILLCSV, billFeedCsv.FileName, base64);
                billFeedUseCase.Execute(request);
            });
        }
    }
}
