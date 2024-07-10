using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT.IRequestHandlers;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH
{
    public class SequenceHandler : Handler, ISequenceHandler<Domain.FAT.FATFaturado.FATFaturado>
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;

        public SequenceHandler(IFileReadOnlyRepository fileReadOnlyRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Consulting sequencial file - FAT");                       
            request.SequenceFile = fileReadOnlyRepository.GetSequentialFileByCycle(Messaging.Messages.File.Enum.TypeRegister.FAT);

            sucessor?.ProcessRequest(request);
        }
    }
}
