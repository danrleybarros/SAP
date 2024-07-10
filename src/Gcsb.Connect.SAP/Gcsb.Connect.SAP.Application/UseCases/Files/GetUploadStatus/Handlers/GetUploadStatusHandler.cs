using System;
using System.Linq;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Upload;
using Gcsb.Connect.SAP.Application.UseCases.File;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.GetUploadStatus.Handlers
{
    public class GetUploadStatusHandler : Handler<UploadStatusRequest>
    {
        private readonly IInterfaceProgressRepository interfaceProgressRepository;
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;
        private readonly IUploadWriteOnlyRepository uploadWriteOnlyRepository;

        public GetUploadStatusHandler(IInterfaceProgressRepository interfaceProgressRepository, IFileReadOnlyRepository fileReadOnlyRepository, IUploadWriteOnlyRepository uploadWriteOnlyRepository)
        {
            this.interfaceProgressRepository = interfaceProgressRepository;
            this.fileReadOnlyRepository = fileReadOnlyRepository;
            this.uploadWriteOnlyRepository = uploadWriteOnlyRepository;
        }

        public override void ProcessRequest(UploadStatusRequest request)
        {
            request.AddProcessingLog("GetUploadStatusHandler", "GetUploadStatusHandler");
            // fat 57 79
            var uploadFats57_79 = request.Uploads.Where(s=> s.UploadType == Domain.Upload.Enum.UploadTypeEnum.Fat57_79 && !string.IsNullOrEmpty(s.FileName)).Select(s => s.Id).ToList();
            request.UploadFiles.AddRange(fileReadOnlyRepository.GetFiles(s => uploadFats57_79.Contains(s.IdParent ?? new Guid())));

            var fileNames = request.Uploads.Select(s => s.FileName).Where(s=> !string.IsNullOrEmpty(s)).ToList();
            request.UploadFiles.AddRange(fileReadOnlyRepository.GetFiles(s => fileNames.Contains(s.FileName)));
            var idParents = request.UploadFiles.Select(s=>s.Id).ToList();
            var interfacesProgress = interfaceProgressRepository.GetByFilter(s => idParents.Contains((Guid)s.IdParent));

            foreach (var upload in request.Uploads)
            {
                var file = request.UploadFiles.Where(s => s.FileName == upload.FileName).FirstOrDefault() ?? request.UploadFiles.Where(s => s.IdParent == upload.Id).FirstOrDefault();
                var someInterfaceGetError = interfacesProgress.Any(s => (s.IdParent == file?.Id || s.IdParent == file?.IdParent) && s.StatusType == Domain.Upload.Enum.StatusType.Error);
                var someInterfaceIsProcessing = interfacesProgress.Any(s => (s.IdParent == file?.Id || s.IdParent == file?.IdParent) && s.StatusType == Domain.Upload.Enum.StatusType.Processing);
                var someInterfaceGeneratedSuccessfully = interfacesProgress.Any(s => (s.IdParent == file?.Id || s.IdParent == file?.IdParent) && s.StatusType == Domain.Upload.Enum.StatusType.Success);

                if (someInterfaceGetError)                
                    upload.SetStatus(Domain.Upload.Enum.StatusType.Error);
                else if (someInterfaceIsProcessing)
                    upload.SetStatus(Domain.Upload.Enum.StatusType.Processing);
                else if (someInterfaceGeneratedSuccessfully)
                    upload.SetStatus(Domain.Upload.Enum.StatusType.Success);

                uploadWriteOnlyRepository.Update(upload);
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
