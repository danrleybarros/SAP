using Gcsb.Connect.SAP.Application.Repositories;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.CISS.RequestHandlers
{
    public class SequenceHandler : Handler
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;

        public SequenceHandler(IFileReadOnlyRepository fileReadOnlyRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public override void ProcessRequest(CISSRequest request)
        {
            request.AddProcessingLog("Consulting sequencial file - CISS");
            if (request == null)
                throw new ArgumentNullException("Null request object");
            
            request.SequenceFile = fileReadOnlyRepository.GetSequentialFile(Connect.Messaging.Messages.File.Enum.TypeRegister.CISS);
            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
