using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.File.Enum;

namespace Gcsb.Connect.SAP.Application.UseCases.PAS.RequestHandlers
{
    public class SaveFileHandler : Handler
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;

        }

        public override void ProcessRequest(PASChainRequest request)
        {
            request.AddProcessingLog("Saving File - PAS");

            request.PASFile.ForEach(file => fileWriteOnlyRepository.Add(file));

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
