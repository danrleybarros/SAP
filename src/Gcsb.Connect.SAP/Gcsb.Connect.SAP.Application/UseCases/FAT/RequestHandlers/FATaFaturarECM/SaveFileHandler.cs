using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT.IRequestHandlers;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarECM
{
    public class SaveFileHandler : Handler, ISaveFileHandler<Domain.FAT.FATaFaturarECM.FATaFaturarECM>
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
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
