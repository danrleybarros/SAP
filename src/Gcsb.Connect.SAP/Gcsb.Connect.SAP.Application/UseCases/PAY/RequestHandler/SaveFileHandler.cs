using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.PAY.RequestHandler
{
    public class SaveFileHandler : Handler
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }

        public override void ProcessRequest(CriticalRequest request)
        {
            request.AddLog("Saving File on database - CriticalFile");
           
            request.File = new Messaging.Messages.File.File($"CriticalFile_Pay_{DateTime.UtcNow.ToString("dd_MM_yyyy")}.api", TypeRegister.CRITICALFILE)
            {
                IdParent = request.IDPaymentFeed,
                Status = Status.Success
            };

            fileWriteOnlyRepository.Add(request.File);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
