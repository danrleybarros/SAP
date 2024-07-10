using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport.RequestHandlers
{
    public class SaveLogsHandler : Handler
    {
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public SaveLogsHandler(ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public override void ProcessRequest(IndividualReportRequestNF request)
        {
            logWriteOnlyRepository.Add(request.Logs);

            sucessor?.ProcessRequest(request);
        }
    }
}
