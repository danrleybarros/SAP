using Gcsb.Connect.SAP.Application.Repositories;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers
{
    public class SaveLogsHandler : Handler
    {
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public SaveLogsHandler(ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public override void ProcessRequest(ItemsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Object request is null");

            try
            {
                if (request.File != null)
                    request.Logs.ForEach(f => f.SetFileId(request.File.Id));

                logWriteOnlyRepository.Add(request.Logs);

                if (sucessor != null)
                    sucessor.ProcessRequest(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
