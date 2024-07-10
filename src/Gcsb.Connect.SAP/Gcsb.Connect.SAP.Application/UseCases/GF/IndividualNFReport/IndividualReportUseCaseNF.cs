using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport.RequestHandlers;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport
{
    public class IndividualReportUseCaseNF : IIndividualReportNFUseCase
    {
        private readonly GetStoresHandler getStoresHandler;
        private readonly SaveLogsHandler saveLogsHandler;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;

        public IndividualReportUseCaseNF(GetStoresHandler getStoresHandler,
            GetInvoicesHandler getInvoicesHandler,
            GetLocalizationHandler getLocalizationHandler,
            MountIndividualReportHandler mountIndividualReport,
            SaveFileHandler saveFileHandler,
            GenerateOutputHandler generateOutputHandler,
            SaveLogsHandler saveLogsHandler,
            IPublisher<Messaging.Messages.File.File> publisher,
            IInterfaceProgressUseCase interfaceProgressUseCase,
            IFileReadOnlyRepository fileReadOnlyRepository)
        {
            getStoresHandler.SetSucessor(getInvoicesHandler);
            getInvoicesHandler.SetSucessor(getLocalizationHandler);
            getLocalizationHandler.SetSucessor(mountIndividualReport);
            mountIndividualReport.SetSucessor(saveFileHandler);
            saveFileHandler.SetSucessor(generateOutputHandler);

            this.getStoresHandler = getStoresHandler;
            this.saveLogsHandler = saveLogsHandler;
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public void Execute(IndividualReportRequestNF request)
        {
            if (request == null)
                throw new ArgumentNullException("Object request is null");

            try
            {
                if (!fileReadOnlyRepository.GetFiles(w => w.Type.Equals(TypeRegister.INDIVIDUALREPORT) && w.IdParent.Value.Equals(request.IdBillFeedFile)).Any())
                    getStoresHandler.ProcessRequest(request);
            }
            catch (Exception ex)
            {
                request.Logs.Add(Log.CreateExceptionLog(request.Service, $"Occurred an error: {ex.Message ?? ex.InnerException.Message}", ex.StackTrace));
                interfaceProgressUseCase.Error(new InterfaceProgressRequest(request.Files.FirstOrDefault()?.IdParent, Domain.Upload.Enum.UploadTypeEnum.Billfeed));
            }
            finally
            {
                saveLogsHandler.ProcessRequest(request);

                request.Files.ForEach(file =>
                {
                    if (file?.Id != null) file.Logs = request.Logs;

                    publisher.PublishAsync(file);
                });
            }
        }
    }
}
