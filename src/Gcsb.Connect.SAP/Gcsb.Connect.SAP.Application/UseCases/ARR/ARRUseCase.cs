using System;
using System.Linq;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR
{
    public class ARRUseCase<T> : IARRUseCase<T>
    {
        private readonly IServicesHandler<T> servicesHandler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public ARRUseCase(ISequenceHandler<T> sequenceHandler,
                          IServicesHandler<T> servicesHandler,
                          IAccountsHandler<T> accountsHandler,
                          ILaunchHandler<T> launchHandler,
                          IGenerateFileHandler<T> generateFileHandler,
                          ISaveFileHandler<T> saveFileHandler,
                          IInsertQueueHandler<T> insertQueueHandler,
                          ILogWriteOnlyRepository logWriteOnlyRepository,
                          IFileWriteOnlyRepository fileWriteOnlyRepository,
                          IPublisher<Messaging.Messages.File.File> publisher,
                          IGetAccountingEntryHandler<T> getAccountingEntryHandler,
                          IGetPaymetFeedHandler<T> getPaymetFeedHandler,
                          IGetCriticalHandler<T> getCriticalHandler,
                          IManualPaymentLaunchHandler<T> manualPaymentLaunchHandler,
                          IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            servicesHandler.SetSucessor(sequenceHandler);
            sequenceHandler.SetSucessor(accountsHandler);
            accountsHandler.SetSucessor(getAccountingEntryHandler);
            getAccountingEntryHandler.SetSucessor(getPaymetFeedHandler);
            getPaymetFeedHandler.SetSucessor(getCriticalHandler);
            getCriticalHandler.SetSucessor(launchHandler);
            launchHandler.SetSucessor(manualPaymentLaunchHandler);
            manualPaymentLaunchHandler.SetSucessor(generateFileHandler);
            generateFileHandler.SetSucessor(saveFileHandler);
            saveFileHandler.SetSucessor(insertQueueHandler);

            this.servicesHandler = servicesHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public int Execute(IARRRequest<T> request)
        {
            if (request == null)
                throw new ArgumentNullException("Requets object is null");
            try
            {
                servicesHandler.ProcessRequest(request);
                return 1;
            }
            catch (Exception e)
            {
                request.AddExceptionLog(e.Message, e.StackTrace);
                interfaceProgressUseCase.Error(new InterfaceProgressRequest(request.Files.FirstOrDefault()?.IdParent,
                    request.Files.FirstOrDefault()?.Type == TypeRegister.PAYMENTBOLETOTSV ? Domain.Upload.Enum.UploadTypeEnum.PaymentFeedBoleto : Domain.Upload.Enum.UploadTypeEnum.PaymentFeedCreditCard));
                return 0;
            }
            finally
            {
                if (request.Files?.Count > 0)
                {
                    request.Logs.ForEach(s => s.SetFileId(request.Files.FirstOrDefault().Id));

                    request.Files.ForEach(f =>
                    {
                        f.Logs = request.Logs;
                        f.Status = request.Logs.Where(x => x.TypeLog == TypeLog.Error).Any() ? Status.Error : Status.Success;

                        publisher.PublishAsync(f); // Send to Reprocessing a file copy 
                    });                    
                }

                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
