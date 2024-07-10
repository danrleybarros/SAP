using Gcsb.Connect.SAP.Application.Repositories;
using System;

namespace Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers
{
    public class SaveLogsHandler : Handler<IRequest>, ISaveLogsHandler
    {
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public SaveLogsHandler(ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public override void ProcessRequest(IRequest request)
        {
            if (request.File != null)
                request.Logs.ForEach(f => f.SetFileId(request.File.Id));

            logWriteOnlyRepository.Add(request.Logs);

            sucessor?.ProcessRequest(request);
        }
    }
}
