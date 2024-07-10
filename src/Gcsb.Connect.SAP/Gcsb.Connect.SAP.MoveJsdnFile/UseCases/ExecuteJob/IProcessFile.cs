namespace Gcsb.Connect.SAP.MoveJsdnFile.UseCases.ExecuteJob
{
    public interface IProcessFile
    {
        bool ExistFile(string pathProcess);
        void DeleteFile(string pathFiles, string fileName);
    }
}
