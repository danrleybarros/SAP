using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCardIntercompany
{
    public class InsertQueueHandler : Handler<ARRCreditCardInter>, IInsertQueueHandler<ARRCreditCardInter>
    {
        private readonly IPublisher<ARRFile> publisher;

        public InsertQueueHandler(IPublisher<ARRFile> publisher)
        {
            this.publisher = publisher;
        }

        public override void ProcessRequest(IARRRequest<ARRCreditCardInter> request)
        {
            request.AddProcessingLog("Inserting Queue - ARR Intercompany");

            if (request.Files.Any(s => s.Status.Equals(Status.Error)))
            {
                request.AddExceptionLog("The file object of ARR Intercompany not exist", "");
                return;
            }

            publisher.PublishAsync(new ARRFile(request.IDPaymentFeed, ""));

            sucessor?.ProcessRequest(request);
        }
    }
}
