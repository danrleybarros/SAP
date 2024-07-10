using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.BillFeed.RequestHandlers;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed
{
    public class BillFeedUseCase : IBillFeedUseCase
    {
        private readonly VerifyFileHandler verifyFileHandler;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public BillFeedUseCase(VerifyFileHandler verifyFileHandler,
            SaveFileHandler saveFileHandler,
            ConvertHandler convertHandler,
            FilterDocFeedhandler filterDocFeedhandler,
            ValidateHandler validateHandler,
            SplitBillFeedDocHandler splitBillFeedDocHandler,
            SaveDocsHandler saveDocsHandler,
            SaveBillFeedSplitHandler saveBillFeedSplitHandler,
            InsertQueueHandler insertQueueHandler,
            IFileWriteOnlyRepository fileWriteOnlyRepository,
            ILogWriteOnlyRepository logWriteOnlyRepository,
            IPublisher<Messaging.Messages.File.File> publisher,
            IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            verifyFileHandler.SetSucessor(saveFileHandler);
            saveFileHandler.SetSucessor(convertHandler);
            convertHandler.SetSucessor(filterDocFeedhandler);
            filterDocFeedhandler.SetSucessor(validateHandler);
            validateHandler.SetSucessor(splitBillFeedDocHandler);
            splitBillFeedDocHandler.SetSucessor(saveDocsHandler);
            saveDocsHandler.SetSucessor(saveBillFeedSplitHandler);
            saveBillFeedSplitHandler.SetSucessor(insertQueueHandler); 

            this.verifyFileHandler = verifyFileHandler;
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public int Execute(DocFeedRequest request)
        {
            var requestChain = new BillFeedChainRequest(request);

            try
            {
                verifyFileHandler.ProcessRequest(requestChain);
            }
            catch (Exception ex)
            {
                requestChain.AddExceptionLog("BillFeed Ingest", ex.InnerException?.Message ?? ex.Message, ex.StackTrace);
                requestChain.ReturnValue = 0;

                if (requestChain.File?.Id != null)
                    fileWriteOnlyRepository.UpdateStatus(requestChain.File.Id, Status.Error);

                interfaceProgressUseCase.Error(new InterfaceProgressRequest(request.File.Id, Domain.Upload.Enum.UploadTypeEnum.Billfeed));
            }
            finally
            {
                SaveFile(requestChain);
                publisher.PublishAsync(requestChain.File);
            }

            return requestChain.ReturnValue;
        }

        private void SaveFile(BillFeedChainRequest requestChain)
        {
            if (requestChain.File?.Id != null)
            {
                requestChain.Logs.ForEach(s => s.SetFileId(requestChain.File.Id));
                requestChain.File.Logs = requestChain.Logs;
                requestChain.File.Status = Status.Success;

                if (requestChain.ReturnValue <= 0)
                    fileWriteOnlyRepository.UpdateStatus(requestChain.File.Id, Status.Error);
            }

            logWriteOnlyRepository.Add(requestChain.Logs);
        }
    }
}
