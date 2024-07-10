using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class ISIConsumer : IConsumer<ClientFile>
    {
        private readonly IISIUseCase ISIUseCase;

        public ISIConsumer(IISIUseCase ISIUseCase)
        {
            this.ISIUseCase = ISIUseCase;
        }

        public async Task Consume(ConsumeContext<ClientFile> context)
        {
            await Task.Run(() =>
            {
                var request = new ISIRequest((Guid)context.Message.IdParent);
                ISIUseCase.Execute(request);
            });
        }
    }
}
