using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.Application.UseCases.GF.SpecialRegime.RequestHandlers;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.SpecialRegime
{
    public class SpecialRegimeUseCase : ISpecialRegimeUseCase
    {
        private readonly GetServicesHandler getServicesHandler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;

        public SpecialRegimeUseCase(GetServicesHandler getServicesHandler,
            GetStoresHandler getStoresHandler,
            GroupingServicesHandler groupingServicesHandler,
            ValidateHandler validateHandler,
            SaveFileHandler saveFileHandler,
            GenerateSpecialRegimeFileHandler generateSpecialRegimeFileHandler,
            ILogWriteOnlyRepository logWriteOnlyRepository,
            IFileWriteOnlyRepository fileWriteOnlyRepository,
            IPublisher<Messaging.Messages.File.File> publisher,
            IInterfaceProgressUseCase interfaceProgressUseCase,
            IFileReadOnlyRepository fileReadOnlyRepository)
        {
            getServicesHandler.SetSucessor(getStoresHandler);
            getStoresHandler.SetSucessor(groupingServicesHandler);
            groupingServicesHandler.SetSucessor(validateHandler);
            validateHandler.SetSucessor(saveFileHandler);
            saveFileHandler.SetSucessor(generateSpecialRegimeFileHandler);

            this.getServicesHandler = getServicesHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public int Execute(SpecialRegimeRequest request)
        {
            try
            {
                if (!fileReadOnlyRepository.GetFiles(w => w.Type.Equals(TypeRegister.SPECIALREGIME) && w.IdParent.Value.Equals(request.FileIdBillFeed)).Any())
                    getServicesHandler.ProcessRequest(request);
                return 1;
            }
            catch (Exception e)
            {
                if (request.Files.Count > 0)
                    request.Files.ForEach(f =>
                    {
                        Log.CreateExceptionLog(request.Service, f.Id, e.Message, e.StackTrace);
                        f.Status = Status.Error;

                        fileWriteOnlyRepository.UpdateStatus(f.Id, f.Status);
                    });
                else
                    Log.CreateExceptionLog(request.Service, e.Message, e.StackTrace);
                interfaceProgressUseCase.Error(new InterfaceProgressRequest(request.Files.FirstOrDefault()?.IdParent, Domain.Upload.Enum.UploadTypeEnum.Billfeed));
                return 0;
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);

                request.Files.ForEach(f =>
                {
                    f.Logs = request.Logs;
                    publisher.PublishAsync(f); //Send to Reprocessing a file copy 
                });
            }
        }
    }
}
