using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.UseCases.ARR;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.PAY;
using Gcsb.Connect.SAP.Domain.ARR.Boleto;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class CriticalFileConsumer : IConsumer<PaymentFeedBoletoFile>
    {
        private readonly ICriticalUseCase criticalUseCase;

        public CriticalFileConsumer(ICriticalUseCase criticalUseCase)
        {
            this.criticalUseCase = criticalUseCase;
        }

        public async Task Consume(ConsumeContext<PaymentFeedBoletoFile> context)
        {
            await Task.Run(() =>
            {
                var request = new CriticalRequest(context.Message.IdParent.Value);
                criticalUseCase.Execute(request);
            });
        }
    }
}
