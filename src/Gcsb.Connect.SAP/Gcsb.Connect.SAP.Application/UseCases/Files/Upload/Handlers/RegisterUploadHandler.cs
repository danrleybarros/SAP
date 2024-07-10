using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories.Upload;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Upload.Handlers
{
    public class RegisterUploadHandler : Handler<UploadUseCaseRequest>
    {
        private readonly IUploadWriteOnlyRepository uploadWriteOnlyRepository;

        public RegisterUploadHandler(IUploadWriteOnlyRepository uploadWriteOnlyRepository)
        {
            this.uploadWriteOnlyRepository = uploadWriteOnlyRepository;
        }

        public override void ProcessRequest(UploadUseCaseRequest request)
        {
            request.AddProcessingLog("RegisterUploadHandler");

            uploadWriteOnlyRepository.Add(new Domain.Upload.Upload(Guid.NewGuid(),
                request.UploadType, request.UserId, DateTime.UtcNow, 
                request.FileName, Domain.Upload.Enum.StatusType.Processing));
            
            sucessor?.ProcessRequest(request);
        }
    }
}
