using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress
{
    public interface IInterfaceProgressUseCase
    {
        Task Successfully(InterfaceProgressRequest request);
        Task Error(InterfaceProgressRequest request);
        Task Progress(InterfaceProgressRequest request);
    }
}
