using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.UseCases.ARR;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class ARRCreditCardIntercompanyConsumer : IConsumer<ARRIntercompanyFile>
    {
        private readonly IARRUseCase<ARRCreditCardInter> arrUseCaseCreditInter;

        public ARRCreditCardIntercompanyConsumer(IARRUseCase<ARRCreditCardInter> arrUseCaseCreditInter)
        {
            this.arrUseCaseCreditInter = arrUseCaseCreditInter;
        }

        public async Task Consume(ConsumeContext<ARRIntercompanyFile> context)
        {
            await Task.Run(() =>
            {
                var requestCreditCardIntercompany = new ARRRequest<ARRCreditCardInter>(TypeRegister.ARRINTER, (Guid)context.Message.IdParent);
                arrUseCaseCreditInter.Execute(requestCreditCardIntercompany);
            });
        }
    }
}
