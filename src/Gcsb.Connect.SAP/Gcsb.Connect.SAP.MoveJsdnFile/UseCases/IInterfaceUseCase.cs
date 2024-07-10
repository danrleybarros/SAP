using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.MoveJsdnFile.Model;

namespace Gcsb.Connect.SAP.MoveJsdnFile.UseCases
{
    public interface IInterfaceUseCase
    {
        void Execute(Configs configs, TypeRegister typeRegister);
    }
}
