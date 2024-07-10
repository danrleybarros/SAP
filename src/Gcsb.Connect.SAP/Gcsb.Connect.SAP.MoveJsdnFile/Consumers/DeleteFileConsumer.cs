using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.MoveJsdnFile.UseCases.ExecuteJob;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.MoveJsdnFile.Consumers
{
    public class DeleteFileConsumer : IConsumer<Messaging.Messages.File.ProcessFile>
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;
        private readonly IExecuteJobUseCase executeJobUseCase;
        private readonly IProcessFile process;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public DeleteFileConsumer(IFileReadOnlyRepository fileReadOnlyRepository, IExecuteJobUseCase executeJobUseCase, IProcessFile processFile, IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
            this.executeJobUseCase = executeJobUseCase;
            this.process = processFile;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public async Task Consume(ConsumeContext<Messaging.Messages.File.ProcessFile> context)
        {
            var processFile = context.Message;
            var progressInterfacesTypes = new List<TypeRegister>() { TypeRegister.BILL, TypeRegister.PAYMENT, TypeRegister.PAYMENTBOLETO, TypeRegister.RETURNNF };
            if (progressInterfacesTypes.Contains(processFile.Type))
                interfaceProgressUseCase.Successfully(new InterfaceProgressRequest(processFile.Id, GetUploadType(processFile.Type)));

            await Task.Run(() =>
            {
                var file = fileReadOnlyRepository.GetById(processFile.Id);

                process.DeleteFile($"{Environment.GetEnvironmentVariable("PROCESS_LOCAL_PATH")}/", file.FileName);
                executeJobUseCase.SetIsJob(false);
                executeJobUseCase.Execute();
            });
        }

        public Domain.Upload.Enum.UploadTypeEnum GetUploadType(TypeRegister typeRegister)
        {
            switch (typeRegister)
            {
                case TypeRegister.BILL: return Domain.Upload.Enum.UploadTypeEnum.Billfeed;
                case TypeRegister.PAYMENT: return Domain.Upload.Enum.UploadTypeEnum.PaymentFeedCreditCard;
                case TypeRegister.PAYMENTBOLETO: return Domain.Upload.Enum.UploadTypeEnum.PaymentFeedBoleto;
                default: return Domain.Upload.Enum.UploadTypeEnum.Billfeed;
            }
        }
    }
}
