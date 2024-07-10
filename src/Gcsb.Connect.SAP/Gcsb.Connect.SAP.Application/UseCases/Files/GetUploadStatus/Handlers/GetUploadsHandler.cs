using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories.Upload;
using Gcsb.Connect.SAP.Domain.Upload;

namespace Gcsb.Connect.SAP.Application.UseCases.File.RequestHandlers
{
    public class GetUploadsHandler : Handler<UploadStatusRequest>
    {
        private readonly IUploadReadOnlyRepository uploadReadOnlyRepository;
        private readonly IOutputPort<List<UploadStatusDto>> outputPort;

        public GetUploadsHandler(IUploadReadOnlyRepository uploadReadOnlyRepository, IOutputPort<List<UploadStatusDto>> outputPort)
        {
            this.uploadReadOnlyRepository = uploadReadOnlyRepository;
            this.outputPort = outputPort;
        }

        public override void ProcessRequest(UploadStatusRequest request)
        {
            request.AddProcessingLog($"Executing UploadStatusHandler UserID:{request.UserId}", $"UploadStatusHandler");
            request.Uploads = uploadReadOnlyRepository.GetAll();
            if (request.Uploads == null || request.Uploads.Count == 0)
            {
                outputPort.NotFound("Not found Uploads to show");
                return;
            }    
            
            sucessor?.ProcessRequest(request);

        }
    }
}

 




     

