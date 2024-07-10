using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories.Upload;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Upload.Handlers
{
    public class UploadFileHandler : Handler<UploadUseCaseRequest>
    {
        private readonly IUploadService uploadService;
        private readonly string destLocalPath;

        public UploadFileHandler(IUploadService uploadService)
        {
            this.uploadService = uploadService;
            this.destLocalPath = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
        }
        public override void ProcessRequest(UploadUseCaseRequest request)
        {
            request.AddProcessingLog("UploadFileHandler");
            uploadService.Upload(request.FileName, request.Base64, destLocalPath);
            sucessor?.ProcessRequest(request);
        }
    }
}
