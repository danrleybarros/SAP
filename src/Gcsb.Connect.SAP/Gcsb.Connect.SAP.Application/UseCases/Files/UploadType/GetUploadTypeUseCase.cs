using Gcsb.Connect.FakeEnv.Application.UseCases.Files.GetUploadType.Handlers;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.UploadTypeDto;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.UploadType
{
    public class GetUploadTypeUseCase : IGetUploadTypeUseCase
    {
        private readonly GetUploadTypeHandler getUploadTypeHandler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IOutputPort<List<UploadTypeDto>> outputPort;

        public GetUploadTypeUseCase(GetUploadTypeHandler getUploadTypeHandler, ILogWriteOnlyRepository logWriteOnlyRepository,
                                    IOutputPort<List<UploadTypeDto>> outputPort)
        {
            this.getUploadTypeHandler = getUploadTypeHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.outputPort = outputPort;
        }

        public void Execute(GetUploadTypeUseCaseRequest request)
        {
            try
            {
                getUploadTypeHandler.ProcessRequest(request);
                this.outputPort.Standard(request.UploadTypes);
            }
            catch (Exception ex)
            {
                request.AddErrorLog(ex.Message, "GetUploadTypeUseCase.Execute: " + ex.StackTrace);

                logWriteOnlyRepository.Add(new Log("GetUploadTypeUseCase", ex.Message, TypeLog.Error, ex.StackTrace, request.UserId.ToString()));

                throw new Exception(ex.Message);
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
