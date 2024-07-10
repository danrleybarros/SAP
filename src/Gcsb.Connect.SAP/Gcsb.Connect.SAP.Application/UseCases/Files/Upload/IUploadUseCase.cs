using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Upload
{
    public interface IUploadUseCase
    {
        Task Execute(UploadUseCaseRequest request);
        object Execute(string tenantID);
    }
}
