using Autofac.Features.Indexed;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.MoveJsdnFile.Model;

namespace Gcsb.Connect.SAP.MoveJsdnFile.UseCases.All
{
    public class AllFilesUseCase : IDownloadFilesUseCase
    {
        private readonly IIndex<TypeRegister, IDownloadFilesUseCase> downloadFiles;

        public AllFilesUseCase(IIndex<TypeRegister, IDownloadFilesUseCase> downloadFiles)
        {
            this.downloadFiles = downloadFiles;
        }

        public TypeRegister TypeRegister => TypeRegister.ALL;

        public void Execute(Configs configs)
        {
            downloadFiles[TypeRegister.BILL].Execute(configs);
            downloadFiles[TypeRegister.PAYMENT].Execute(configs);
            downloadFiles[TypeRegister.PAYMENTBOLETO].Execute(configs);
            downloadFiles[TypeRegister.RETURNNF].Execute(configs);
        }
    }
}
