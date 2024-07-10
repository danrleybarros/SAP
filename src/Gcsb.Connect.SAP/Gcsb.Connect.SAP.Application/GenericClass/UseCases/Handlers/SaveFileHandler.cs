using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using System;
using Gcsb.Connect.Messaging.Messages.Log.Enum;

namespace Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers
{
    public class SaveFileHandler<T> : Handler<T>, ISaveFileHandler<T>
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }

        public override void ProcessRequest(T request)
        {
            ((IRequest)request).AddLog($"Trying save a file object, with file name: {((IRequest)request).FileName}", TypeLog.Processing);

            ((IRequest)request).File = new Connect.Messaging.Messages.File.File(((IRequest)request).FileName, ((IRequest)request).TypeInterface)
            {
                IdParent = ((IRequest)request).IdNFFile,
                Status = Status.Success
            };

            var result = fileWriteOnlyRepository.Add(((IRequest)request).File);

            if (result < 1)
                throw new ApplicationException("Occurred an error in SaveFileHandler");

            sucessor?.ProcessRequest(request);
        }
    }
}
