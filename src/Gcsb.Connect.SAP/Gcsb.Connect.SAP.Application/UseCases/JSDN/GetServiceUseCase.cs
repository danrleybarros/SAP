using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.JSDN;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN
{
    public class GetServiceUseCase : IGetServiceUseCase
    {
        private IJsdnService jsdnService;
        private ILogWriteOnlyRepository LogRepository;

        public GetServiceUseCase(Repositories.IJsdnService jsdnService, ILogWriteOnlyRepository logRepository)
        {
            this.jsdnService = jsdnService;
            this.LogRepository = logRepository;
        }

        public async Task<List<Service>> Execute(GetServiceRequest request)
        {
            try
            {
                return await jsdnService.GetServices(request.Token);
            }
            catch (Exception ex)
            {
                LogRepository.Add(new Log("GetServiceUseCase.Execute", ex.Message, TypeLog.Error, ex.StackTrace, ""));
                throw new Exception(ex.Message);
            }
        }
    }
}
