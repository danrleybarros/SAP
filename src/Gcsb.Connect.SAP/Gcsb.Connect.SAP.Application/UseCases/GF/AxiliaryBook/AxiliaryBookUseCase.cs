using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook.RequestHandlers;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook
{
    public class AxiliaryBookUseCase : IAxiliaryBookUseCase
    {
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly ProcessHandler processHandler;

        public AxiliaryBookUseCase(ILogWriteOnlyRepository logWriteOnlyRepository, IFileWriteOnlyRepository fileWriteOnlyRepository, IPublisher<Messaging.Messages.File.File> publisher,
            ProcessHandler processHandler,
            SaveFileHandler saveFileHandler,
            GetReturnNF getReturnNF,
            GetInvoiceHandler getInvoiceHandler,
            GetFinancialAccountsHandler getFinancialAccountsHandler,
            ValidateAllServiceCodeHandler validateAccountingAccountHandler,
            LaunchHandler launchHandler,
            ValidateHandler validateHandler,
            GetFileNameHandler getFileNameHandler,
            GenerateFileHandler generateFileHandler
           )
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
            this.publisher = publisher;
            this.processHandler = processHandler;

            processHandler.SetSucessor(saveFileHandler);
            saveFileHandler.SetSucessor(getReturnNF);
            getReturnNF.SetSucessor(getInvoiceHandler);
            getInvoiceHandler.SetSucessor(getFinancialAccountsHandler);
            getFinancialAccountsHandler.SetSucessor(validateAccountingAccountHandler);
            validateAccountingAccountHandler.SetSucessor(launchHandler);
            launchHandler.SetSucessor(validateHandler);
            validateHandler.SetSucessor(getFileNameHandler);
            getFileNameHandler.SetSucessor(generateFileHandler);
            
        }

        public int Execute(AxiliaryBookRequest request)
        {
            try
            {
                processHandler.ProcessRequest(request);
                return 1;
            }
            catch (Exception e)
            {
                request.AddExceptionLog(e.Message, e.StackTrace);
                fileWriteOnlyRepository.UpdateStatus(request.File.Id, Status.Error);
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
                publisher.PublishAsync(request.File);
            }
        }
    }
}
