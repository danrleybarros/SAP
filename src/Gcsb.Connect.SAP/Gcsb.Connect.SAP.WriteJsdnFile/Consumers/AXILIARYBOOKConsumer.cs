using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class AXILIARYBOOKConsumer : IConsumer<CISSFile>
    {
        private readonly IAxiliaryBookUseCase axiliaryBookUseCase;

        public AXILIARYBOOKConsumer(IAxiliaryBookUseCase axiliaryBookUseCase)
        {
            this.axiliaryBookUseCase = axiliaryBookUseCase;
        }

        public async Task Consume(ConsumeContext<CISSFile> context)
        {
            await Task.Run(() =>
            {
                var request = new AxiliaryBookRequest((Guid)context.Message.IdParent);

                axiliaryBookUseCase.Execute(request);
            });
        }
    }
}
