using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.Download.Handlers;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Download
{
    public class DownloadUseCase : IDownloadUseCase
    {
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IOutputPort<DownloadOutput> outputPort;
        private readonly VerifyUploadProgressHandler verifyUploadProgressHandler;

        public DownloadUseCase(ILogWriteOnlyRepository logWriteOnlyRepository, IOutputPort<DownloadOutput> outputPort, VerifyUploadProgressHandler verifyUploadProgressHandler,
            GetInterfacesNamesHandler getInterfacesNamesHandler, DownloadInterfacesHandler downloadInterfacesHandler, ConvertBase64Handler convertBase64Handler)
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.outputPort = outputPort;
            this.verifyUploadProgressHandler = verifyUploadProgressHandler;

            verifyUploadProgressHandler.SetSucessor(getInterfacesNamesHandler);
            getInterfacesNamesHandler.SetSucessor(downloadInterfacesHandler);
            downloadInterfacesHandler.SetSucessor(convertBase64Handler);
        }
        public DownloadOutput Execute(DownloadUseCaseRequest request)
        {
            try
            {
                verifyUploadProgressHandler.ProcessRequest(request);                
                return new DownloadOutput() { Base64 = request?.Base64, BytesFile = request?.BytesZip, Logs = request.Logs };
            }
            catch (Exception e)
            {
                request.AddExceptionLog(e.Message, e.StackTrace);
                outputPort.Error(e.Message);
                return new DownloadOutput() { Logs = request.Logs };
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
