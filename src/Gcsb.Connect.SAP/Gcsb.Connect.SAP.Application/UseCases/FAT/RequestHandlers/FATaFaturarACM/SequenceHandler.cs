using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT.IRequestHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarACM
{
    public class SequenceHandler : Handler, ISequenceHandler<Domain.FAT.FATaFaturarACM.FATaFaturarACM>
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;

        public SequenceHandler(IFileReadOnlyRepository fileReadOnlyRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Consulting sequencial file - FAT a Faturar");
            request.SequenceFile = fileReadOnlyRepository.GetSequentialFileByCycle(Messaging.Messages.File.Enum.TypeRegister.FATAFATURARACM);

            sucessor?.ProcessRequest(request);
        }
    }
}
