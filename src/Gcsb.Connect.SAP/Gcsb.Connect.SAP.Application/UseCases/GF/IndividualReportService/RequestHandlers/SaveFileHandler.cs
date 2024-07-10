using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService.RequestHandlers
{
    public class SaveFileHandler : Handler
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }

        public override void ProcessRequest(ISIChainRequest request)
        {            
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Saving File - Individual Report Service"));
            request.ISIFile = new Connect.Messaging.Messages.File.File(request.ISIFileName, Connect.Messaging.Messages.File.Enum.TypeRegister.ISI)
            {
                IdParent = request.IdFile,
                Status = Connect.Messaging.Messages.File.Enum.Status.Success
            };

            fileWriteOnlyRepository.Add(request.ISIFile);

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
