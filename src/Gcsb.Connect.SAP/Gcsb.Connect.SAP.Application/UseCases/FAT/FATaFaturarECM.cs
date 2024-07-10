using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarECM;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT
{
    public class FATaFaturarECM : FATUseCase<Domain.FAT.FATaFaturarECM.FATaFaturarECM>
    {
        public FATaFaturarECM(SequenceHandler sequenceHandler,
                          InvoiceHandler invoiceHandler,
                          GetAddressHandler getAddressHandler,
                          ServicesFATECMHandler serviceHandler,
                          AccountsFATECMHandler accountsHandler,
                          LaunchHandler launchHandler,
                          IGenerateFileHandler<Domain.FAT.FATaFaturarECM.FATaFaturarECM> generateFileHandler,
                          SaveFileHandler saveFileHandler,
                          InsertQueueHandler insertQueueHandler,
                          ILogWriteOnlyRepository logWriteOnlyRepository,
                          IFileWriteOnlyRepository fileWriteOnlyRepository,
                          IPublisher<Messaging.Messages.File.File> publisher,
                          GetAccountingAccountHandler getAccountingAccountHandler,
                          FineServicesFATECMHandler fineServicesFATHandler,
                          InterestServicesFATECMHandler interestServicesFATHandler,
                          GetInterestAndFineFinancialAccountHandler getInterestAndFineFinancialAccountHandler,
                          LaunchInterestAndFinesHandler launchInterestAndFinesHandler,
                          ContractualServicesFATECMHandler contractualFineServicesHandler,
                          GetContractualFineAccountHandler getContractualFineAccountHandler,
                          LaunchContractualFineHandler launchContractualFineHandler,
                          GetCounterchargeDisputeByCycleHandler getCounterchargeDisputeByCycleHandler,
                          CounterchargeChargebackServicesFATHandler counterchargeChargebackServicesFATHandler,
                          InterestAndFineChargebackLaunchHandler interestAndFineChargebackLaunchHandler,
                          GetFinancialAccountDefferralHandler getFinancialAccountDefferralHandler,
                          LaunchDeferralHandler launchDeferralHandler,
                          IInterfaceProgressUseCase interfaceProgressUseCase,
                          IFileReadOnlyRepository fileReadOnlyRepository)
            : base(sequenceHandler, logWriteOnlyRepository, fileWriteOnlyRepository, publisher, interfaceProgressUseCase, fileReadOnlyRepository)
        {
            sequenceHandler.SetSucessor(invoiceHandler);
            invoiceHandler.SetSucessor(getAddressHandler);
            getAddressHandler.SetSucessor(serviceHandler);
            serviceHandler.SetSucessor(fineServicesFATHandler);
            fineServicesFATHandler.SetSucessor(interestServicesFATHandler);
            interestServicesFATHandler.SetSucessor(contractualFineServicesHandler);
            contractualFineServicesHandler.SetSucessor(accountsHandler);
            accountsHandler.SetSucessor(getAccountingAccountHandler);
            getAccountingAccountHandler.SetSucessor(getInterestAndFineFinancialAccountHandler);
            getInterestAndFineFinancialAccountHandler.SetSucessor(getContractualFineAccountHandler);
            getContractualFineAccountHandler.SetSucessor(getFinancialAccountDefferralHandler);
            getFinancialAccountDefferralHandler.SetSucessor(launchDeferralHandler);
            launchDeferralHandler.SetSucessor(launchHandler);
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
