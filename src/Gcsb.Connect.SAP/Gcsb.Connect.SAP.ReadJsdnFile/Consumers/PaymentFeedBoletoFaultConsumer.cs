using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using MassTransit;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.ReadJsdnFile.Consumers
{
    public class PaymentFeedBoletoFaultConsumer : IConsumer<Fault<PaymentFeedBoletoTsv>>
    {
        public readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public PaymentFeedBoletoFaultConsumer(ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public Task Consume(ConsumeContext<Fault<PaymentFeedBoletoTsv>> context)
        {
            var logs = new List<Log>();

            context.Message.Exceptions.ToList().ForEach(f => logs.Add(new Log("RabbitMQ", context.Message.Message.Id, $"Error in consumer PaymentFeedBoletoTsv: {f.Message}. Original message: {JsonConvert.SerializeObject(context.Message.Message)}",
                    TypeLog.Error, f.StackTrace)));

            logWriteOnlyRepository.Add(logs);

            return Task.CompletedTask;
        }
    }
}
