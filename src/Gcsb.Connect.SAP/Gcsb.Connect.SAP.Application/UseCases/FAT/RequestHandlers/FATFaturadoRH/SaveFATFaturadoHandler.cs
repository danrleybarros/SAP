using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT.IRequestHandlers;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public class SaveFATFaturadoHandler : Handler, ISaveFATHandler<Domain.FAT.FATFaturado.FATFaturado>
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFATFaturadoHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
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
