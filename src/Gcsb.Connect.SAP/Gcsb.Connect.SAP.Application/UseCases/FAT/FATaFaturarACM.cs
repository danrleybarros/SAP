using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarACM;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT
{
    public class FATaFaturarACM : FATUseCase<Domain.FAT.FATaFaturarACM.FATaFaturarACM>
    {
        public FATaFaturarACM(SequenceHandler sequenceHandler,
            InvoiceHandler invoiceHandler,
            GetAddressHandler getAddressHandler,
            ServicesFATACMHandler serviceHandler,
            AccountsFATACMHandler accountsHandler,
            LaunchHandler launchHandler,
            IGenerateFileHandler<Domain.FAT.FATaFaturarACM.FATaFaturarACM> generateFileHandler,
            SaveFileHandler saveFileHandler,
            ILogWriteOnlyRepository logWriteOnlyRepository,
            IFileWriteOnlyRepository fileWriteOnlyRepository,
            IPublisher<Messaging.Messages.File.File> publisher,
            GetAccountingAccountHandler getAccountingAccountHandler,
            ValidateAllServiceCodeHandler validateAllServiceCodeHandler,
            GetFinancialAccountDefferralHandler getFinancialAccountDefferralHandler,
            LaunchDeferralHandler launchDeferralHandler,            
            IInterfaceProgressUseCase interfaceProgressUseCase,          
            IFileReadOnlyRepository fileReadOnlyRepository)
            : base(sequenceHandler, logWriteOnlyRepository, fileWriteOnlyRepository, publisher, interfaceProgressUseCase, fileReadOnlyRepository)
        {
            sequenceHandler.SetSucessor(invoiceHandler);
            invoiceHandler.SetSucessor(getAddressHandler);
            getAddressHandler.SetSucessor(serviceHandler);
            serviceHandler.SetSucessor(accountsHandler);
            accountsHandler.SetSucessor(validateAllServiceCodeHandler);
            validateAllServiceCodeHandler.SetSucessor(getAccountingAccountHandler);
            getAccountingAccountHandler.SetSucessor(getFinancialAccountDefferralHandler);
            getFinancialAccountDefferralHandler.SetSucessor(launchDeferralHandler);          
            launchDeferralHandler.SetSucessor(launchHandler);          
            launchHandler.SetSucessor(generateFileHandler);
            generateFileHandler.SetSucessor(saveFileHandler);
        }
    }
}
