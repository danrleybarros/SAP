using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories.Download;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Download.Handlers
{
    public class DownloadInterfacesHandler : Handler<DownloadUseCaseRequest>
    {
        private readonly IDownloadService downloadService;
        private readonly IOutputPort<DownloadOutput> outputPort;
        private readonly string destLocalPath;

        public DownloadInterfacesHandler(IDownloadService downloadService, IOutputPort<DownloadOutput> outputPort)
        {
            this.downloadService = downloadService;
            this.outputPort = outputPort;
            this.destLocalPath = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH")??"";
        }
        public override void ProcessRequest(DownloadUseCaseRequest request)
        {
            request.AddProcessingLog("DownloadInterfacesHandler");

            request.BytesZip = downloadService.DownloadZip(request.Interfaces.Select(s=>s.FileName).ToList(), destLocalPath);
            if (request.BytesZip == null)
            {
                outputPort.NotFound($"Not found Intefaces files to download in volume: {destLocalPath}");
                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
