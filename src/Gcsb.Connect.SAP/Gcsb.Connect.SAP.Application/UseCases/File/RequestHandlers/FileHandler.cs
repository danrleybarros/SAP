using System;
using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.File.RequestHandlers
{
    public class FileHandler : IFileHandler
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;
        private readonly IInsertQueueHandler handler;

        public FileHandler(IFileReadOnlyRepository fileReadOnlyRepository, IInsertQueueHandler handler)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
            this.handler = handler;
        }

        public void FileReprocessRequest(FileReprocessRequest request)
        {
            try
            {
                if (request == null)
                    throw new NullReferenceException("File Identification is null.");

                Connect.Messaging.Messages.File.File file = fileReadOnlyRepository.GetById(request.FileId);

                if (file == null)
                    throw new NullReferenceException("File Identification Parent is null.");

                handler.FileReprocess(file);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
