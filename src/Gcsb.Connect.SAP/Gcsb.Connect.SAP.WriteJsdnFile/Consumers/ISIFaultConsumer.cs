using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using MassTransit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class ISIFaultConsumer: IConsumer<Fault<ClientFile>>
    {
        public readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public ISIFaultConsumer(ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public Task Consume(ConsumeContext<Fault<ClientFile>> context)
        {
            var logs = new List<Log>();

            context.Message.Exceptions.ToList().ForEach(f => logs.Add(new Log("RabbitMQ", (Guid)context.Message.Message.IdParent, $"Error in consumer ClientFile: {f.Message}. Original message: {JsonConvert.SerializeObject(context.Message.Message)}",
                    TypeLog.Error, f.StackTrace)));

            logWriteOnlyRepository.Add(logs);

            return Task.CompletedTask;
        }
    }
}
