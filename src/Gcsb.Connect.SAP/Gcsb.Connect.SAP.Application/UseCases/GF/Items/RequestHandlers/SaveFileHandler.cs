using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers
{
    public class SaveFileHandler : Handler
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }

        public override void ProcessRequest(ItemsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Object request is null");
           
            request.Logs.Add(Log.CreateProcessingLog(request.Service, $"Trying save a file object, with file name: {request.FileName}"));

            request.File = new Connect.Messaging.Messages.File.File(request.FileName, TypeRegister.ITEMS)
            {
                IdParent = request.IdNFFile,
                Status = Status.Success
            };

            fileWriteOnlyRepository.Add(request.File);
            
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
