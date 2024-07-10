using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.CISS.RequestHandlers
{
    public class InsertQueueHandler : Handler
    {
        private readonly IPublisher<CISSFile> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public InsertQueueHandler(IPublisher<CISSFile> publisher, IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public override void ProcessRequest(CISSRequest request)
        {
            request.AddProcessingLog("Inserting Queue");

            if (request.File.Status == Connect.Messaging.Messages.File.Enum.Status.Success)
                publisher.PublishAsync(new CISSFile(request.IdFileReturnNF, request.File.FileName));

                interfaceProgressUseCase.Error(new InterfaceProgressRequest(request.IdFileReturnNF, Domain.Upload.Enum.UploadTypeEnum.ReturnNF));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
