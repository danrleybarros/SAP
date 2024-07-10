using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT
{
    public abstract class FATUseCase<T> : IFATUseCase<T>
    {
        private readonly ISequenceHandler<T> sequenceHandler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;

        public FATUseCase(ISequenceHandler<T> sequenceHandler,
                          ILogWriteOnlyRepository logWriteOnlyRepository,
                          IFileWriteOnlyRepository fileWriteOnlyRepository,
                          IPublisher<Messaging.Messages.File.File> publisher,
                          IInterfaceProgressUseCase interfaceProgressUseCase,
                          IFileReadOnlyRepository fileReadOnlyRepository)
        {
            this.sequenceHandler = sequenceHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public int Execute(FATRequest request)
        {
            try
            {
                if (!fileReadOnlyRepository.GetFiles(w => w.Type.Equals(request.TypeRegister) && w.IdParent.Value.Equals(request.IdBillFeed)).Any())
                    sequenceHandler.ProcessRequest(request);

                return 1;
            }
            catch (Exception e)
            {
                request.AddExceptionLog(e.Message, e.StackTrace);

                request.Files.ForEach(f =>
                {
                    if (f?.Id != null)
                        fileWriteOnlyRepository.UpdateStatus(f.Id, Status.Error);
                });
                interfaceProgressUseCase.Error(new InterfaceProgressRequest(request.Files.FirstOrDefault()?.IdParent, Domain.Upload.Enum.UploadTypeEnum.Billfeed));
                return 0;
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);

                request.Files.ForEach(f => publisher.PublishAsync(f)); // Send to Reprocessing a file copy 
            }
        }
    }
}
