using System;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.Application.UseCases.PAS.RequestHandlers;

namespace Gcsb.Connect.SAP.Application.UseCases.PAS
{
    public class PASUseCase : IPASUseCase
    {
        private readonly PrepareDataHandler prepareDataHandler;
        private readonly InsertQueueHandler insertQueueHandler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public PASUseCase(PrepareDataHandler prepareDataHandler,
            GetCorrectUFAndCityByZipCodeHandler getCorrectUFAndCityByZipCodeHandler,
            GenerateFilePASHandler generateFilePASHandler,
            SaveFileHandler saveFileHandler,
            InsertQueueHandler insertQueueHandler,                  
            ILogWriteOnlyRepository logWriteOnlyRepository,
            IFileWriteOnlyRepository fileWriteOnlyRepository,
            IPublisher<Messaging.Messages.File.File> publisher,
            IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            prepareDataHandler.SetSucessor(getCorrectUFAndCityByZipCodeHandler);
            getCorrectUFAndCityByZipCodeHandler.SetSucessor(generateFilePASHandler);
            generateFilePASHandler.SetSucessor(saveFileHandler);
            saveFileHandler.SetSucessor(insertQueueHandler);
           
            this.prepareDataHandler = prepareDataHandler;
            this.insertQueueHandler = insertQueueHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public int Execute(PASRequest pASRequest)
        {
            PASChainRequest request = new PASChainRequest(pASRequest.File);

            try
            {
                prepareDataHandler.ProcessRequest(request);
                return 1;
            }
            catch (Exception e)
            {
                request.AddExceptionLog(e.Message, e.StackTrace);

                request.PASFile.ForEach(f =>
                {
                    if (f?.Id != null)
                        fileWriteOnlyRepository.Add(f);
                });
                interfaceProgressUseCase.Error(new InterfaceProgressRequest(pASRequest.File.IdParent, Domain.Upload.Enum.UploadTypeEnum.PaymentFeedCreditCard));
                return 0;
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
                request.PASFile.ForEach(f => publisher.PublishAsync(f));
            }

        }
    }
}
