using System.Linq;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Download.Handlers
{
    public class GetInterfacesNamesHandler : Handler<DownloadUseCaseRequest>
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;
        private readonly IOutputPort<DownloadOutput> outputPort;

        public GetInterfacesNamesHandler(IFileReadOnlyRepository fileReadOnlyRepository, IOutputPort<DownloadOutput> outputPort)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
            this.outputPort = outputPort;
        }
        public override void ProcessRequest(DownloadUseCaseRequest request)
        {
            request.AddProcessingLog("GetInterfacesNamesHandler");

            var NonDownloadableTypes = new TypeRegister[] { TypeRegister.BILLCSV, TypeRegister.PAYMENTBOLETOTSV, TypeRegister.PAYMENTTSV, TypeRegister.CRITICALFILE, TypeRegister.RETURNNF };
            request.Interfaces = fileReadOnlyRepository.GetFiles(s => (s.IdParent == request.FileId || s.Id == request.FileId) && !NonDownloadableTypes.Contains(s.Type));
            if (request.Interfaces == null || request.Interfaces.Count == 0 )
            {
                outputPort.NotFound("Not found interfaces to download");
                return;
            }
            sucessor?.ProcessRequest(request);
        }
    }
}
