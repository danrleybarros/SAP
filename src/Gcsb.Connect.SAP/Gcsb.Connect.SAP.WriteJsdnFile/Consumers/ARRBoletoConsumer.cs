using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.UseCases.ARR;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.Boleto;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class ARRBoletoConsumer : IConsumer<CriticalFile>
    {
        private readonly IARRUseCase<ARRBoleto> arrUseCaseBoleto;

        public ARRBoletoConsumer(IARRUseCase<ARRBoleto> arrUseCaseBoleto)
        {
            this.arrUseCaseBoleto = arrUseCaseBoleto;
        }

        public async Task Consume(ConsumeContext<CriticalFile> context)
        {
            await Task.Run(() =>
            {
                var requestCreditCard = new ARRRequest<ARRBoleto>(TypeRegister.ARRBOLETO, (Guid)context.Message.IdParent);
                arrUseCaseBoleto.Execute(requestCreditCard);
            });
        }
    }
}
