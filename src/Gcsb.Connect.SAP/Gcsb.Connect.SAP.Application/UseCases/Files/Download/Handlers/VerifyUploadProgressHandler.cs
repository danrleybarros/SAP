using System.Linq;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Upload;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Download.Handlers
{
    public class VerifyUploadProgressHandler : Handler<DownloadUseCaseRequest>
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;
        private readonly IInterfaceProgressRepository interfaceProgressRepository;

        public VerifyUploadProgressHandler(IFileReadOnlyRepository fileReadOnlyRepository, IInterfaceProgressRepository interfaceProgressRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
            this.interfaceProgressRepository = interfaceProgressRepository;
        }
        public override void ProcessRequest(DownloadUseCaseRequest request)
        {
            request.AddProcessingLog("VerifyUploadProgressHandler");

            var file = fileReadOnlyRepository.GetFiles(s => s.Id == request.FileId).FirstOrDefault();
            if (file == null)
            {
                request.AddExceptionLog("FileId Not Found", "FileId Not Found");
                return;
            }

            request.InterfacesProgress = interfaceProgressRepository.GetByFilter(s => s.IdParent == file.Id || s.IdParent == file.IdParent).ToList();
            if (request.InterfacesProgress == null || request.InterfacesProgress?.Count == 0)
            {
                request.AddExceptionLog("Interfaces Not Found to Download", "Interfaces Not Found to Download");
                return;
            }

            if (request.InterfacesProgress.Any(s=>s.StatusType == Domain.Upload.Enum.StatusType.Error || s.StatusType == Domain.Upload.Enum.StatusType.Processing))
            {
                request.AddExceptionLog("Some interfaces are processing or get error", "Some interfaces are processing or get error");
                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
