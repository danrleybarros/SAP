using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT.IRequestHandlers;
namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarACM
{
    public class SaveFATaFaturarHandler : Handler, ISaveFileHandler<Domain.FAT.FATaFaturarACM.FATaFaturarACM>
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        public SaveFATaFaturarHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }
        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Saving File");
            request.Files.ForEach(file => fileWriteOnlyRepository.Add(file));
            sucessor?.ProcessRequest(request);
        }
    }
}