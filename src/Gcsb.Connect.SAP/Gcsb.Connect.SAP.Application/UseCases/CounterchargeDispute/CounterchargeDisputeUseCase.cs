using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.Domain.GenerateInterfaceDtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute
{
    public class CounterchargeDisputeUseCase : ICounterchargeDisputeUseCase
    {
        private readonly SequenceHandler sequenceHandler;
        private readonly SetUploadStatusHandler setUploadStatusHandler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly IPublisher<Messaging.Messages.File.File> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public CounterchargeDisputeUseCase(SequenceHandler sequenceHandler,
            CounterchargeDisputeAdjustmentHandler counterchargeDisputeAdjustmentHandler,
            CounterchargeDisputeBillingHandler counterchargeDisputeBillingHandler,
            FinancialAccountsHandler financialAccounts,
            GetInterestAndFineFinancialAccountHandler getInterestAndFineFinancialAccountHandler,
            GetCreditGrantedFinancialAccountsHandler getCreditGrantedFinancialAccountsHandler,
            ValidateAllServiceCodeHandler validateAllServiceCodeHandler,
            GetAccountingEntryHandler getAccountingEntryHandler,
            SaveFileHandler saveFileHandler,
            LaunchHandler launchHandler,
            InterestAndFineLaunchHandler interestAndFineLaunchHandler,
            CreditGrantedLaunchHandler creditGrantedLaunchHandler,
            GenerateFileHandler generateFileHandler,
            GetContractualFineAccountingEntryHandler getContractualFineAccountingEntryHandler,
            ContractualFineLaunchHandler contractualFineLaunchHandler,
            GetInvoiceCycleHandler getInvoiceCycleHandler,
            SetUploadStatusHandler setUploadStatusHandler,            
            ILogWriteOnlyRepository logWriteOnlyRepository,
            IFileWriteOnlyRepository fileWriteOnlyRepository,
            IPublisher<Messaging.Messages.File.File> publisher,
            IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            sequenceHandler.SetSucessor(counterchargeDisputeAdjustmentHandler);
            counterchargeDisputeAdjustmentHandler.SetSucessor(counterchargeDisputeBillingHandler);
            counterchargeDisputeBillingHandler.SetSucessor(getInvoiceCycleHandler);
            getInvoiceCycleHandler.SetSucessor(financialAccounts);
            financialAccounts.SetSucessor(getInterestAndFineFinancialAccountHandler);
            getInterestAndFineFinancialAccountHandler.SetSucessor(getCreditGrantedFinancialAccountsHandler);
            getCreditGrantedFinancialAccountsHandler.SetSucessor(validateAllServiceCodeHandler);
            validateAllServiceCodeHandler.SetSucessor(getAccountingEntryHandler);
            getAccountingEntryHandler.SetSucessor(launchHandler);
            launchHandler.SetSucessor(interestAndFineLaunchHandler);
            interestAndFineLaunchHandler.SetSucessor(creditGrantedLaunchHandler);
            creditGrantedLaunchHandler.SetSucessor(getContractualFineAccountingEntryHandler);
            getContractualFineAccountingEntryHandler.SetSucessor(contractualFineLaunchHandler);
            contractualFineLaunchHandler.SetSucessor(generateFileHandler);            
            generateFileHandler.SetSucessor(saveFileHandler);

            this.sequenceHandler = sequenceHandler;
            this.setUploadStatusHandler = setUploadStatusHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public async Task<CounterChargeDisputeOutput> Execute(CounterchargeDisputeRequest request)
        {
            CounterChargeDisputeOutput output;
            request.InterfaceProgressIdParent = Guid.NewGuid();

            try
            {
                request.AddProcessingLog("Processing FAT57");
                await interfaceProgressUseCase.Progress(new InterfaceProgressRequest(request.InterfaceProgressIdParent, Domain.Upload.Enum.UploadTypeEnum.Fat57_79));
                if (!request.IsJob)
                    await setUploadStatusHandler.UpdateStatus(request, Domain.Upload.Enum.StatusType.Processing);

                sequenceHandler.ProcessRequest(request);
                
                await interfaceProgressUseCase.Successfully(new InterfaceProgressRequest(request.InterfaceProgressIdParent, Domain.Upload.Enum.UploadTypeEnum.Fat57_79));
                if (!request.IsJob)
                    await setUploadStatusHandler.UpdateStatus(request, Domain.Upload.Enum.StatusType.Success);
            }
            catch (Exception e)
            {
                request.AddExceptionLog(e.Message, e.StackTrace);

                request.Files.ForEach(f =>
                {
                    if (f?.Id != null)
                        fileWriteOnlyRepository.Add(f);
                });
                await interfaceProgressUseCase.Error(new InterfaceProgressRequest(request.InterfaceProgressIdParent, Domain.Upload.Enum.UploadTypeEnum.Fat57_79));
                if (!request.IsJob)
                    await setUploadStatusHandler.UpdateStatus(request, Domain.Upload.Enum.StatusType.Error);
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
                request.Files.ForEach(f => publisher.PublishAsync(f));
                var erros = request?.Logs?.Where(s => s.TypeLog == Messaging.Messages.Log.Enum.TypeLog.Error).Select(s => new NotificationError(s.Message, s.StackTrace)).ToList();
                output = new CounterChargeDisputeOutput(erros, request?.Files?.Select(s => new GeneratedInterface(s.FileName)).ToList());
            }
            return output;
        }
    }
}
