using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.MoveJsdnFile.Model;

namespace Gcsb.Connect.SAP.MoveJsdnFile.UseCases
{
    public interface IDownloadFilesUseCase
    {
        TypeRegister TypeRegister { get; }

        void Execute(Configs configs);
    }
}
