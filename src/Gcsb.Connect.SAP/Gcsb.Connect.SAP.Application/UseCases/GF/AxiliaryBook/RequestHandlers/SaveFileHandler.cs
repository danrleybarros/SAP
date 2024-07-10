using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook.RequestHandlers
{
    public class SaveFileHandler : Handler
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }

        public override void ProcessRequest(AxiliaryBookRequest request)
        {
            request.AddProcessingLog("Saving File on database - Axiliary Book");           

            var fileName = $"GW_LIVRO_{DateTime.UtcNow.ToString("dd")}_{DateTime.UtcNow.ToString("MMyyyy")}.TXT";

            request.File = new Connect.Messaging.Messages.File.File(fileName, TypeRegister.AXILIARYBOOK, DateTime.UtcNow)
            {
                IdParent = request.IdFileReturnNF,
                Status = Status.Success
            };

            fileWriteOnlyRepository.Add(request.File);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
