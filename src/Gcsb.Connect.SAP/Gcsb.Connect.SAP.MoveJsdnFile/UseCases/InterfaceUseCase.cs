using Autofac.Features.Indexed;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.MoveJsdnFile.Model;

namespace Gcsb.Connect.SAP.MoveJsdnFile.UseCases
{
    public class InterfaceUseCase : IInterfaceUseCase
    {
        private readonly IIndex<TypeRegister, IDownloadFilesUseCase> downloadFiles;

        public InterfaceUseCase(IIndex<TypeRegister, IDownloadFilesUseCase> downloadFiles)
        {
            this.downloadFiles = downloadFiles;
        }

        public void Execute(Configs configs, TypeRegister typeRegister)
        {
            Serilog.Log.Information($"Executing interfaces: {System.Enum.GetName(typeof(TypeRegister), typeRegister)}");

            downloadFiles[typeRegister].Execute(configs);
        }
    }
}
