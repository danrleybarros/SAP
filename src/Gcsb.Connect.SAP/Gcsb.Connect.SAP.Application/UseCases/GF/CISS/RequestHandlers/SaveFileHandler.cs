using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.CISS.RequestHandlers
{
    public class SaveFileHandler : Handler
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }

        public override void ProcessRequest(CISSRequest request)
        {            
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Saving File - CISS"));
            request.File = new Connect.Messaging.Messages.File.File(request.CISSFileName, TypeRegister.CISS)
            {
                IdParent = request.IdFileReturnNF,
                Status = Status.Success
            };

            fileWriteOnlyRepository.Add(request.File);

            if (base.sucessor != null)
                base.sucessor.ProcessRequest(request);
        }
    }
}