using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers
{
    public class InsertQueueHandler : Handler, IInsertQueueHandler<PaymentCreditCard>
    {
        private readonly IPublisher<PaymentFeedFile> publisher;

        public InsertQueueHandler(IPublisher<PaymentFeedFile> publisher)
        {
            this.publisher = publisher;
        }

        public override void ProcessRequest(DocFeedRequest request)
        {
            if (request.File.Status == Connect.Messaging.Messages.File.Enum.Status.Success)
            {
                var paymentFile = new PaymentFeedFile(request.File.Id, request.File.FileName, Messaging.Messages.File.Enum.TypePaymentMethod.CreditCard);

                publisher.PublishAsync(paymentFile);
            }

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
