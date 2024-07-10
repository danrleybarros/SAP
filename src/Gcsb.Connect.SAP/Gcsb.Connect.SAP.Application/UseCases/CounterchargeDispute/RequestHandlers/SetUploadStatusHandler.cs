using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories.Upload;
using Gcsb.Connect.SAP.Domain.Upload.Enum;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class SetUploadStatusHandler
    {
        private readonly IUploadWriteOnlyRepository uploadWriteOnlyRepository;

        public SetUploadStatusHandler(IUploadWriteOnlyRepository uploadWriteOnlyRepository)
        {
            this.uploadWriteOnlyRepository = uploadWriteOnlyRepository;
        }

        public async Task UpdateStatus(CounterchargeDisputeRequest request, StatusType status)
        {            
            switch (status)
            {
                case StatusType.Processing:
                    request.AddProcessingLog("RegisterUploadHandler - Processing");

                    request.Upload = new Domain.Upload.Upload(request.InterfaceProgressIdParent,
                            UploadTypeEnum.Fat57_79, request.LoginName, DateTime.UtcNow,
                            "FAT 57-79", status);

                    uploadWriteOnlyRepository.Add(request.Upload);
                    break;
                case StatusType.Success:
                    request.AddProcessingLog("RegisterUploadHandler - Success");

                    request.Upload = new Domain.Upload.Upload(request.InterfaceProgressIdParent,
                            request.Upload.UploadType, request.Upload.UserId, request.Upload.UploadDate,
                            (request.FileName ?? "FAT 57-79"), status);

                    uploadWriteOnlyRepository.Update(request.Upload);
                    break;
                case StatusType.Error:
                    request.AddProcessingLog("RegisterUploadHandler - Error");

                    request.Upload = new Domain.Upload.Upload(request.Upload.Id,
                            request.Upload.UploadType, request.Upload.UserId, request.Upload.UploadDate,
                            request.Upload.FileName, status);

                    uploadWriteOnlyRepository.Update(request.Upload);
                    break;
                default:
                    break;
            }
        }

    }
}
