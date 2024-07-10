using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.Application.UseCases.GF.Client.RequestHandlers;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Client
{
    public class ClientUseCase : IClientUseCase
    {
        private readonly GetCustomersHandler GetCustumersHandler;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;
        private readonly ILogWriteOnlyRepository LogWriteOnlyRepository;

        public ClientUseCase(SaveFileHandler saveFileHandler,
            PrepareDataHandler prepareDataHandler,
            GetFileNameHandler getFileNameHandler,
            CreateClientHandler createClientHandler,
            GenerateClientHandler generateClientHandler,
            InsertQueueHandler insertQueueHandler,
            GetCustomersHandler getCustumersHandler,
            GetAddressHandler getAddressHandler,
            ILogWriteOnlyRepository logWriteOnlyRepository,
            IPublisher<Messaging.Messages.File.File> publisher,
            IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            getCustumersHandler.SetSucessor(getAddressHandler);
            getAddressHandler.SetSucessor(prepareDataHandler);
            prepareDataHandler.SetSucessor(getFileNameHandler);
            getFileNameHandler.SetSucessor(saveFileHandler);
            saveFileHandler.SetSucessor(createClientHandler);
            createClientHandler.SetSucessor(generateClientHandler);
            generateClientHandler.SetSucessor(insertQueueHandler);
            this.GetCustumersHandler = getCustumersHandler;
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
            this.LogWriteOnlyRepository = logWriteOnlyRepository;
        }

        public int Execute(ClientRequest clientRequest)
        {
            var requestChain = new ClientChainRequest(clientRequest.IdFileNF);

            try
            {
                GetCustumersHandler.ProcessRequest(requestChain);
                return 1;
            }
            catch (Exception e)
            {
                requestChain.Logs.Add(requestChain.ClientFile == null ? Log.CreateExceptionLog(requestChain.Service, e.Message, e.StackTrace) :
                    Log.CreateExceptionLog(requestChain.Service, requestChain.ClientFile.Id, e.Message, e.StackTrace));
                interfaceProgressUseCase.Error(new InterfaceProgressRequest(clientRequest.IdFileNF, Domain.Upload.Enum.UploadTypeEnum.ReturnNF));
                return 0;
            }
            finally
            {
                if (requestChain.ClientFile?.Id != null)
                    requestChain.ClientFile.Logs = requestChain.Logs;
                LogWriteOnlyRepository.Add(requestChain.Logs);
                publisher.PublishAsync(requestChain.ClientFile); // Send to Reprocessing a file copy 
            }
        }
    }
}
