using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.ReturnNF.ReturnNFHandlers
{
    public class VerifyProcessFileHandler : Handler
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;

        public VerifyProcessFileHandler(IFileReadOnlyRepository fileReadOnlyRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public override void ProcessRequest(ReturnNFRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, $"The file {request.File.FileName} will be processed"));

            if (fileReadOnlyRepository.ProcessedFile(request.File.FileName, Status.Success) && !request.File.FileName.StartsWith("Sample"))
            {
                request.File = fileReadOnlyRepository.GetFile(request.File.FileName, Status.Success);
                request.Logs.Add(Log.CreateExceptionLog(request.Service, $"The file {request.File.FileName} has already been processed.", $"{request.File.FileName}"));

                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
