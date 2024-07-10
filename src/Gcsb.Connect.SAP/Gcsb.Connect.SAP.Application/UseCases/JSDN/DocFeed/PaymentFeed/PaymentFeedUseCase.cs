using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using System;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.PaymentFeed
{
    public class PaymentFeedUseCase<T> : IPaymentFeedUseCase<T>
    {
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly ISaveFileHandler saveFileHandler;
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public PaymentFeedUseCase(ISaveFileHandler saveFileHandler,
            ILogWriteOnlyRepository logWriteOnlyRepository, IFileReadOnlyRepository fileReadOnlyRepository,
            IFileWriteOnlyRepository fileWriteOnlyRepository, IPublisher<Messaging.Messages.File.File> publisher,
            IConvertHandler<T> convertHandler, IValidateHandler validateHandler,
            ISaveDocsHandler<T> saveDocsHandler, IInsertQueueHandler<T> insertQueueHandler,
            IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.saveFileHandler = saveFileHandler;
            this.fileReadOnlyRepository = fileReadOnlyRepository;
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;

            saveFileHandler.SetSucessor(convertHandler);
            convertHandler.SetSucessor(validateHandler);
            validateHandler.SetSucessor(saveDocsHandler);
            saveDocsHandler.SetSucessor(insertQueueHandler);
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public virtual int Execute(DocFeedRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");            
            try
            {
                // Verifica se arquivo já foi processado
                if (fileReadOnlyRepository.ProcessedFile(request.File.FileName, Status.Success) && !request.File.FileName.StartsWith("Sample"))
                {
                    request.File = fileReadOnlyRepository.GetFile(request.File.FileName, Status.Success);
                    request.AddExceptionLog("PaymentFeed Ingest", $"The file {request.File.FileName} has already been processed.", $"{request.File.FileName}");

                    return 0;
                }
                this.saveFileHandler.ProcessRequest(request);
                
                return 1;
            }
            catch (Exception e)
            {                
                request.AddExceptionLog("PaymentFeed Ingest", e.Message, e.StackTrace);

                if(request.File?.Id != null)
                {
                    fileWriteOnlyRepository.UpdateStatus(request.File.Id, Status.Error);
                    request.File.Status = Status.Error;
                }
                interfaceProgressUseCase.Error(new InterfaceProgressRequest(request.File.Id, 
                    request.File.Type == TypeRegister.PAYMENTBOLETOTSV ? Domain.Upload.Enum.UploadTypeEnum.PaymentFeedBoleto : Domain.Upload.Enum.UploadTypeEnum.PaymentFeedCreditCard));
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
