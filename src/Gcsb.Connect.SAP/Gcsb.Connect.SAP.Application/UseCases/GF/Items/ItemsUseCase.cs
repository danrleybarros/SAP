using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Items
{
    public class ItemsUseCase : IItemsUseCase
    {
        private readonly GetInvoicesHandler getInvoicesHandler;
        private readonly SaveLogsHandler saveLogsHandler;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public ItemsUseCase(GetInvoicesHandler getInvoicesHandler,
                            GetIbgeCodHandlers getIbgeCodHandlers,
                            GetNFsHandler getNFsHandler,
                            MountItemsHandler mountItemsHandler,
                            SaveFileHandler saveFileHandler,
                            GenerateOutputHandler generateOutputHandler,
                            SaveLogsHandler saveLogsHandler,
                            InsertQueueHandler insertQueueHandler,
                            GetFileNameHandler getFileNameHandler,
                            IPublisher<Messaging.Messages.File.File> publisher,
                            IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            getInvoicesHandler.SetSucessor(getIbgeCodHandlers);
            getIbgeCodHandlers.SetSucessor(getNFsHandler);
            getNFsHandler.SetSucessor(mountItemsHandler);
            mountItemsHandler.SetSucessor(getFileNameHandler);
            getFileNameHandler.SetSucessor(saveFileHandler);
            saveFileHandler.SetSucessor(generateOutputHandler);
            generateOutputHandler.SetSucessor(insertQueueHandler);

            this.getInvoicesHandler = getInvoicesHandler;
            this.saveLogsHandler = saveLogsHandler;
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public void Execute(ItemsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Object request is null");

            try
            {
               getInvoicesHandler.ProcessRequest(request);
            }
            catch (Exception ex)
            {
                request.Logs.Add(Log.CreateExceptionLog(request.Service, $"Occurred an error in ItemsUseCase: {ex.Message ?? ex.InnerException.Message}", ex.StackTrace));
                interfaceProgressUseCase.Error(new InterfaceProgressRequest(request.File?.IdParent, Domain.Upload.Enum.UploadTypeEnum.ReturnNF));
            }
            finally
            {
                if (request != null && (request.Logs != null && request.Logs.Count > 0))
                    saveLogsHandler.ProcessRequest(request);
                if (request.File?.Id != null)
                    request.File.Logs = request.Logs;
                publisher.PublishAsync(request.File); // Send to Reprocessing a file copy 
            }
        }
    }
}
