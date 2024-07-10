namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IUploadFile
    {
        bool Execute(string strFile, string strFileName, string strPath);
    }
}
