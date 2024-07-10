using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.PAY.RequestHandler;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.PAY
{
    public class CriticalUseCase : ICriticalUseCase
    {
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        public SaveFileHandler SaveFileHandler;

        public CriticalUseCase(
            ILogWriteOnlyRepository logWriteOnlyRepository,
            IFileWriteOnlyRepository fileWriteOnlyRepository,
            SaveFileHandler saveFileHandler,
            GetDateProcesingHandler getDateProcesingHandler,
            CallApiPayHandler callApiPayHandler,
            ValidateHandler validateHandler,
            SaveCriticalHandler saveCriticalHandler,
            ValidatePaymentEmptyHandler validatePaymentEmptyHandler,
            InsertQueueHandler InsertQueueHandler)
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
            this.SaveFileHandler = saveFileHandler;

            saveFileHandler.SetSucessor(getDateProcesingHandler);
            getDateProcesingHandler.SetSucessor(callApiPayHandler);
            callApiPayHandler.SetSucessor(validateHandler);
            validateHandler.SetSucessor(saveCriticalHandler);
            saveCriticalHandler.SetSucessor(validatePaymentEmptyHandler);
            validatePaymentEmptyHandler.SetSucessor(InsertQueueHandler);
        }

        public void Execute(CriticalRequest request)
        {
            try
            {
                SaveFileHandler.ProcessRequest(request);
            }
            catch (Exception ex)
            {
                fileWriteOnlyRepository.UpdateStatus(request.File.Id, Status.Error);
                request.AddLogError(ex.Message, ex.StackTrace);
            }
            finally
            {
                if (request.File?.Id != null)
                {
                    request.Logs.ForEach(s => s.SetFileId(request.File.Id));
                    request.File.Status = request.Logs.Where(x => x.TypeLog == TypeLog.Error).Any() ? Status.Error : Status.Success;
                }

                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
