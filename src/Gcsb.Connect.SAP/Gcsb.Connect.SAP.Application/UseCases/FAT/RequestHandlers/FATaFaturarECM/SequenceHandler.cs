using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT.IRequestHandlers;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarECM
{
    public class SequenceHandler : Handler, ISequenceHandler<Domain.FAT.FATaFaturarECM.FATaFaturarECM>
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;

        public SequenceHandler(IFileReadOnlyRepository fileReadOnlyRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Consulting sequencial file - FAT a Faturar");
            request.SequenceFile = fileReadOnlyRepository.GetSequentialFileByCycle(TypeRegister.FATAFATURARECM);

            sucessor?.ProcessRequest(request);
        }
    }
}
