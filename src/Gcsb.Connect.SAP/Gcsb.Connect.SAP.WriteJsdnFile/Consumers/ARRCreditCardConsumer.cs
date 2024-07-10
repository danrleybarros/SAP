using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.UseCases.ARR;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class ARRCreditCardConsumer : IConsumer<PaymentFeedFile>
    {
        private readonly IARRUseCase<ARRCreditCard> arrUseCaseCredit;

        public ARRCreditCardConsumer(IARRUseCase<ARRCreditCard> arrUseCaseCredit)
        {
            this.arrUseCaseCredit = arrUseCaseCredit;            
        }

        public async Task Consume(ConsumeContext<PaymentFeedFile> context)
        {
            await Task.Run(() =>
            {
                var requestCreditCard = new ARRRequest<ARRCreditCard>(TypeRegister.ARR, (Guid)context.Message.IdParent);
                arrUseCaseCredit.Execute(requestCreditCard);              
            });
        }
    }
}
