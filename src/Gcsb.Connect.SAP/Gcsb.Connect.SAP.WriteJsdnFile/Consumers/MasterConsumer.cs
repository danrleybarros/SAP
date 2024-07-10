using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.UseCases.GF.Master;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class MasterConsumer : IConsumer<ISIFile>
    {
        private readonly IMasterUseCase masterUseCase;

        public MasterConsumer(IMasterUseCase MasterUseCase)
        {
            this.masterUseCase = MasterUseCase;
        }

        public async Task Consume(ConsumeContext<ISIFile> context)
        {
            var isiFile = context.Message;

            await Task.Run(() =>
            {
                var request = new MasterRequest((Guid)isiFile.IdParent);
                masterUseCase.Execute(request);
            });
        }
    }
}
