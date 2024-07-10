using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Client.RequestHandlers
{
    public class SaveFileHandler : Handler
    {
        private readonly IFileWriteOnlyRepository FileWriteOnlyRepository;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository, IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            this.FileWriteOnlyRepository = fileWriteOnlyRepository;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public override void ProcessRequest(ClientChainRequest request)
        {            
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Saving File - Client GF"));
            request.ClientFile = new Connect.Messaging.Messages.File.File(request.FileName, Connect.Messaging.Messages.File.Enum.TypeRegister.CLIENT) {
                Status = Connect.Messaging.Messages.File.Enum.Status.Success,
                IdParent = request.IdFile
            };

            FileWriteOnlyRepository.Add(request.ClientFile);
            interfaceProgressUseCase.Progress(new InterfaceProgressRequest(request.ClientFile.IdParent, Domain.Upload.Enum.UploadTypeEnum.ReturnNF));

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
