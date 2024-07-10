using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.UseCases.PAS;

using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class PASConsumer : IConsumer<ARRIntercompanyFile>
    {
        public readonly IPASUseCase pasUseCase;

        public PASConsumer(IPASUseCase pasUseCase)
        {
            this.pasUseCase = pasUseCase;
        }

        public async Task Consume(ConsumeContext<ARRIntercompanyFile> context)
        {
            await Task.Run(() =>
            {
                var file = new Messaging.Messages.File.File((Guid)context.Message.IdParent,
                                    context.Message.FileName,
                                    context.Message.Type,
                                    context.Message.InclusionDate,
                                    context.Message.Status,                                                                       
                                    context.Message.Logs);
                
                pasUseCase.Execute(new PASRequest(file));
            });
        }
    }
}
