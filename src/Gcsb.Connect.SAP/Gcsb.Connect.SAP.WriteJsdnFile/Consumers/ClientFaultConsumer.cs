﻿using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using MassTransit;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.Messaging.Messages.File;
using System;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class ClientFaultConsumer: IConsumer<Fault<ReturnNFFile>>
    {
        public readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public ClientFaultConsumer(ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public Task Consume(ConsumeContext<Fault<ReturnNFFile>> context)
        {
            var logs = new List<Log>();

            context.Message.Exceptions.ToList().ForEach(f => logs.Add(new Log("RabbitMQ", (Guid)context.Message.Message.IdParent, $"Error in consumer ReturnNFFile: {f.Message}. Original message: {JsonConvert.SerializeObject(context.Message.Message)}",
                    TypeLog.Error, f.StackTrace)));

            logWriteOnlyRepository.Add(logs);

            return Task.CompletedTask;
        }
    }
}
