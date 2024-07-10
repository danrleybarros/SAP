using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.UploadType;
using Gcsb.Connect.SAP.Domain;
using Gcsb.Connect.SAP.Domain.UploadTypeDto;
using System.Collections.Generic;

namespace Gcsb.Connect.FakeEnv.Application.UseCases.Files.GetUploadType.Handlers
{
    public class GetUploadTypeHandler : Handler<GetUploadTypeUseCaseRequest>
    {
 
        public override void ProcessRequest(GetUploadTypeUseCaseRequest request)
        {
            request.AddProcessingLog("GetUploadTypeHandler", $"Executing GetUploadTypeHandler, UserId: {request.UserId}");

            List<UploadTypeDto> uploadTypes = Util.GetAllUploadType();

            if (uploadTypes == null || uploadTypes.Count == 0)
            {
                request.AddProcessingLog("GetUploadTypeHandler", $"Not found upload types: UserId:{request.UserId}");
                return;
            }

            request.UploadTypes = uploadTypes;
            request.HasExecuted = true;

            sucessor?.ProcessRequest(request);
        }
    }
}
