using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.JSDN;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers.Boleto
{
    public class InsertQueueHandler : Handler, IInsertQueueHandler<PaymentBoleto>
    {
        private readonly IPublisher<PaymentFeedBoletoFile> publisher;

        public InsertQueueHandler(IPublisher<PaymentFeedBoletoFile> publisher)
        {
            this.publisher = publisher;
        }

        public override void ProcessRequest(DocFeedRequest request)
        {
            if (request.File.Status == Status.Success)
            {
                var paymentFile = new PaymentFeedBoletoFile(request.File.Id, request.File.FileName, TypePaymentMethod.Boleto);                
                publisher.PublishAsync(paymentFile);
            }
            
            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
