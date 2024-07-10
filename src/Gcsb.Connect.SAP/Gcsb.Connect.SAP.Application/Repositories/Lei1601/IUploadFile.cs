namespace Gcsb.Connect.SAP.Application.Repositories.Lei1601
{
    public interface IUploadFile
    {
        bool Execute(string strFile, string strFileName, string strPath);
    }
}
