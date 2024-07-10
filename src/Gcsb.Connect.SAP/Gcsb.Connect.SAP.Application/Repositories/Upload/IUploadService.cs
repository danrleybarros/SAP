namespace Gcsb.Connect.SAP.Application.Repositories.Upload
{
    public interface IUploadService
    {
        void Upload(string fileName, string base64, string destLocalPath);
    }
}
