using System;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Lei1601.RequestHandlers;

namespace Gcsb.Connect.SAP.Application.UseCases.Lei1601
{
    public class Lei1601UseCase : ILei1601UseCase
    {
        private readonly DeleteOldFilesHandler deleteOldFilesHandler;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public Lei1601UseCase
        (
            GetDataHandler getDataHandler,
            SequenceHandler sequenceHandler,
            GetBankHandler getBankHandler,
            GenerateFileHandler generateFileHandler,
            SaveFileHandler saveFileHandler,
            DeleteOldFilesHandler deleteOldFilesHandler,
            IFileWriteOnlyRepository fileWriteOnlyRepository,
            ILogWriteOnlyRepository logWriteOnlyRepository
        )
        {
            this.deleteOldFilesHandler = deleteOldFilesHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;

            deleteOldFilesHandler.SetSucessor(getDataHandler);           
            getDataHandler.SetSucessor(sequenceHandler);
            sequenceHandler.SetSucessor(getBankHandler);
            getBankHandler.SetSucessor(generateFileHandler);          
            generateFileHandler.SetSucessor(saveFileHandler);
        }

        public void Execute(Lei1601Request request)
        {
            try
            {
                request.AddProcessingLog("Processing Lei 1601");

                deleteOldFilesHandler.ProcessRequest(request);
            }
            catch (Exception ex)
            {
                request.AddExceptionLog(ex.InnerException?.Message ?? ex.Message, ex.StackTrace);

                request.Files.ForEach(f =>
                {
                    if (f?.Id != null)
                        fileWriteOnlyRepository.Add(f);
                });
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
