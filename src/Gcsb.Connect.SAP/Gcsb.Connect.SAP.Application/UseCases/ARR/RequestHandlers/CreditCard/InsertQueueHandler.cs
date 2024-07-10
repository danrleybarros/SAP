using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers
{
    public class InsertQueueHandler : Handler<ARRCreditCard>, IInsertQueueHandler<ARRCreditCard>
    {
        private readonly IPublisher<ARRIntercompanyFile> publisher;

        public InsertQueueHandler(IPublisher<ARRIntercompanyFile> publisher)
        {
            this.publisher = publisher;
        }

        public override void ProcessRequest(IARRRequest<ARRCreditCard> request)
        {
            request.AddProcessingLog("Inserting Queue - ARR");

            if (request.Files.Any(s => s.Status.Equals(Status.Error)))
            {
                request.AddExceptionLog("The file object of ARR not exist", "");
                return;
            }

            publisher.PublishAsync(new ARRIntercompanyFile(request.IDPaymentFeed, ""));
            
            sucessor?.ProcessRequest(request);
        }
    }
}
