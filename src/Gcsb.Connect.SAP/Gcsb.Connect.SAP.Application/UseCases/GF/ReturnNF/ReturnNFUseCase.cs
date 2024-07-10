using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.Application.UseCases.GF.ReturnNF.ReturnNFHandlers;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.ReturnNF
{
    public class ReturnNFUseCase : IReturnNFUseCase
    {
        private readonly VerifyProcessFileHandler verifyProcessFileHandler;

        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public ReturnNFUseCase(VerifyProcessFileHandler verifyProcessFileHandler,
            SaveFileHandler saveFileHandler,
            ConvertHandler convertHandler,
            ValidateHandler validateHandler,
            SaveReturnNFsHandler saveReturnNfHandler,
            ExecuteDeferralHandler executeDeferralHandler,
            GenerateFATsHandler generateFATsHandler,
            InsertQueueHandler insertQueueHandler,
            ILogWriteOnlyRepository logWriteOnlyRepository,
            IFileWriteOnlyRepository fileWriteOnlyRepository,
            IPublisher<Messaging.Messages.File.File> publisher,
            IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            verifyProcessFileHandler.SetSucessor(saveFileHandler);
            saveFileHandler.SetSucessor(convertHandler);
            convertHandler.SetSucessor(validateHandler);
            validateHandler.SetSucessor(saveReturnNfHandler);
            saveReturnNfHandler.SetSucessor(executeDeferralHandler);
            executeDeferralHandler.SetSucessor(generateFATsHandler);
            generateFATsHandler.SetSucessor(insertQueueHandler);

            this.verifyProcessFileHandler = verifyProcessFileHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public int Execute(ReturnNFRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            try
            {
                verifyProcessFileHandler.ProcessRequest(request);

                return Result(request);
            }
            catch (Exception ex)
            {
                request.Logs.Add(Log.CreateExceptionLog(request.Service, ex.Message, ex.StackTrace));

                if (request.File?.Id != null)
                {
                    fileWriteOnlyRepository.UpdateStatus(request.File.Id, Status.Error);
                    request.File.Status = Status.Error;
                }
                interfaceProgressUseCase.Error(new InterfaceProgressRequest(request.File?.IdParent, Domain.Upload.Enum.UploadTypeEnum.ReturnNF));
                return 0;
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
                publisher.PublishAsync(request.File);
            }
        }

        private int Result(ReturnNFRequest request)
        {
            var retorno = 1;

            if (request.Logs.Select(s => s.TypeLog).Contains(TypeLog.Error))
            {
                fileWriteOnlyRepository.UpdateStatus(request.File.Id, Status.Error);
                retorno = 0;
            }

            return retorno;
        }
    }
}
