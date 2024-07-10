using System;
using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.File;
using Gcsb.Connect.SAP.Domain.Upload;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.GetUploadStatus.Handlers
{
    public class GetInterfacesLogsHandler : Handler<UploadStatusRequest>
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;
        private readonly ILogReadOnlyRepository logReadOnlyRepository;

        public GetInterfacesLogsHandler(IFileReadOnlyRepository fileReadOnlyRepository, ILogReadOnlyRepository logReadOnlyRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
            this.logReadOnlyRepository = logReadOnlyRepository;
        }
        public override void ProcessRequest(UploadStatusRequest request)
        {
            request.AddProcessingLog("GetInterfacesHandler", "Get interfaces status/logs");
            
            var ids = request.Uploads.Select(s => s.Id).ToList();
            var interfaces = fileReadOnlyRepository.GetFiles(s => ids.Contains((Guid)s.IdParent));

            request.Output = new List<UploadStatusDto>();
            foreach (var upload in request.Uploads)
            {
                var fileId = request.UploadFiles.Where(s => s.FileName == upload.FileName).Select(s => s.Id).FirstOrDefault();
                fileId = fileId != new Guid() ? fileId : request.UploadFiles.Where(s => s.IdParent == upload.Id).Select(s => s.Id).FirstOrDefault();

                var uploadStatus = new UploadStatusDto()
                {
                    Id = upload.Id,
                    FileId = fileId,
                    FileName = upload.FileName,
                    StatusType = upload.StatusType,
                    UploadDate = (DateTime)upload.UploadDate,
                    UploadType = upload.UploadType,
                    UserId = upload.UserId,                    
                    Logs = logReadOnlyRepository.GetLogsByFileId(request.UploadFiles.Where(s => s.FileName == upload.FileName).Select(s => s.Id).FirstOrDefault()).OrderBy(s => s.DateLog).ToList(), 
                };
                // Logs from interfaces
                var interfacesFromParent = interfaces.Where(s => s.IdParent == uploadStatus.FileId).Select(s => s.Id).ToList();
                interfacesFromParent = interfacesFromParent.Count != 0 ? interfacesFromParent : interfaces.Where(s => s.IdParent == uploadStatus.Id).Select(s => s.Id).ToList();                
                uploadStatus?.Logs.AddRange(logReadOnlyRepository.GetLogs(s => interfacesFromParent.Contains((Guid)s.FileId)).OrderBy(s=>s.DateLog));

                request.Output.Add(uploadStatus);
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
