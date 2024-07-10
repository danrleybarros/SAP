using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT
{
    public class FATFaturado : FATUseCase<Domain.FAT.FATFaturado.FATFaturado>
    {
        public FATFaturado(SequenceHandler sequenceHandler,
                          InvoiceHandler invoiceHandler,
                          GetAddressHandler getAddressHandler,
                          ServicesFATHandler serviceHandler,
                          AccountsFATHandler accountsHandler,
                          LaunchHandler launchHandler,
                          IGenerateFileHandler<Domain.FAT.FATFaturado.FATFaturado> generateFileHandler,
                          SaveFileHandler saveFileHandler,
                          InsertQueueHandler insertQueueHandler,
                          ILogWriteOnlyRepository logWriteOnlyRepository,
                          IFileWriteOnlyRepository fileWriteOnlyRepository,
                          IPublisher<Messaging.Messages.File.File> publisher,
                          GetAccountingAccountHandler getAccountingAccountHandler,
                          FineServicesFATHandler fineServicesFATHandler,
                          InterestServicesFATHandler interestServicesFATHandler,
                          GetInterestAndFineFinancialAccountHandler getInterestAndFineFinancialAccountHandler,
                          LaunchInterestAndFinesHandler launchInterestAndFinesHandler,
                          ContractualServicesFATHandler contractualFineServicesHandler,
                          GetContractualFineAccountHandler getContractualFineAccountHandler,
                          LaunchContractualFineHandler launchContractualFineHandler,
                          GetCounterchargeDisputeByCycleHandler getCounterchargeDisputeByCycleHandler,
                          CounterchargeChargebackServicesFATHandler counterchargeChargebackServicesFATHandler,
                          InterestAndFineChargebackLaunchHandler interestAndFineChargebackLaunchHandler,
                          GetFinancialAccountDefferralHandler getFinancialAccountDefferralHandler,
                          LaunchDeferralHandler launchDeferralHandler,
                          SaveDeferralHistoryHandler saveDeferralHistoryHandler,
                          IInterfaceProgressUseCase interfaceProgressUseCase,
                          IFileReadOnlyRepository fileReadOnlyRepository)
            : base(sequenceHandler, logWriteOnlyRepository, fileWriteOnlyRepository, publisher, interfaceProgressUseCase,fileReadOnlyRepository)
        {
            sequenceHandler.SetSucessor(invoiceHandler);
            invoiceHandler.SetSucessor(getAddressHandler);
            getAddressHandler.SetSucessor(serviceHandler);
            serviceHandler.SetSucessor(fineServicesFATHandler);
            fineServicesFATHandler.SetSucessor(interestServicesFATHandler);
            interestServicesFATHandler.SetSucessor(contractualFineServicesHandler);
            contractualFineServicesHandler.SetSucessor(accountsHandler);
            accountsHandler.SetSucessor(getAccountingAccountHandler);
            getAccountingAccountHandler.SetSucessor(getFinancialAccountDefferralHandler);
            getFinancialAccountDefferralHandler.SetSucessor(getInterestAndFineFinancialAccountHandler);
            getInterestAndFineFinancialAccountHandler.SetSucessor(getContractualFineAccountHandler);
            getContractualFineAccountHandler.SetSucessor(launchDeferralHandler);
            launchDeferralHandler.SetSucessor(saveDeferralHistoryHandler);
            saveDeferralHistoryHandler.SetSucessor(launchHandler);            
            launchHandler.SetSucessor(launchInterestAndFinesHandler);
            launchInterestAndFinesHandler.SetSucessor(getCounterchargeDisputeByCycleHandler);
            getCounterchargeDisputeByCycleHandler.SetSucessor(counterchargeChargebackServicesFATHandler);
            counterchargeChargebackServicesFATHandler.SetSucessor(interestAndFineChargebackLaunchHandler);
            interestAndFineChargebackLaunchHandler.SetSucessor(launchContractualFineHandler);
            launchContractualFineHandler.SetSucessor(generateFileHandler);
            generateFileHandler.SetSucessor(saveFileHandler);
            saveFileHandler.SetSucessor(insertQueueHandler);
        }
    }
}
