using Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService.RequestHandlers;
using Gcsb.Connect.SAP.Application.Repositories;
using System;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService
{
    public class ISIUseCase : IISIUseCase
    {
        private readonly PrepareDataHandler prepareDataHandler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public ISIUseCase(PrepareDataHandler prepareDataHandler, 
            ValidateHandler validateHandler,
            GetFileNameHandler getFileNameHandler, 
            CreateISIFileHandler createISIFileHandler,
            SaveISIHandler saveISIHandler, 
            SaveFileHandler saveFileHandler,
            InsertQueueHandler insertQueueHandler,
            ILogWriteOnlyRepository logWriteOnlyRepository,
            IPublisher<Messaging.Messages.File.File> publisher,
            IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            prepareDataHandler.SetSucessor(validateHandler);
            validateHandler.SetSucessor(getFileNameHandler);
            getFileNameHandler.SetSucessor(saveFileHandler);
            saveFileHandler.SetSucessor(createISIFileHandler);
            createISIFileHandler.SetSucessor(saveISIHandler);
            saveISIHandler.SetSucessor(insertQueueHandler);

            this.prepareDataHandler = prepareDataHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public int Execute(ISIRequest iSIRequest)
        {
            ISIChainRequest request = new ISIChainRequest(iSIRequest.IdNFFile);

            try
            {
                prepareDataHandler.ProcessRequest(request);
                return 1;
            }
            catch(Exception e)
            {
                request.Logs.Add(request.ISIFile == null ? Log.CreateExceptionLog(request.Service, e.Message, e.StackTrace) : 
                    Log.CreateExceptionLog(request.Service, request.ISIFile.Id, e.Message, e.StackTrace));
                interfaceProgressUseCase.Error(new InterfaceProgressRequest(iSIRequest.IdNFFile, Domain.Upload.Enum.UploadTypeEnum.ReturnNF));
                return 0;
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
                if (request.ISIFile?.Id != null)
                    request.ISIFile.Logs = request.Logs;
                publisher.PublishAsync(request.ISIFile); // Send to Reprocessing a file copy 
            }
        }
    }
}
