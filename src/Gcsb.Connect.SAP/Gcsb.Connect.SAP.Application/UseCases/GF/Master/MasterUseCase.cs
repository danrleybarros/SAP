using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.Application.UseCases.GF.Master.RequestHandlers;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Master
{
    public class MasterUseCase : IMasterUseCase
    {
        private readonly IGetInvoicesHandler getInvoiceHandler;
        private readonly ISaveLogsHandler saveLogsHandler;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;

        public MasterUseCase(IGetInvoicesHandler getInvoiceHandler, 
                            IGetReturnNFHandler getReturnNFHandler,
                            IGetFileNameHandler getFileNameHandler,
                            IMountMasterHandler mountItemsHandler,
                            ISaveFileHandler<MasterRequest> saveFileHandler,
                            IGenerateOutputHandler<MasterRequest> generateOutputHandler,
                            ISaveLogsHandler saveLogsHandler,
                            IInsertQueueHandler insertQueueHandler,
                            IPublisher<Messaging.Messages.File.File> publisher,
                            IFileWriteOnlyRepository fileWriteOnlyRepository,
                            IInterfaceProgressUseCase interfaceProgressUseCase
            )
        {            
            getInvoiceHandler.SetSucessor(getReturnNFHandler);
            getReturnNFHandler.SetSucessor(getFileNameHandler);
            getFileNameHandler.SetSucessor(mountItemsHandler);
            mountItemsHandler.SetSucessor(saveFileHandler);
            saveFileHandler.SetSucessor(generateOutputHandler);
            generateOutputHandler.SetSucessor(insertQueueHandler);
            this.getInvoiceHandler = getInvoiceHandler;
            this.saveLogsHandler = saveLogsHandler;
            this.publisher = publisher;
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public void Execute(MasterRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Object request is null");

            try
            {
                getInvoiceHandler.ProcessRequest(request);
            }
            catch(Exception ex)
            {
                request.AddExceptionLog(ex.Message, ex.StackTrace);

                if (request.File?.Id != null)
                {
                    fileWriteOnlyRepository.UpdateStatus(request.File.Id, Status.Error);
                    request.File.Status = Status.Error;
                }
                interfaceProgressUseCase.Error(new InterfaceProgressRequest(request.IdNFFile, Domain.Upload.Enum.UploadTypeEnum.ReturnNF));
            }
            finally
            {
                if (request != null && (request.Logs != null && request.Logs.Count > 0))
                    saveLogsHandler.ProcessRequest((IRequest)request);
                if (request.File?.Id != null)
                    request.File.Logs = request.Logs;
                publisher.PublishAsync(request.File); // Send to Reprocessing a file copy 
            }
        }
    }
}
