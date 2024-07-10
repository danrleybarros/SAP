using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.Application.UseCases.GF.CISS.RequestHandlers;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.CISS
{
    public class CISSUseCase : ICISSUseCase
    {
        private readonly PrepareDataHandler prepareDataHandler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public CISSUseCase(PrepareDataHandler prepareDataHandler,  
                            GetFileNameHandler getFileNameHandler,
                            GenerateFileHandler generateFileHandler,
                            SaveFileHandler saveFileHandler,                            
                            SaveCISSHandler saveCISSHandler,
                            ValidateHandler validateHandler,
                            InsertQueueHandler insertQueueHandler,
                            ILogWriteOnlyRepository logWriteOnlyRepository,
                            IPublisher<Messaging.Messages.File.File> publisher,
                            IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            prepareDataHandler.SetSucessor(validateHandler);
            validateHandler.SetSucessor(getFileNameHandler);
            getFileNameHandler.SetSucessor(saveFileHandler);
            saveFileHandler.SetSucessor(generateFileHandler);
            generateFileHandler.SetSucessor(saveCISSHandler);
            saveCISSHandler.SetSucessor(insertQueueHandler);
            this.prepareDataHandler = prepareDataHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public int Execute(CISSRequest request)
        {            
            try
            {                
                prepareDataHandler.ProcessRequest(request);                
                return 1;
            }
            catch (Exception e)
            {                
                request.AddExceptionLog(e.Message, e.StackTrace);
                interfaceProgressUseCase.Error(new InterfaceProgressRequest(request.IdFileReturnNF, Domain.Upload.Enum.UploadTypeEnum.ReturnNF));
                return 0;
            }
            finally
            {
                if (request.File?.Id != null)
                {
                    request.Logs.ForEach(s => s.SetFileId(request.File.Id));
                    request.File.Logs = request.Logs;
                }
                logWriteOnlyRepository.Add(request.Logs);
                publisher.PublishAsync(request.File); // Send to Reprocessing a file copy 
            }
        }
    }
}
