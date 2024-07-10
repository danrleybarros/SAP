using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Upload;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.BillFeed.RequestHandlers
{
    public class SaveFileHandler : Handler<BillFeedChainRequest>
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;        

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository, IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
            this.interfaceProgressUseCase = interfaceProgressUseCase;            
        }

        public override void ProcessRequest(BillFeedChainRequest request)
        {
            request.AddProcessingLog("BillFeed Ingest", "Saving File - BillFeed");
            request.File.Status = Status.Success;
            request.ReturnValue = fileWriteOnlyRepository.Add(request.File);            
            interfaceProgressUseCase.Progress(new InterfaceProgressRequest(request.File.Id, Domain.Upload.Enum.UploadTypeEnum.Billfeed));

            sucessor?.ProcessRequest(request);
        }
    }
}
