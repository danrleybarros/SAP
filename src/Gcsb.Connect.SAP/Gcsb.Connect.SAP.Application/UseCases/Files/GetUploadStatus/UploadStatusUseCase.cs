using System;
using System.Collections.Generic;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.File.RequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.Files.GetUploadStatus.Handlers;
using Gcsb.Connect.SAP.Domain.Upload;

namespace Gcsb.Connect.SAP.Application.UseCases.File.Upload
{
    public class UploadStatusUseCase : IUploadStatusUseCase
    {
        private readonly GetUploadsHandler uploadStatusHandler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IOutputPort<List<UploadStatusDto>> outputPort;

        public UploadStatusUseCase(GetUploadsHandler uploadStatusHandler, ILogWriteOnlyRepository logWriteOnlyRepository,
                                    IOutputPort<List<UploadStatusDto>> outputPort, GetInterfacesLogsHandler getInterfacesLogsHandler,
                                    GetUploadStatusHandler getUploadStatusHandler)
        {
            uploadStatusHandler.SetSucessor(getUploadStatusHandler);
            getUploadStatusHandler.SetSucessor(getInterfacesLogsHandler);

            this.uploadStatusHandler = uploadStatusHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.outputPort = outputPort;
        }

        public void Execute(UploadStatusRequest request)
        {
            try
            {
                uploadStatusHandler.ProcessRequest(request);
                if (request.Output != null || request.Output?.Count > 0)                                
                    outputPort.Standard(request.Output);
            }
            catch (Exception ex)
            {
                request.AddErrorLog("UploadStatusUseCase", ex.Message, "UpdateStatusUseCase.Execute: " + ex.StackTrace);
                logWriteOnlyRepository.Add(new Log("UpdateStatusUseCase", ex.Message, TypeLog.Error, ex.StackTrace, request.UserId.ToString()));
                outputPort.Error(ex.Message);
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
