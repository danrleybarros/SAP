using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.UseCases.GF.CISS;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class CISSConsumer : IConsumer<ItemsFile>
    {
        private readonly ICISSUseCase cissUseCase;

        public CISSConsumer(ICISSUseCase cissUseCase)
        {
            this.cissUseCase = cissUseCase;
        }

        public async Task Consume(ConsumeContext<ItemsFile> context)
        {
            await Task.Run(() =>
            {
                CISSRequest request = new CISSRequest((Guid)context.Message.IdParent);
                cissUseCase.Execute(request);
            });
        }
    }
}
