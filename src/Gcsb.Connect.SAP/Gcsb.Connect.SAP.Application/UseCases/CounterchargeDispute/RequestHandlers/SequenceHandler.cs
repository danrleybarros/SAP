using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class SequenceHandler : Handler
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;

        public SequenceHandler(IFileReadOnlyRepository fileReadOnlyRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Consulting sequencial file - FAT57");
            request.SequenceFile = fileReadOnlyRepository.GetSequentialFile(TypeRegister.AJU);

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
