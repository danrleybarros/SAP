using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.BillFeed.RequestHandlers
{
    public class VerifyFileHandler : Handler<BillFeedChainRequest>
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;

        public VerifyFileHandler(IFileReadOnlyRepository fileReadOnlyRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public override void ProcessRequest(BillFeedChainRequest request)
        {
            if (fileReadOnlyRepository.ProcessedFile(request.File.FileName, Status.Success) && !request.File.FileName.StartsWith("Sample"))
            {
                request.File = fileReadOnlyRepository.GetFile(request.File.FileName, Status.Success);
                request.AddExceptionLog("BillFeed Ingest", $"The file {request.File.FileName} has already been processed.", $"{request.File.FileName}");
                request.ReturnValue = 0;

                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
