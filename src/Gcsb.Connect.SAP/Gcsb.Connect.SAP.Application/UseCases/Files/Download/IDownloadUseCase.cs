namespace Gcsb.Connect.SAP.Application.UseCases.Files.Download
{
    public interface IDownloadUseCase
    {
        DownloadOutput Execute(DownloadUseCaseRequest request);
    }
}
