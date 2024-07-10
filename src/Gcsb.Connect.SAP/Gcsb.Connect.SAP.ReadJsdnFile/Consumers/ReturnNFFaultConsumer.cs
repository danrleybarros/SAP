using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using MassTransit;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.ReadJsdnFile.Consumers
{
    public class ReturnNFFaultConsumer : IConsumer<Fault<ReturnNFCsv>>
    {
        public readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public ReturnNFFaultConsumer(ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public Task Consume(ConsumeContext<Fault<ReturnNFCsv>> context)
        {
            var logs = new List<Log>();

            context.Message.Exceptions.ToList().ForEach(f => logs.Add(new Log("RabbitMQ", context.Message.Message.Id, $"Error in consumer ReturnNFCsv: {f.Message}. Original message: {JsonConvert.SerializeObject(context.Message.Message)}",
                    TypeLog.Error, f.StackTrace)));

            logWriteOnlyRepository.Add(logs);

            return Task.CompletedTask;
        }
    }
}
