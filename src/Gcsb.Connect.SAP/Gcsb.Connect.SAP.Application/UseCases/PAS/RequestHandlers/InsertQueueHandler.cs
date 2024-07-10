using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.PAS.RequestHandlers
{
    public class InsertQueueHandler : Handler
    {
        private readonly IPublisher<ProcessFile> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public InsertQueueHandler(IPublisher<ProcessFile> publisher, IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public override void ProcessRequest(PASChainRequest request)
        {
            request.AddProcessingLog("Inserting Queue - Process Next File");

            var processFile = new ProcessFile(request.FilePaymentFeed.Id, request.FilePaymentFeed.FileName, TypeRegister.PAYMENT);

            if (request.PASFile.Any(w=> w.Status.Equals(Status.Error)))
            {
                request.AddExceptionLog("The file object of PAS not exist", "");
                return;
            }

            publisher.PublishAsync(processFile);
            interfaceProgressUseCase.Successfully(new InterfaceProgressRequest(request.PASFile.FirstOrDefault()?.IdParent, Domain.Upload.Enum.UploadTypeEnum.PaymentFeedCreditCard));

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
